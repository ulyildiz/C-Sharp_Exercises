using System;
using System.Net.Sockets;
using System.Numerics;
using Permutation;

namespace Permutation
{
    class Calculation
    {
        public static long FactCalculation(long i)
        {
            if (i < 0)
                return 0;
            else if (i == 0)
                return 1;
            long result = 1;
            while (i > 0)
            {
                result *= i;
                i--;
            }
            return result;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the number of elements in the set: ");
        long n = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter the number of elements to be selected: ");
        long r = Convert.ToInt64(Console.ReadLine());
        long result = Calculation.FactCalculation(n) / Calculation.FactCalculation(n - r);
        Console.WriteLine("The permutation of {0} elements taken {1} at a time is {2}", n, r, result);
    }
}
