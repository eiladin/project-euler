using Euler;

double maxRatio = 0;
int maxN = 0;

for (var i = 2; i <= 1000000; i++)
{
    var totient = Numerics.EulerTotient(i);
    var ratio = (double)i / totient;
    if (ratio > maxRatio)
    {
        maxRatio = ratio;
        maxN = i;
    }
}

Console.WriteLine(maxN);
