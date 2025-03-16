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

    public static double EulerIntegration(double xn, double yn, double eulerh, double upperlimit, double lowerlimit)
    {
        for (double i = lowerlimit; i < upperlimit; i += eulerh)
        {
            yn = yn + Function(xn) * eulerh;
            xn = xn + eulerh;
        }
        return yn;
    }

    public static void Main()
    {
        double upperlimit = Math.PI;
        double lowerlimit = 0;
        double eulerh = (upperlimit-lowerlimit)/1000; // ?
        double xn = lowerlimit;
        double yn = 0;

        Console.WriteLine(EulerIntegration(xn, yn, eulerh, upperlimit, lowerlimit));
        Console.WriteLine(analytical_solution(upperlimit));
    }
}