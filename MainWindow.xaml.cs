using System;
using System.Windows;
using System.Windows.Controls;

namespace EmotionApp
{
    public partial class MainWindow : Window
    {
        private FacialEmotionAnalyzer facialAnalyzer;
        private TextEmotionAnalyzer textAnalyzer;

        public MainWindow()
        {
            InitializeComponent();

            // Initialiser les analyseurs avec les chemins des scripts Python
            facialAnalyzer = new FacialEmotionAnalyzer("facial_emotion_script.py");
            textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", string.Empty);
        }

        // Méthode pour analyser les émotions faciales
        private void AnalyzeFacialEmotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Appel de l'analyseur facial et affichage du résultat
                string result = facialAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse faciale : {result}", "Résultat");
            }
            catch (Exception ex)
            {
                // Gestion des erreurs avec un message d'alerte
                MessageBox.Show($"Erreur lors de l'analyse faciale : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Méthode pour analyser les émotions textuelles
        private void AnalyzeTextEmotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Ajouter une validation supplémentaire pour TextInputBox
                if (TextInputBox == null || string.IsNullOrWhiteSpace(TextInputBox.Text))
                {
                    MessageBox.Show("Veuillez entrer un texte à analyser.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string inputText = TextInputBox.Text;

                // Mise à jour de l'instance de l'analyseur textuel pour inclure le texte utilisateur
                textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", inputText);

                // Appel de l'analyseur textuel et affichage du résultat
                string result = textAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse textuelle : {result}", "Résultat");
            }
            catch (Exception ex)
            {
                // Gestion des erreurs avec un message d'alerte
                MessageBox.Show($"Erreur lors de l'analyse textuelle : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
