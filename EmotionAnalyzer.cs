namespace FeelAnalyzer
{public abstract class EmotionAnalyzerBase
{
    public abstract void Emot();
}

    public abstract class EmotionAnalyzer
    {
        public abstract string Analyze(string imagePath);
    }

    public class FacialEmotionAnalyzer : EmotionAnalyzer
    {
        private string pythonScriptPath;

        public FacialEmotionAnalyzer(string scriptPath)
        {
            pythonScriptPath = scriptPath;
        }

        public override string Analyze(string imagePath)
        {
            PythonScriptRunner runner = new PythonScriptRunner();
            string result = runner.RunScript(pythonScriptPath, $"\"{imagePath}\"");
            return result;
        }
    }
}
