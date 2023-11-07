using System;
using System.Security.Cryptography;
using System.Text;

public class CodeWars
{
    static int length = 5;

    public static string CalculateMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public static string crack(string hash)
    {
        for (int i = 0; i < 100000; i++)
        {
            string pin = i.ToString("D5");
            string hashedPin = CalculateMD5(pin);

            if (hashedPin.Equals(hash, StringComparison.OrdinalIgnoreCase))
            {
                return pin;
            }
        }

        return "";
    }

    static void Main()
    {
        string hashToCrack = Console.ReadLine();
        string crackedPin = crack(hashToCrack);

        if (!string.IsNullOrEmpty(crackedPin))
        {
            Console.WriteLine("Cracked PIN: " + crackedPin);
        }
        else
        {
            Console.WriteLine("PIN not found.");
        }
    }
}
