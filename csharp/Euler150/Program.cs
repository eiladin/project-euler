var s = new long[1000, 1000];
var t = 0L;
for (var i = 0; i < 1000; ++i)
{
    for (var j = 0; j <= i; ++j)
    {
        t = (615949 * t + 797807) % (1 << 20);
        s[i, j] = t - (1 << 19);
    }
}
long ans = long.MaxValue;
var prev = new long[1001, 1001];
var cur = new long[1001, 1];
for (var i = 999; i >= 0; --i)
{
    var next = new long[i + 1, 1001 - i];
    for (int j = 0; j <= i; ++j)
    {
        next[j, 1] = s[i, j];
        ans = Math.Min(ans, next[j, 1]);
        for (int k = 2; k < 1001 - i; ++k)
        {
            next[j, k] = s[i, j] + cur[j, k - 1] + cur[j + 1, k - 1] - prev[j + 1, k - 2];
            ans = Math.Min(ans, next[j, k]);
        }
    }
    prev = cur;
    cur = next;
}
Console.WriteLine(ans);