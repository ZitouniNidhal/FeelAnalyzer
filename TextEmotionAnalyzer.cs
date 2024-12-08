public class TextEmotionAnalyzer : EmotionAnalyzer
{
    private string pythonScriptPath;
    private string inputText;

    public TextEmotionAnalyzer(string scriptPath, string text)
    {
        pythonScriptPath = scriptPath;
        inputText = text;
    }

    public override string Analyze()
    {
        PythonScriptRunner runner = new PythonScriptRunner();
        string result = runner.RunScript(pythonScriptPath, $"\"{inputText}\"");
        return result;
    }

    public override string Analyze(string imagePath, string additionalArgument)
    {
        throw new NotImplementedException();
    }
}
