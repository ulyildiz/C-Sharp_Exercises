using System;
using System.Diagnostics;

class Program
{
    public static uint score = 0;
    static void Main()
    {
    Start:
        Console.WriteLine("You have press given key within 1 second to gain a score.");
        Console.WriteLine("Press space key to start the game or press 'q' to quit the game.");
        if (Console.ReadKey().KeyChar == 'q')
            return;
        else if (Console.ReadKey().KeyChar != ' ')
        {
            Console.Clear();
            goto Start;
        }
        Stopwatch stopwatch = new Stopwatch();
        const string chars = "asdf";
        var rand = new Random();

        while (true)
        {
            int randindex = rand.Next(0, chars.Length - 1);

            Console.WriteLine($"Current score -> {score}");
            Console.WriteLine("Get ready to press the key.");
            Thread.Sleep(rand.Next(0, chars.Length - 1) * 500);
            Console.WriteLine($"Press {chars[randindex]}");

            stopwatch.Start();
            char givenKey = Console.ReadKey().KeyChar;
            stopwatch.Stop();
            Console.Clear();
            
            if (givenKey == chars[randindex] && stopwatch.ElapsedMilliseconds < 1000)
            {
                score++;
                Console.WriteLine($"Correct key pressed in {stopwatch.ElapsedMilliseconds} milisecond.");
            }
            else if (givenKey == 'q')
                break;
            else
                Console.WriteLine($"Wrong key pressed in {stopwatch.ElapsedMilliseconds} milisecond.");
            
            stopwatch.Reset();
        }
    }
}