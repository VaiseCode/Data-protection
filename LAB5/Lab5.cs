using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CodeWars 
{
      public static string Encode(string text)
      {
        StringBuilder encodedBits = new StringBuilder();

        foreach (char c in text)
        {
            int asciiValue = (int)c;
            string binaryValue = Convert.ToString(asciiValue, 2).PadLeft(8, '0');

            StringBuilder tripledBits = new StringBuilder();
            foreach (char bit in binaryValue)
            {
                tripledBits.Append(new string(bit, 3));
            }

            encodedBits.Append(tripledBits);
        }

        return encodedBits.ToString();
    }

    public static string Decode(string bits)
    {
        StringBuilder decodedBits = new StringBuilder();

        for (int i = 0; i < bits.Length; i += 24)
        {
            string triple = bits.Substring(i, 24);

            StringBuilder correctedBits = new StringBuilder();
            for (int j = 0; j < triple.Length; j += 3)
            {
                string bitGroup = triple.Substring(j, 3);
                char correctedBit = bitGroup.GroupBy(b => b).OrderByDescending(g => g.Count()).First().Key;
                correctedBits.Append(correctedBit);
            }

            for (int k = 0; k < correctedBits.Length; k += 8)
            {
                string binaryByte = correctedBits.ToString().Substring(k, 8);
                int asciiValue = Convert.ToInt32(binaryByte, 2);
                char decodedChar = (char)asciiValue;
                decodedBits.Append(decodedChar);
            }
        }

        return decodedBits.ToString();
    }

    static void Main()
    {
        string inputText = Console.ReadLine();
        string encodedText = Encode(inputText);
        string decodedText = Decode(encodedText);

        Console.WriteLine("Original Text: " + inputText);
        Console.WriteLine("Encoded Text: " + encodedText);
        Console.WriteLine("Decoded Text: " + decodedText);
    }
}
