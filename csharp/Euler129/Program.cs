using Euler;

var limit = 1_000_000;
int result;
for (var i = limit; ; i++)
{
    if (Numerics.Repunit(i) > limit)
    {
        result = i;
        break;
    }
}
Console.WriteLine(result);
