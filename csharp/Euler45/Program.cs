using Euler;

long h = 144L, p = 166L;
long hex, penta = 0L;
do
{
    hex = Numerics.GetHexagonal(h++);
    while (penta < hex)
        penta = Numerics.GetPentagonal(p++);
} while (hex != penta);

Console.WriteLine(hex);