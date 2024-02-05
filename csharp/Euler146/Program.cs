using System.Numerics;
using Euler;

BigInteger LimitA = 1373653;
BigInteger LimitB = 9080191;
BigInteger LimitC = 4759123141L;
BigInteger LimitD = 2152302898747L;
BigInteger LimitE = 3474749660383L;
int[] Add = [1, 3, 7, 9, 13, 27];
int[] NotAdd = [19, 21];

var limit = 150000000;

var result = 0L;
var primes = Primes.Get(5000).ToList();
(long, bool[])[] mods = new (long, bool[])[primes.Count];

for (int i = 0; i < primes.Count; i++)
    mods[i] = (primes[i], Mods(primes[i]));

for (long i = 10; i < limit; i += 10)
{
    bool ok = true;
    for (int j = 0; ok && j < primes.Count && i * i > primes[j]; j++)
        ok = mods[j].Item2[i % mods[j].Item1];

    for (int j = 0; ok && j < Add.Length; j++)
        ok = IsProbablePrime(i * i + Add[j]);

    for (int j = 0; ok && j < NotAdd.Length; j++)
        ok = !IsProbablePrime(i * i + NotAdd[j]);

    if (ok)
        result += i;
}

Console.WriteLine(result);

bool[] Mods(long m)
{
    bool[] res = new bool[m];
    for (int i = 0; i < m; i++)
    {
        res[i] = true;
        for (int j = 0; j < Add.Length; j++)
        {
            if ((i * i + Add[j]) % m == 0)
            {
                res[i] = false;
                break;
            }
        }
    }

    return res;
}

bool IsProbablePrime(long n)
{
    if (n < LimitA) return IsProbablePrime2(n, [2, 3]);
    if (n < LimitB) return IsProbablePrime2(n, [31, 73]);
    if (n < LimitC) return IsProbablePrime2(n, [2, 7, 61]);
    if (n < LimitD) return IsProbablePrime2(n, [2, 3, 5, 7, 11]);
    if (n < LimitE) return IsProbablePrime2(n, [2, 3, 5, 7, 11, 13]);
    return IsProbablePrime2(n, [2, 3, 5, 7, 11, 13, 17]);
}

bool IsProbablePrime2(long n, int[] ar)
{
    for (int i = 0; i < ar.Length; i++)
        if (Witness(ar[i], n))
            return false;
    return true;
}

bool Witness(int a, BigInteger n)
{
    var t = 0;
    var u = n - 1;
    while ((u & 1) == 0)
    {
        t++;
        u >>= 1;
    }

    var xi1 = BigInteger.ModPow(a, u, n);
    var xi2 = BigInteger.Zero;

    for (int i = 0; i < t; i++)
    {
        xi2 = xi1 * xi1 % n;
        if ((xi2 == 1) && (xi1 != 1) && (xi1 != (n - 1)))
            return true;
        xi1 = xi2;
    }
    if (xi1 != 1)
        return true;
    return false;
}