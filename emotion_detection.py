import cv2
import numpy as np
import tensorflow as tf
from keras.models import load_model
from keras.preprocessing import image
from tensorflow.keras.preprocessing.image import img_to_array

# Charger le modèle pré-entraîné (vous devrez avoir ce modèle .h5)
model = load_model('ferplus_model.h5')

# Dictionnaire des émotions
emotion_dict = {0: "Angry", 1: "Disgust", 2: "Fear", 3: "Happy", 4: "Sad", 5: "Surprise", 6: "Neutral"}

# Charger l'image de la webcam ou de la galerie
def predict_emotion(image_path):
    # Charger l'image en niveau de gris
    img = cv2.imread(image_path)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    
    # Détecter les visages dans l'image
    face_cascade = cv2.CascadeClassifier(cv2.data.haarcascades + 'haarcascade_frontalface_default.xml')
    faces = face_cascade.detectMultiScale(gray, scaleFactor=1.1, minNeighbors=5, minSize=(30, 30))

    for (x, y, w, h) in faces:
        roi_gray = gray[y:y+h, x:x+w]
        roi_color = img[y:y+h, x:x+w]

        # Redimensionner l'image pour qu'elle corresponde à la taille d'entrée du modèle
        roi = cv2.resize(roi_gray, (48, 48))
        roi = roi.astype('float32') / 255
        roi = np.reshape(roi, (1, 48, 48, 1))

        # Faire la prédiction avec le modèle
        prediction = model.predict(roi)
        max_index = np.argmax(prediction[0])

        # Afficher le résultat
        emotion = emotion_dict[max_index]
        return emotion
    
    return "No face detected"
