using System.Numerics;
using Euler;

var max = Enumerable.Range(1, 100)
                    .SelectMany(a => Enumerable.Range(1, 100).Select(b => Numerics.GetDigits(BigInteger.Pow(a, b)).Sum()))
                    .Max();

Console.WriteLine(max);