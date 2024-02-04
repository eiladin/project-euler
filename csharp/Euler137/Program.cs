using Euler;

Console.WriteLine(Numerics.Fibonacci().Skip(15 * 2).Take(2).Aggregate((a, b) => a * b));