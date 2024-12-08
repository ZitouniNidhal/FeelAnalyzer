using System.Diagnostics;
public abstract class EmotionAnalyzer
{
    public abstract string Analyze();
    public abstract string Analyze(string imagePath, string additionalArgument);
}

public class FacialEmotionAnalyzer : EmotionAnalyzer
{
    private readonly string pythonScriptPath; // Make this field readonly

    public FacialEmotionAnalyzer(string scriptPath)
    {
        pythonScriptPath = scriptPath; // Assign the value in the constructor
    }

    public override string Analyze()
    {
        PythonScriptRunner runner = new PythonScriptRunner();
        string result = runner.RunScript(pythonScriptPath, "");
        return result;
    }

    public override string Analyze(string imagePath, string additionalArgument)
    {
        PythonScriptRunner runner = new PythonScriptRunner();
        string result = runner.RunScript(pythonScriptPath, $"\"{imagePath}\" \"{additionalArgument}\"");
        return result;
    }
}

