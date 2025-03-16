using System;
using System.Numerics;
using System.Runtime.InteropServices;
public static class Program 
{
    static void Main()
    {
        Console.WriteLine("Enter x, y1, y2, x1, x2");
        int x = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());
        int x1 = int.Parse(Console.ReadLine());
        int x2= int.Parse(Console.ReadLine());

        if (x1 == x2 || y1 == y2)
        {
            Console.WriteLine("Error");
            return;
        }
        else 
        {
            int result = y1 + (x - x1) * (y2 - y1) / (x2 - x1);
            Console.WriteLine("result-> " + result);
        }
    }
}