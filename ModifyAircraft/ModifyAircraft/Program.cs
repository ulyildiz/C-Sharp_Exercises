using System;

class Program
{
    public void ModifyAircraft(ref double weight, ref double wingArea, double weightChangePercent, double areaChangePercent)
    {
        weight += weight * (weightChangePercent / 100);
        wingArea += wingArea * (areaChangePercent / 100);
    }

    static public void Main()
    {
        double weight;
        double wingArea;
        Program program = new Program();

        Console.WriteLine("Inputs:");
        Console.WriteLine("Enter the weight of the aircraft (in kg):");
        weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the wing area of the aircraft (in m^2):");
        wingArea = double.Parse(Console.ReadLine());

        Console.WriteLine($"Wing loading: {weight / wingArea}");

        Console.WriteLine("Enter the percentage change in weight:");
        double weightChangePercent = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the percentage change in wing area:");
        double areaChangePercent = double.Parse(Console.ReadLine());


        program.ModifyAircraft(ref weight, ref wingArea, weightChangePercent, areaChangePercent);

        Console.WriteLine("Outputs:");
        Console.WriteLine($"New weight: {weight}");
        Console.WriteLine($"New wing area: {wingArea}");
        Console.WriteLine($"New wing loading: {weight / wingArea}");
    }

}