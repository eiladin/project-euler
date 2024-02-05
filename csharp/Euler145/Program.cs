var count = Enumerable.Range(2, 8).Sum(Reversable);

Console.WriteLine(count);

static int Reversable(int num) => (num % 4) switch
{
    0 => 20 * (int)Math.Pow(30, num / 2 - 1),
    2 => 20 * (int)Math.Pow(30, num / 2 - 1),
    3 => 100 * (int)Math.Pow(500, (num - 3) / 4),
    _ => 0
};
