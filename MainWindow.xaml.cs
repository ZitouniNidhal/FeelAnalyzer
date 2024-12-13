using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace EmotionApp
{
    public partial class MainWindow : Window
    {
        private FacialEmotionAnalyzer _facialAnalyzer;
        private TextEmotionAnalyzer _textAnalyzer;

        public MainWindow()
        {
            InitializeComponent();

            // Initialisation des analyseurs avec les chemins des scripts Python
            _facialAnalyzer = new FacialEmotionAnalyzer("facial_emotion_script.py");
            _textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", string.Empty);
        }

        // Analyse des émotions faciales
        private void AnalyzeFacialEmotion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UpdateStatus("Analyse faciale en cours...");

                // Simulation d'analyse faciale
                string result = _facialAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse faciale : {result}", "Résultat");

                UpdateStatus("Analyse faciale terminée.");
                SaveResultToFile(result, "facial_emotion_result.txt");
            }
            catch (Exception ex)
            {
                HandleError("Erreur lors de l'analyse faciale", ex);
            }
        }

        // Analyse des émotions textuelles
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
                _textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", inputText);

                UpdateStatus("Analyse textuelle en cours...");

                string result = _textAnalyzer.Analyze();
                MessageBox.Show($"Résultat de l'analyse textuelle : {result}", "Résultat");

                UpdateStatus("Analyse textuelle terminée.");
                SaveResultToFile(result, "text_emotion_result.txt");
            }
            catch (Exception ex)
            {
                HandleError("Erreur lors de l'analyse textuelle", ex);
            }
        }

        // Sauvegarde des résultats dans un fichier
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
                HandleError("Erreur lors de la sauvegarde du fichier", ex);
            }
        }

        // Chargement d'un fichier texte dans la TextBox
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
                    HandleError("Erreur lors de l'ouverture du fichier", ex);
                }
            }
        }

        // Copier le résultat dans le presse-papier
        private void CopyResultToClipboard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(StatusTextBlock.Text))
                {
                    Clipboard.SetText(StatusTextBlock.Text);
                    MessageBox.Show("Résultat copié dans le presse-papier.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Aucun résultat disponible à copier.", "Attention", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                HandleError("Erreur lors de la copie du résultat", ex);
            }
        }

        // Quitter l'application
        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Mise à jour de l'état
        private void UpdateStatus(string message)
        {
            StatusTextBlock.Text = message;
        }

        // Gestion des erreurs
        private void HandleError(string errorMessage, Exception ex)
        {
            UpdateStatus(errorMessage);
            MessageBox.Show($"{errorMessage}\nDétails : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    // Simulateur d'analyse faciale
    public class FacialEmotionAnalyzer
    {
        private string _scriptPath;

        public FacialEmotionAnalyzer(string scriptPath)
        {
            _scriptPath = scriptPath;
        }

        public string Analyze()
        {
            // Simulation de l'appel d'un script Python
            return "Émotion détectée : Joie";
        }
    }

    // Simulateur d'analyse textuelle
    public class TextEmotionAnalyzer
    {
        private string _scriptPath;
        private string _inputText;

        public TextEmotionAnalyzer(string scriptPath, string inputText)
        {
            _scriptPath = scriptPath;
            _inputText = inputText;
        }

        public string Analyze()
        {
            // Simulation de l'appel d'un script Python
            return "Émotion détectée : Tristesse";
        }
    }
}
