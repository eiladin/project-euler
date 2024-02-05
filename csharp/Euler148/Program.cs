Console.WriteLine(Solve(1_000_000_000));

static long Solve(int num)
{
    if (num <= 7)
        return num * (num + 1) / 2;
    var ans = 7L * 8 / 2;
    var r = 7;
    while (r * 7 <= num)
    {
        ans *= 7 * 8 / 2;
        r *= 7;
    }
    int level = num / r;
    ans *= level * (level + 1) / 2;
    ans += (num / r + 1) * Solve(num % r);
    return ans;
}