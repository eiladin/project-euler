using System.Collections;

var allNumbers = Primes(1_000_000);
int max = 0;
int maxCount = 1;
List<int> primes = [];
for (int i = 0; i < allNumbers.Length; i++)
    if (allNumbers[i])
        primes.Add(i);

foreach (int prime in primes)
{
    int startingIndex = 0;
    while (primes[startingIndex] < prime / maxCount)
    {
        int n = prime;
        int j = startingIndex;
        int sum = 0;
        int count = 0;
        while (n > 0)
        {
            sum += primes[j];
            n -= primes[j];
            j++;
            count++;
        }
        if (sum == prime)
        {
            if (count > maxCount)
            {
                maxCount = count;
                max = prime;
            }
        }
        startingIndex++;
    }
}
Console.WriteLine(max);


static BitArray Primes(int n)
{
    BitArray a = new(n + 1, true);
    int limit = (int)Math.Sqrt(n);
    a[0] = false;
    a[1] = false;
    for (int i = 4; i <= n; i += 2)
        a[i] = false;
    for (int i = 3; i <= limit; i += 2)
    {
        if (a[i])
        {
            int step = i * 2;
            for (int j = i * i; j <= n; j += step)
                a[j] = false;
        }
    }
    return a;
}