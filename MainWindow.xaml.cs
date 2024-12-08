using System.Windows;

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
        string result = facialAnalyzer.Analyze();
        MessageBox.Show($"Résultat de l'analyse faciale : {result}", "Résultat");
    }

    // Méthode pour analyser les émotions dans le texte
    private void AnalyzeTextEmotion_Click(object sender, RoutedEventArgs e)
    {
        string inputText = TextInputBox.Text;
        textAnalyzer = new TextEmotionAnalyzer("text_emotion_script.py", inputText);

        string result = textAnalyzer.Analyze();
        MessageBox.Show($"Résultat de l'analyse textuelle : {result}", "Résultat");
    }
    private void AnalyzeFacialEmotion_Click(object sender, RoutedEventArgs e)
{
    var webcamCapture = new WebcamCapture();
    string emotion = webcamCapture.CaptureAndAnalyzeEmotion();
    MessageBox.Show($"L'émotion détectée est : {emotion}", "Résultat");
}

}

