using Euler;

int T, N;

var ans = 0L;
for (T = 0; T <= 9; ++T)
{
    for (var M = 9; ; --M)
    {
        N = 0;
        DFS(10, M, 0);
        if (N != 0) break;
    }
}
Console.WriteLine(ans);

void DFS(int d, int m, long x)
{
    if (d < m) return;
    if (d == 0)
    {
        if (Primes.IsPrime(x))
        {
            ++N;
            ans += x;
        }
        return;
    }

    for (var i = 0; i < 10; ++i)
        if (d != 10 || i != 0)
            DFS(d - 1, m - (i == T ? 1 : 0), x * 10 + i);
}
