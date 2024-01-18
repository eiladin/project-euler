var count = Enumerable.Range(1, 10000).Count(x => CanonicalForm(x).Length % 2 != 0);
Console.WriteLine(count);

static bool IsSquare(int num) => Math.Sqrt(num) % 1 == 0;

static int[] CanonicalForm(int num)
{
    if (IsSquare(num))
        return [];
    var m0 = 0;
    var d0 = 1;
    var a0 = (int)Math.Floor(Math.Sqrt(num));
    var temp = new List<int>();
    while (true)
    {
        var mn = d0 * a0 - m0;
        var dn = (num - mn * mn) / d0;
        var an = (int)Math.Floor((Math.Sqrt(num) + mn) / dn);
        temp.Add(an);
        if (an == 2 * Math.Floor(Math.Sqrt(num)))
            break;
        m0 = mn;
        d0 = dn;
        a0 = an;
    }
    return [.. temp];
}
