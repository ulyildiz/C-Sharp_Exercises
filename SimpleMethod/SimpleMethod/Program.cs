using System;

public class Program
{
    public static double Func(double x)
    {
        x = x * Math.PI / 180.0;
        return (Math.Tan(x/2)+(3*Math.Sin(x)*Math.Cos(2*x)));
    }

    public static void Main()
    {
        try
        {
            Console.WriteLine(Func(double.Parse(Console.ReadLine())));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }   
}
