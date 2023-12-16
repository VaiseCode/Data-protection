using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class Program
{
    public static void Main()
    {
        // Створення AES об'єкту
        using (Aes aesObject = Aes.Create())
        {
            aesObject.Mode = CipherMode.CBC;

            byte[] key = aesObject.Key;
            byte[] iv = aesObject.IV;

            byte[] plaintext = Encoding.UTF8.GetBytes("Hello, world!!");

            // Шифрування
            byte[] encryptedText = Encrypt(plaintext, key, iv);
            Console.WriteLine("Зашифрований текст: " + Convert.ToBase64String(encryptedText));

            // Розшифрування
            byte[] decryptedText = Decrypt(encryptedText, key, iv);
            Console.WriteLine("Розшифрований текст: " + Encoding.UTF8.GetString(decryptedText));
        }
    }

    public static byte[] Encrypt(byte[] plaintext, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;

            using (ICryptoTransform encryptor = aes.CreateEncryptor())
            {
                return PerformCryptography(plaintext, encryptor);
            }
        }
    }

    public static byte[] Decrypt(byte[] ciphertext, byte[] key, byte[] iv)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Mode = CipherMode.CBC;
            aes.Key = key;
            aes.IV = iv;

            using (ICryptoTransform decryptor = aes.CreateDecryptor())
            {
                return PerformCryptography(ciphertext, decryptor);
            }
        }
    }

    private static byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
            {
                cryptoStream.Write(data, 0, data.Length);
            }

            return memoryStream.ToArray();
        }
    }
}
