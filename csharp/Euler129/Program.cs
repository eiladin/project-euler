var limit = 1_000_000;
int result;
for (var i = limit; ; i++)
{
    if (LeastDivisibleRepunit(i) > limit)
    {
        result = i;
        break;
    }
}
Console.WriteLine(result);

static int LeastDivisibleRepunit(int n)
{
    if (n % 2 == 0 || n % 5 == 0)
        return 0;

    var k = 1;
    var s = 1;
    var p = 1;
    while (s % n != 0)
    {
        k++;
        p = p * 10 % n;
        s = (s + p) % n;
    }
    return k;
}