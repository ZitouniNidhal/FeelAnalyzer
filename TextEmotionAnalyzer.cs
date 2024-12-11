using System;
using System.IO;

public class TextEmotionAnalyzer : EmotionAnalyzer
{
    private string pythonScriptPath;
    private string inputText;

    // Constructor with input validation
    public TextEmotionAnalyzer(string scriptPath, string text)
    {
        if (string.IsNullOrWhiteSpace(scriptPath))
        {
            throw new ArgumentException("Script path cannot be null or empty.", nameof(scriptPath));
        }

        if (!File.Exists(scriptPath))
        {
            throw new FileNotFoundException("The specified Python script file does not exist.", scriptPath);
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Input text cannot be null or empty.", nameof(text));
        }

        pythonScriptPath = scriptPath;
        inputText = text;
    }

    // Override Analyze method for text analysis
    public override string Analyze()
    {
        try
        {
            Log("Starting emotion analysis for the provided text.");

            PythonScriptRunner runner = new PythonScriptRunner();
            string result = runner.RunScript(pythonScriptPath, EscapeArgument(inputText));

            Log("Emotion analysis completed successfully.");
            return result;
        }
        catch (Exception ex)
        {
            LogError($"Error during emotion analysis: {ex.Message}");
            throw;
        }
    }

    // Unimplemented method to handle other types of analysis
    public override string Analyze(string imagePath, string additionalArgument)
    {
        throw new NotImplementedException("Image analysis is not supported in this class.");
    }

    // Method to escape arguments safely for the Python script
    private string EscapeArgument(string argument)
    {
        return argument.Replace("\"", "\\\"");
    }

    // Method to log information messages
    private void Log(string message)
    {
        Console.WriteLine($"[INFO] {DateTime.Now}: {message}");
    }

    // Method to log error messages
    private void LogError(string errorMessage)
    {
        Console.WriteLine($"[ERROR] {DateTime.Now}: {errorMessage}");
    }

    // Additional feature: Export analysis results to a file
    public void ExportResults(string result, string outputPath)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                throw new ArgumentException("Output path cannot be null or empty.", nameof(outputPath));
            }

            File.WriteAllText(outputPath, result);
            Log($"Results exported successfully to {outputPath}.");
        }
        catch (Exception ex)
        {
            LogError($"Error exporting results: {ex.Message}");
            throw;
        }
    }

    // Additional feature: Validate input text length
    public bool IsValidInputLength(int maxLength)
    {
        if (inputText.Length > maxLength)
        {
            LogError($"Input text exceeds the maximum allowed length of {maxLength} characters.");
            return false;
        }

        Log("Input text length is valid.");
        return true;
    }

    // Additional feature: Display summary of the class state
    public void DisplaySummary()
    {
        Console.WriteLine("\n--- TextEmotionAnalyzer Summary ---");
        Console.WriteLine($"Python Script Path: {pythonScriptPath}");
        Console.WriteLine($"Input Text Length: {inputText.Length}");
        Console.WriteLine($"Input Text Preview: {inputText.Substring(0, Math.Min(50, inputText.Length))}...");
        Console.WriteLine("------------------------------------\n");
    }
}