using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static byte[] HexToBytes(string hex)
    {
        if (hex.Length % 2 != 0)
        {
            throw new ArgumentException("Hex string must have an even length.");
        }

        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < hex.Length; i += 2)
        {
            string byteString = hex.Substring(i, 2);
            bytes[i / 2] = Convert.ToByte(byteString, 16);
        }

        return bytes;
    }

    static byte[] CalculateXOR(byte[] bytes1, byte[] bytes2)
    {
        if (bytes1.Length != bytes2.Length)
        {
            throw new ArgumentException("Byte arrays must have the same length.");
        }

        byte[] result = new byte[bytes1.Length];
        for (int i = 0; i < bytes1.Length; i++)
        {
            result[i] = (byte)(bytes1[i] ^ bytes2[i]);
        }

        return result;
    }
    public static bool IsValidUtf8(byte[] bytes)
    {
        try
        {
            Encoding.UTF8.GetString(bytes);
            return true;
        }
        catch (DecoderFallbackException)
        {
            return false;
        }
    }

    static void Main(string[] args)
    {
        string message1Hex = Console.ReadLine();
        string message2Hex = Console.ReadLine();
        string message3Hex = Console.ReadLine();

        byte[] message1 = HexToBytes(message1Hex);
        byte[] message2 = HexToBytes(message2Hex);
        byte[] message3 = HexToBytes(message3Hex);
        byte[] aliceBobKeyXor = CalculateXOR(message1, message3); 
        byte[] bobKey = CalculateXOR(message2, message3); 
        byte[] decryptedMessage = CalculateXOR(bobKey, message1);

        if (IsValidUtf8(decryptedMessage))
        {
            string textMessage = Encoding.UTF8.GetString(decryptedMessage);
            Console.WriteLine(textMessage);
        }
        else
        {
            Console.WriteLine("Decryption failed. Invalid UTF-8 string.");
        }
    }
}
