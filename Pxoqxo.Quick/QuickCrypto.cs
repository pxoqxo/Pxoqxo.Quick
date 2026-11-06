using System.Security.Cryptography;
using System.Text;

namespace Pxoqxo.Quick
{
    public static class QuickCrypto
    {
        private static byte[] key = [];
        private static byte[] iv = [];

        public static string? GenerateSecret()
        {
            try
            {
                using Aes aes = Aes.Create();
                aes.GenerateKey();
                aes.GenerateIV();

                return PackSecret(aes.Key, aes.IV);
            }
            catch
            {
                return null;
            }
        }
        public static bool SetSecret(string secret)
        {
            try
            {
                Tuple<byte[], byte[]>? keyIv = UnpackSecret(secret);

                if (keyIv == null)
                {
                    return false;
                }

                key = keyIv.Item1;
                iv = keyIv.Item2;

                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void ResetSecret()
        {
            key = [];
            iv = [];
        }

        public static string? ToCrypto(string plain)
        {
            try
            {
                string crypto = string.Empty;

                using Aes aes = Aes.Create();
                using ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                using MemoryStream ms = new MemoryStream();
                using CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                using StreamWriter sw = new StreamWriter(cs);
                sw.Write(plain);
                sw.Flush();
                cs.FlushFinalBlock();

                crypto = Convert.ToBase64String(ms.ToArray());

                return crypto;
            }
            catch
            {
                return null;
            }
        }
        public static string? FromCrypto(string crypto)
        {
            try
            {
                string plain = string.Empty;

                using Aes aes = Aes.Create();
                using ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(crypto));
                using CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                using StreamReader sr = new StreamReader(cs);
                plain = sr.ReadToEnd();

                return plain;
            }
            catch
            {
                return null;
            }
        }

        private static string? PackSecret(byte[] secretKey, byte[] secretIv)
        {
            try
            {
                byte[] keyArray = secretKey;
                byte[] ivArray = secretIv;

                string key = Convert.ToBase64String(keyArray);
                string iv = Convert.ToBase64String(ivArray);
                string plainSecret = key + "|" + iv;

                byte[] secretArray = Encoding.UTF8.GetBytes(plainSecret);
                string secret = Convert.ToBase64String(secretArray);

                return secret;
            }
            catch
            {
                return null;
            }
        }
        private static Tuple<byte[], byte[]>? UnpackSecret(string secret)
        {
            try
            {
                byte[] secretArray = Convert.FromBase64String(secret);
                string plainSecret = Encoding.UTF8.GetString(secretArray);

                string[] keyAndIv = plainSecret.Split('|');
                string key = keyAndIv[0];
                string iv = keyAndIv[1];

                byte[] keyArray = Convert.FromBase64String(key);
                byte[] ivArray = Convert.FromBase64String(iv);

                return Tuple.Create(keyArray, ivArray);
            }
            catch
            {
                return null;
            }
        }
    }
}
