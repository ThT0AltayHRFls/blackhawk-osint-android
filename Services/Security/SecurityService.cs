using System;
using System.Security.Cryptography;
using System.Text;

namespace BlackHawk.Services.Security
{
    public class SecurityService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public bool VerifyPassword(string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput.Equals(hash);
        }

        public string EncryptString(string plainText, string key)
        {
            using (var aes = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                Array.Resize(ref keyBytes, 32);

                aes.Key = keyBytes;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new System.IO.MemoryStream())
                {
                    ms.Write(aes.IV, 0, aes.IV.Length);

                    using (var cs = new System.Security.Cryptography.CryptoStream(ms, encryptor, System.Security.Cryptography.CryptoStreamMode.Write))
                    {
                        using (var sw = new System.IO.StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        public string DecryptString(string cipherText, string key)
        {
            try
            {
                var buffer = Convert.FromBase64String(cipherText);

                using (var aes = Aes.Create())
                {
                    var keyBytes = Encoding.UTF8.GetBytes(key);
                    Array.Resize(ref keyBytes, 32);

                    aes.Key = keyBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    var iv = new byte[aes.IV.Length];
                    Array.Copy(buffer, 0, iv, 0, iv.Length);
                    aes.IV = iv;

                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream(buffer, iv.Length, buffer.Length - iv.Length))
                    {
                        using (var cs = new System.Security.Cryptography.CryptoStream(ms, decryptor, System.Security.Cryptography.CryptoStreamMode.Read))
                        {
                            using (var sr = new System.IO.StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
