var result = Enumerable.Range(3, 998).Select(a => 2 * a * ((a - 1) / 2)).Sum();
Console.WriteLine(result);
