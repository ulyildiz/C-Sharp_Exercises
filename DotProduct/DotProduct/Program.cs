using System;
using System.Runtime.ExceptionServices;

class Program
{
    public static int DotProduct(int[] vector1, int[] vector2)
    {
        int result = 0;
        for (int i = 0; i < vector1.Length; i++)
        {
            result += vector1[i] * vector2[i];
        }
        return result;
    }

    public static void Main()
    {
        Console.WriteLine("Enter the dimension of vectors: ");
        int[][] vectors = new int[2][];
        try
        {
        Dim:
            string dimension = Console.ReadLine();
            if (!int.TryParse(dimension, out int dim))
            {
                Console.WriteLine("Invalid input");
                return;
            }


        First:
            Console.WriteLine("Enter the first vector: ");
            string[] vector = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            vectors[0] = vector.Select(int.Parse).ToArray();
            if (vectors[0].Length != dim)
            {
                Console.WriteLine("Vector length does not match the specified dimension");
                goto First;
            }

        Second:
            Console.WriteLine("Enter the second vector: ");
            vector = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            vectors[1] = vector.Select(int.Parse).ToArray();
            if (vectors[1].Length != dim)
            {
                Console.WriteLine("Vector length does not match the specified dimension");
                goto Second;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        int dotProduct = DotProduct(vectors[0], vectors[1]);
        double angle = Math.Acos(dotProduct / (Math.Sqrt(DotProduct(vectors[0], vectors[0])) * Math.Sqrt(DotProduct(vectors[1], vectors[1]))));
    
        Console.WriteLine($"The dot product of the two vectors is {dotProduct}");
        Console.WriteLine($"The angle between the two vectors is {angle} radians");
        
        Console.ReadKey();
    }
}
