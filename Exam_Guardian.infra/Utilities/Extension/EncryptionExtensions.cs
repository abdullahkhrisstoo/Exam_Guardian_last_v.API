using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionExtensions
{
    private static readonly string Key = "your16charsecret"; 

    public static string Encrypt(this string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; 

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    public static string Decrypt(this string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; 

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
