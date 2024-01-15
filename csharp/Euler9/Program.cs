var result = Enumerable.Range(1, 1000)
    .SelectMany(a => Enumerable.Range(a + 1, 1000 - a - 1)
        .SelectMany(b => Enumerable.Range(b + 1, 1000 - b - 1)
            .Where(c => a + b + c == 1000 && a * a + b * b == c * c)
            .Select(c => a * b * c)))
    .First();

Console.WriteLine(result);