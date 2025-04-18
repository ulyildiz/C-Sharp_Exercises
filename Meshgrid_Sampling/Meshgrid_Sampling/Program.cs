using System;
class Program
{
    static decimal Func(ref decimal x, ref decimal y)
    {
        return ((x*x) - (3*y*y) + (x*y*y*y));
    }

    static void Main()
    {
        FileStream fs = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);

        sw.WriteLine("x    |y    |z");

        for (decimal x = -2; x <= 4; x += 0.1m)
        {
            for (decimal y = -1; y <= 5; y += 0.1m)
                sw.WriteLine($"{x,-5}|{y,-5}|{Func(ref x, ref y), 10}");
        }
    }
}