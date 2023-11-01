using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution {
    static string DecodeMessage(string encodedMessage) {
        int shift = CalculateShift(encodedMessage);
        StringBuilder decodedMessage = new StringBuilder();
        
        foreach (char character in encodedMessage) 
        {
            if (char.IsLetter(character)) 
            {
                char baseCharacter = char.IsUpper(character) ? 'A' : 'a';
                char decodedChar = (char)(((character - baseCharacter - shift + 26) % 26) + baseCharacter);
                decodedMessage.Append(decodedChar);
            } 
            else 
            {
                decodedMessage.Append(character);
            }
        }

        return decodedMessage.ToString();
    }

    static int CalculateShift(string encodedMessage) 
    {
        double[] letterFrequencies = { 8.167, 1.492, 2.782, 4.253, 12.702, 2.228, 2.015, 6.094, 6.966, 0.153, 0.772, 4.025, 2.406, 6.749, 7.507, 1.929, 0.095, 5.987, 6.327, 9.056, 2.758, 0.978, 2.360, 0.150, 1.974, 0.074 };
        int bestShift = 0;
        double bestScore = double.NegativeInfinity;

    for (int shift = 0; shift < 26; shift++) 
    {
        double score = 0;
        for (int i = 0; i < encodedMessage.Length; i++) {

            char character = encodedMessage[i];
            
            if (char.IsLetter(character)) 
            {
                char baseCharacter = char.IsUpper(character) ? 'A' : 'a';
                int index = (character - baseCharacter - shift + 26) % 26;
                score += letterFrequencies[index];
            }
        }

        if (score > bestScore) 
        {
            bestScore = score;
            bestShift = shift;
        }
    }

    return bestShift;
}

    static void Main(string[] args) 
    {
        string message = Console.ReadLine();
        string decodedMessage = DecodeMessage(message);
        Console.WriteLine(decodedMessage);
    }
}
