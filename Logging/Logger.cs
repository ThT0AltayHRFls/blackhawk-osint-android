using System;
using System.IO;
using System.Threading.Tasks;

namespace BlackHawk.Logging
{
    public static class Logger
    {
        private static readonly string LogPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "logs");

        static Logger()
        {
            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);
        }

        public static void Debug(string message)
        {
            Log("DEBUG", message);
        }

        public static void Info(string message)
        {
            Log("INFO", message);
        }

        public static void Warning(string message)
        {
            Log("WARNING", message);
        }

        public static void Error(string message, Exception exception = null)
        {
            var fullMessage = exception != null ? $"{message} - {exception.Message}" : message;
            Log("ERROR", fullMessage);
        }

        private static void Log(string level, string message)
        {
            try
            {
                var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                var logEntry = $"[{timestamp}] [{level}] {message}";
                
                System.Diagnostics.Debug.WriteLine(logEntry);

                // File logging
                var logFile = Path.Combine(LogPath, $"log_{DateTime.Now:yyyy-MM-dd}.txt");
                File.AppendAllText(logFile, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Logging error: {ex.Message}");
            }
        }
    }
}
