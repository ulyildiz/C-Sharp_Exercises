using System;

class Program
{
    static double Function(double x)
    {
        return x*Math.Sin(2*x);
    }
    static double analytical_solution(double x)
    {
        return -(x * Math.Cos(2 * x)) / 2 + Math.Sin(2 * x) / 4;
    }
    static double Derivative(double x, double h = 1e-5)
    {
        return (Function(x + h) - Function(x - h)) / (2 * h);
    }

    public static double EulerIntegration(double xn, double yn, double eulerh, double upperlimit, double lowerlimit)
    {
        for (double i = lowerlimit; i < upperlimit; i += eulerh)
        {
            yn = yn + eulerh * Derivative(xn); // ?
            xn = xn + eulerh;
        }
        return yn;
    }

    public static void Main()
    {
        double xn = 0;
        double yn = 0;
        double upperlimit = Math.PI;
        double lowerlimit = 0;
        double eulerh = (upperlimit-lowerlimit)/7; // ?

        Console.WriteLine(EulerIntegration(xn, yn, eulerh, upperlimit, lowerlimit));
        Console.WriteLine(analytical_solution(upperlimit));
    }
}