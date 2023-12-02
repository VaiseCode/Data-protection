using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    public static long DiscreteLogAttack(long G, long H, long Q)
    {
        long m = (long)Math.Sqrt(Q) + 1;
        long gPowM = ModPow(G, m, Q);
        var babySteps = new Dictionary<long, long>();
        long babyStep = 1;
        for (long i = 0; i < m; i++)
        {
            babySteps[babyStep] = i;
            babyStep = (babyStep * G) % Q;
        }
        long giantStep = H;
        long giantStepMultiplier = ModPow(gPowM, Q - 2, Q);

        for (long j = 0; j < m; j++)
        {
            if (babySteps.TryGetValue(giantStep, out long i))
            {
                return (j * m + i) % Q;
            }

            giantStep = (giantStep * giantStepMultiplier) % Q;
        }

        throw new Exception("No solution found");
    }

    public static long ModPow(long baseValue, long exponent, long modulus)
    {
        if (modulus == 1)
            return 0;

        long result = 1;
        baseValue %= modulus;
        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * baseValue) % modulus;
            exponent >>= 1;
            baseValue = (baseValue * baseValue) % modulus;
        }

        return result;
    }

    public static void Main(string[] args)
    {
        string input = Console.ReadLine();
        string[] inputValues = input.Split(' ');
        if (inputValues.Length != 3 ||
            !long.TryParse(inputValues[0], out long G) ||
            !long.TryParse(inputValues[1], out long H) ||
            !long.TryParse(inputValues[2], out long Q))
        {
            Console.WriteLine("Invalid input format. Please enter three valid numeric values separated by spaces.");
            return;
        }

        try
        {
            long result = DiscreteLogAttack(G, H, Q);
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
