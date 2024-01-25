using Euler;

var setSize = 12;

var result = Enumerable.Range(2, setSize / 2 + 1).Sum(i => Combination(setSize, i * 2) * (Combination(i * 2, i) / 2 - Catalan(i)));

Console.WriteLine(result);

static long Combination(int n, int k) => Numerics.Factorial(n) / (Numerics.Factorial(k) * Numerics.Factorial(n - k));

static long Catalan(int n) => Numerics.Factorial(2 * n) / (Numerics.Factorial(n) * Numerics.Factorial(n + 1));