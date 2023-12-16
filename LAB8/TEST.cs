using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;
using System.Security.Cryptography;

namespace Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void EncryptAndDecryptText1()
        {
            byte[] key = new byte[16]; // 16 байт для ключа (128 біт)
            byte[] iv = new byte[16]; // 16 байт для вектора ініціалізації (128 біт)
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            byte[] plaintext = Encoding.UTF8.GetBytes("Hello, world!");

            byte[] encryptedText = Program.Encrypt(plaintext, key, iv);
            byte[] decryptedText = Program.Decrypt(encryptedText, key, iv);

            string decryptedString = Encoding.UTF8.GetString(decryptedText);
            Assert.AreEqual("Hello, world!", decryptedString);
        }
        [TestMethod]
        public void EncryptAndDecryptText2()
        {
            byte[] key = new byte[16]; // 16 байт для ключа (128 біт)
            byte[] iv = new byte[16]; // 16 байт для вектора ініціалізації (128 біт)
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            byte[] plaintext = Encoding.UTF8.GetBytes("1234567890");

            byte[] encryptedText = Program.Encrypt(plaintext, key, iv);
            byte[] decryptedText = Program.Decrypt(encryptedText, key, iv);

            string decryptedString = Encoding.UTF8.GetString(decryptedText);
            Assert.AreEqual("1234567890", decryptedString);
        }
        [TestMethod]
        public void EncryptAndDecryptText3()
        {
            byte[] key = new byte[16]; // 16 байт для ключа (128 біт)
            byte[] iv = new byte[16]; // 16 байт для вектора ініціалізації (128 біт)
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            byte[] plaintext = Encoding.UTF8.GetBytes("Lorem ipsum dolor sit amet");

            byte[] encryptedText = Program.Encrypt(plaintext, key, iv);
            byte[] decryptedText = Program.Decrypt(encryptedText, key, iv);

            string decryptedString = Encoding.UTF8.GetString(decryptedText);
            Assert.AreEqual("Lorem ipsum dolor sit amet", decryptedString);
        }
        [TestMethod]
        public void EncryptAndDecryptText4()
        {
            byte[] key = new byte[16]; // 16 байт для ключа (128 біт)
            byte[] iv = new byte[16]; // 16 байт для вектора ініціалізації (128 біт)
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);
            }

            byte[] plaintext = Encoding.UTF8.GetBytes("!%$#^#$#%0029242#$%%$#$%");

            byte[] encryptedText = Program.Encrypt(plaintext, key, iv);
            byte[] decryptedText = Program.Decrypt(encryptedText, key, iv);

            string decryptedString = Encoding.UTF8.GetString(decryptedText);
            Assert.AreEqual("!%$#^#$#%0029242#$%%$#$%", decryptedString);
        }
    }
}
