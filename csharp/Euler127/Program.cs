using Euler;

int limit = 120000;
var radicals = new long[limit];
var sums = new long[limit];
var sum = 0L;

for (var i = 1; i < limit; i++)
    radicals[i] = Numerics.Radical(i);

for (var a = 1; a < limit; a++)
{
    for (var b = a + 1; b < limit - a; b++)
    {
        var c = a + b;
        if (c >= limit)
            break;

        if (radicals[a] * radicals[b] * radicals[c] < c && Numerics.Gcd(a, b) == 1)
            sum += c;
    }
}

Console.WriteLine(sum);
