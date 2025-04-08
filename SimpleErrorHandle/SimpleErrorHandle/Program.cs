using System.Numerics;
using System;
class Program
{
    public static void Main()
    {
        string input;

        while (true)
        {
            Console.WriteLine("Enter number:");
            input = Console.ReadLine();
            try
            {
                decimal.Parse(input);
                Console.WriteLine("Valid input received.");
                Console.WriteLine($"You entered: {input}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
