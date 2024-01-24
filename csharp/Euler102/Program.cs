using System.Numerics;

var lines = File.ReadAllLines("input.txt");
var triangles = lines.Select(l => new Triangle(l));
Console.WriteLine(triangles.Count(t => t.ContainsOrigin()));

internal class Triangle
{
    public Point A { get; }
    public Point B { get; }
    public Point C { get; }

    public Triangle(string line)
    {
        var parts = line.Split(',').Select(int.Parse).ToList();
        A = new Point(parts.First(), parts.Skip(1).First());
        B = new Point(parts.Skip(2).First(), parts.Skip(3).First());
        C = new Point(parts.Skip(4).First(), parts.Skip(5).First());
    }
    public bool ContainsOrigin()
    {
        var area = BigInteger.Abs(BigInteger.Multiply(A.X - C.X, B.Y - A.Y) - BigInteger.Multiply(A.X - B.X, C.Y - A.Y));
        var area1 = BigInteger.Abs(BigInteger.Multiply(A.X, B.Y - A.Y) - BigInteger.Multiply(A.Y, B.X - A.X));
        var area2 = BigInteger.Abs(BigInteger.Multiply(B.X, C.Y - B.Y) - BigInteger.Multiply(B.Y, C.X - B.X));
        var area3 = BigInteger.Abs(BigInteger.Multiply(C.X, A.Y - C.Y) - BigInteger.Multiply(C.Y, A.X - C.X));
        return area == area1 + area2 + area3;
    }
}

internal record Point(int X, int Y);
