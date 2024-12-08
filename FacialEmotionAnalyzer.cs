using System.Diagnostics;

public abstract class EmotionAnalyzer
{
    public abstract string Analyze();
}

public class FacialEmotionAnalyzer : EmotionAnalyzer
{
    private string pythonScriptPath;

    public FacialEmotionAnalyzer(string scriptPath)
    {
        pythonScriptPath = scriptPath;
    }

    public override string Analyze()
    {
        PythonScriptRunner runner = new PythonScriptRunner();
        string result = runner.RunScript(pythonScriptPath, "");
        return result;
    }
}
