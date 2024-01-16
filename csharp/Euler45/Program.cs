long h = 144L, p = 166L;
long hex, penta = 0L;
do
{
    hex = Hexagonal(h++);
    while (penta < hex)
        penta = Pentagonal(p++);
} while (hex != penta);

Console.WriteLine(hex);

static long Hexagonal(long n) => n * (2 * n - 1);

static long Pentagonal(long n) => n * (3 * n - 1) / 2;