using System;


class Program
{

    public static double EulerIntegration(Func<double, double, double> f, double x0, double y0, double h, double x)
    {
        double y = y0;
        for (double xi = x0; xi < x; xi += h)
        {
            y += h * f(xi, y);
        }
        return y;
    }

    public static void Main()
    {
        
    }
}