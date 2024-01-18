using Euler;

var allNumbers = Primes.Sieve(1_000_000);
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
