using System;

class Program
{
    public static ulong Factorial(ulong n)
    {
        ulong result = 1;

        for (ulong i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static double TaylorSeries(double x, ulong n)
    {
        double result = 0;

        for (ulong i = 0; i < n; i++)
        {
            result += Math.Pow(x, i) / (double)Factorial(i);
        }
        return result;
    }

    public static void Main()
    {
        double x;
        ulong n;

        try
        {
            Console.WriteLine("Enter the 'x' value:");
            x = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the number of iterations:");
            n = ulong.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input: " + e.Message);
            return;
        }

        Console.WriteLine("The result is: " + TaylorSeries(x, n));
    }
}