using System;


class Sort
{
    public static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    public static void Quicksort(int[] array, int start, int end)
    {
        if (start >= end)
        {
            return;
        }
        int pivot = array[end];

        int i = start - 1;
        int j = start;

        while (j < end)
        {
            if (array[j] <= pivot)
            {
                i++;
                Swap(array, i, j);
            }
            j++;
        }
        Swap(array, i + 1, end);

        Quicksort(array, start, i);
        Quicksort(array, i + 2, end);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a integer array: ");
        try
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input: Empty string");
                return;
            }
            int[] array = input.Split(' ').Select(int.Parse).ToArray();

            Sort.Quicksort(array, 0, array.Length - 1);

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
            Console.Write("\n");
        }
        catch (Exception e)
        {
            Console.WriteLine("Invalid input: " + e.Message);
            return;
        }
        Console.ReadKey();
    }
}
