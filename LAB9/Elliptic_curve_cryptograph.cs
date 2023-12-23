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
        int N = int.Parse(Console.ReadLine());
        string[] keyPoints = new string[N];

        for (int i = 0; i < N; i++)
        {
            string kHex = Console.ReadLine();
            string xCoordinate = GenerateKeyPoint(kHex);
            keyPoints[i] = xCoordinate;
        }

        Console.WriteLine(string.Join(Environment.NewLine, keyPoints));
    }

    static string GenerateKeyPoint(string kHex)
    {
        long A = 0;
        long B = 7;
        long P = 0x3fddbf07bb3bc551;
        (long, long) G = (0x69d463ce83b758e, 0x287a120903f7ef5c);

        long k = Convert.ToInt64(kHex.Substring(2), 16);
        (long, long) currentPoint = G;

        for (int j = Convert.ToString(k, 2).Length - 1; j >= 0; j--)
        {
            currentPoint = PointAddition(currentPoint, currentPoint, A, P);
            if (Convert.ToString(k, 2)[j] == '1')
            {
                currentPoint = PointAddition(currentPoint, G, A, P);
            }
        }
        
        return $"0x{currentPoint.Item1:x}";
    }

    static (long, long) PointAddition((long, long) C, (long, long) D, long A, long P)
    {
        long Xc = C.Item1, Yc = C.Item2;
        long Xd = D.Item1, Yd = D.Item2;

        long L;
        if (C.Equals(D))
        {
            L = (3 * (Xc * Xc) + A) * ModularInverse(2 * Yc, P) % P;
        }
        else
        {
            L = (Yd - Yc) * ModularInverse(Xd - Xc, P) % P;
        }

        long Xs = (L * L - Xc - Xd) % P;
        long Ys = (L * (Xc - Xs) - Yc) % P;

        return (Xs, Ys);
    }

    static long ModularInverse(long num, long mod)
    {
        long t = 0, newT = 1, r = mod, newR = num;

        while (newR != 0)
        {
            long quotient = r / newR;
            (t, newT) = (newT, t - quotient * newT);
            (r, newR) = (newR, r - quotient * newR);
        }

        if (r > 1)
        {
            throw new ArgumentException("Number is not invertible");
        }

        return t + mod * (t < 0 ? 1 : 0);
    }
}
