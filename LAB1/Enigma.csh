using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string operation = Console.ReadLine();
        int pseudoRandomNumber = int.Parse(Console.ReadLine());

        string[] rotors = new string[3];
        for (int i = 0; i < 3; i++)
        {
            rotors[i] = Console.ReadLine();
        }

        string message = Console.ReadLine();

        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string result = "";

        for (int i = 0; i < message.Length; i++)
        {
            char letter = message[i];
            int shift = (pseudoRandomNumber + i) % 26;
            if (operation == "ENCODE")
            {
                char shiftedLetter = alphabet[(alphabet.IndexOf(letter) + shift) % 26];
                foreach (string rotor in rotors)
                {
                    shiftedLetter = rotor[alphabet.IndexOf(shiftedLetter)];
                }
                result += shiftedLetter;
            }
            else if (operation == "DECODE")
            {
                char shiftedLetter = letter;
                for (int j = rotors.Length - 1; j >= 0; j--)
                {
                    shiftedLetter = alphabet[rotors[j].IndexOf(shiftedLetter)];
                }
                result += alphabet[(alphabet.IndexOf(shiftedLetter) - shift + 26) % 26];
            }
        }
        Console.WriteLine(result);
    }
}
