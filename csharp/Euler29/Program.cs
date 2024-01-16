IEnumerable<double> list = Enumerable.Range(2, 99)
    .SelectMany(x => Enumerable.Range(2, 99)
        .Select(y => Math.Pow(x, y)))
    .Distinct();

Console.WriteLine(list.Count());