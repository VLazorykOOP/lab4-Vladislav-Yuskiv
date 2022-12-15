using LabVector;

internal class Program
{
    private static void Main(string[] args)
    {
        VectorLong vl = new(1, 4);
        VectorLong vl2 = new(1, 3);

        Console.WriteLine(vl <= vl2);

        vl.Print();
    }
}