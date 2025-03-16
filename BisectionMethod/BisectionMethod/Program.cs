using System;
using System.ComponentModel.Design.Serialization;

class Program
{
    public static double root;

    public static double SomeEquations(double x)
    {
        return ((x * x * x) + (x * x) + x + 5);
    }

    public static void BisectionMethod(double a, double b, double tolerance)
    {
        double fa = SomeEquations(a);
        double fb = SomeEquations(b);

        if (fa * fb > 0)
            throw new Exception("There is no root that given interval.");

        double c = (a + b) / 2;
        while (Math.Abs(a-b) > tolerance)
        {
            double fc = SomeEquations(c);

            if (fc == 0)
            {
                break;
            }
            else if (fa * fc < 0)
            {
                b = c;
                fb = fc;
            }
            else if (fb * fc < 0)
            {
                a = c;
                fa = fc;
            }
            c = (a + b) / 2;
        }
        root = c;
    }

    public static void Main()
    {
        double tolerance;
        double a, b;

        try
        {
            Console.Write("Enter the value of a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Enter the value of b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Enter the tolerance: ");
            tolerance = double.Parse(Console.ReadLine());

            BisectionMethod(a, b, tolerance);
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input" + e.Message);
            return;
        }

        Console.WriteLine("The root is: " + root);
        Console.ReadKey();
    }
}
