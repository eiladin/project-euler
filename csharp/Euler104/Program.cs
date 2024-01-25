using System.Numerics;
using Euler;

var (Index, Value) = Numerics.FibonacciIndex()
    .Where(f => Numerics.IsPandigital((long)(f.Value % 1_000_000_000)) && Numerics.IsPandigital(Convert.ToInt64(f.Value.ToString()[..9])))
    .First();

Console.WriteLine(Index);