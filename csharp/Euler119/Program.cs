using System.Numerics;
using Euler;

var results = Enumerable.Range(2, 2000)
          .SelectMany(i => Enumerable.Range(2, 8).Select(power => (i, power, result: BigInteger.Pow(i, power))))
          .Where(n => Numerics.GetDigits(n.result).Sum() == n.i)
          .ToList();

var result = results.OrderBy(x => x.result).Skip(29).First().result;
Console.WriteLine(result);