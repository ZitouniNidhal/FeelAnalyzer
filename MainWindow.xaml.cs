using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

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
                // Indiquer que l'analyse est en cours
                FeedbackLabel.Content = "Analyse faciale en cours...";

                // Appel de l'analyseur facial et affichage du résultat
                string result = facialAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse faciale : {result}", "Résultat");

                // Mettre à jour l'état de l'application
                FeedbackLabel.Content = "Analyse faciale terminée.";
                SaveResultToFile(result, "facial_emotion_result.txt");
            }
            catch (Exception ex)
            {
                // Gestion des erreurs avec un message d'alerte
                FeedbackLabel.Content = "Erreur lors de l'analyse faciale.";
                MessageBox.Show($"Erreur lors de l'analyse faciale : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Méthode pour analyser les émotions textuelles
        private void AnalyzeTextEmotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextInputBox == null || string.IsNullOrWhiteSpace(TextInputBox.Text))
                {
                    MessageBox.Show("Veuillez entrer un texte à analyser.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string inputText = TextInputBox.Text;
                textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", inputText);

                // Indiquer que l'analyse est en cours
                FeedbackLabel.Content = "Analyse textuelle en cours...";

                string result = textAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse textuelle : {result}", "Résultat");

                FeedbackLabel.Content = "Analyse textuelle terminée.";
                SaveResultToFile(result, "text_emotion_result.txt");
            }
            catch (Exception ex)
            {
                FeedbackLabel.Content = "Erreur lors de l'analyse textuelle.";
                MessageBox.Show($"Erreur lors de l'analyse textuelle : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Méthode pour sauvegarder les résultats dans un fichier
        private void SaveResultToFile(string result, string fileName)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
                File.WriteAllText(filePath, result);
                MessageBox.Show($"Résultat sauvegardé dans : {filePath}", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde du fichier : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Méthode pour quitter l'application
        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Méthode pour ouvrir un fichier de texte existant
        private void LoadTextFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Fichiers texte (*.txt)|*.txt|Tous les fichiers (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string content = File.ReadAllText(openFileDialog.FileName);
                    TextInputBox.Text = content;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de l'ouverture du fichier : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Méthode pour copier le résultat dans le presse-papier
        private void CopyResultToClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (FeedbackLabel.Content != null && !string.IsNullOrWhiteSpace(FeedbackLabel.Content.ToString()))
                {
                    Clipboard.SetText(FeedbackLabel.Content.ToString());
                    MessageBox.Show("Résultat copié dans le presse-papier.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aucun résultat disponible à copier.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la copie du résultat : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Exemple simplifié des classes des analyseurs (Facial et Textuel)
    public class FacialEmotionAnalyzer
    {
        private string scriptPath;

        public FacialEmotionAnalyzer(string scriptPath)
        {
            this.scriptPath = scriptPath;
        }

        public string Analyze()
        {
            // Simulation d'appel au script Python
            return "Émotion détectée : Joie";
        }
    }

    public class TextEmotionAnalyzer
    {
        private string scriptPath;
        private string inputText;

        public TextEmotionAnalyzer(string scriptPath, string inputText)
        {
            this.scriptPath = scriptPath;
            this.inputText = inputText;
        }

        public string Analyze()
        {
            // Simulation d'appel au script Python
            return "Émotion détectée : Tristesse";
        }
    }
}
