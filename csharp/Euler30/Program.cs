var total = Enumerable.Range(2, 999999)
    .Where(n => n == n.ToString().Select(c => (int)Math.Pow(int.Parse(c.ToString()), 5)).Sum())
    .Sum();

Console.WriteLine(total);