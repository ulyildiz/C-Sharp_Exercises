using System;

class Program
{
    void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main(string[] args)
    {
        Program program = new Program();

        Console.WriteLine("Enter two numbers to swap:");
        Console.Write("First number: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Second number: ");
        int y = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Before Swap: x = {x}, y = {y}");
        program.Swap(ref x, ref y);
        Console.WriteLine($"After Swap: x = {x}, y = {y}");
    }
}