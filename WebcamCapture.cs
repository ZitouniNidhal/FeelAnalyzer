using OpenCvSharp;
using System;

public class WebcamCapture
{
    private string _imagePath;
    private string _emotionAnalyzerScript;

    public WebcamCapture(string imagePath = "captured_face.jpg", string emotionAnalyzerScript = "emotion_detection.py")
    {
        _imagePath = imagePath;
        _emotionAnalyzerScript = emotionAnalyzerScript;
    }

    public string CaptureAndAnalyzeEmotion()
    {
        try
        {
            using (var capture = new VideoCapture(0))
            {
                if (!capture.IsOpened())
                {
                    throw new Exception("Unable to open the webcam.");
                }

                Mat frame = new Mat();
                capture.Read(frame);

                if (frame.Empty())
                {
                    throw new Exception("Failed to capture an image from the webcam.");
                }

                // Sauvegarder l'image capturée pour l'analyse
                Cv2.ImWrite(_imagePath, frame);

                // Analyser l'image capturée
                return AnalyzeEmotion(_imagePath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return "Error";
        }
    }

    private string AnalyzeEmotion(string imagePath)
    {
        var facialAnalyzer = new FacialEmotionAnalyzer(_emotionAnalyzerScript);
        string additionalArgument = "some_value"; // Définir l'argument requis
        return facialAnalyzer.Analyze(imagePath, additionalArgument);
    }
}