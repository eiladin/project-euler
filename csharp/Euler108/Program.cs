
int target = 1000;
var res = GetSolutions().TakeWhile(n => (n + 1) / 2 <= target).Count();
Console.WriteLine(res);

static IEnumerable<int> GetSolutions()
{
    int next = 0;
    while (true)
    {
        var n = next++;
        var count = 1;
        var end = (int)Math.Sqrt(n);
        for (var x = 2; x <= end; x++)
        {
            if (n % x == 0)
            {
                var j = 0;
                while (true)
                {
                    n /= x;
                    j++;
                    if (n % x != 0)
                        break;
                }
                count *= 2 * j + 1;
                end = (int)Math.Sqrt(n);
            }
        }
        if (n != 1)
            count *= 3;
        yield return count;
    }

}