using System.Diagnostics;
using System.IO;

public class PythonScriptRunner
{
    public string RunScript(string scriptPath, string arguments)
    {
        ProcessStartInfo start = new ProcessStartInfo
        {
            FileName = "python",
            Arguments = $"{scriptPath} {arguments}",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(start))
        {
            using (StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}
