using System;
using System.IO;
using System.Threading.Tasks;

namespace BlackHawk.Utils
{
    public static class FileUtil
    {
        public static string GetAppDataPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        }

        public static string GetDocumentsPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static async Task<bool> SaveFileAsync(string filename, byte[] fileData)
        {
            try
            {
                var path = Path.Combine(GetDocumentsPath(), filename);
                await File.WriteAllBytesAsync(path, fileData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static async Task<byte[]> ReadFileAsync(string filename)
        {
            try
            {
                var path = Path.Combine(GetDocumentsPath(), filename);
                return await File.ReadAllBytesAsync(path);
            }
            catch
            {
                return null;
            }
        }

        public static long GetFileSize(string filename)
        {
            try
            {
                var path = Path.Combine(GetDocumentsPath(), filename);
                return new FileInfo(path).Length;
            }
            catch
            {
                return 0;
            }
        }
    }
}
