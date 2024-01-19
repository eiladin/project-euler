using Euler;

var count = 0;

for (long num = 2; num < 1_000_000; num++)
{
    var chain = new List<long> { num };
    var next = num;
    while (true)
    {
        next = GetNext(next);
        if (chain.Contains(next))
            break;
        chain.Add(next);
    }
    if (chain.Count == 60)
        count++;
}

Console.WriteLine(count);

static long GetNext(long num) => Numerics.GetDigits(num).Select(d => Numerics.Factorial(d)).Sum();