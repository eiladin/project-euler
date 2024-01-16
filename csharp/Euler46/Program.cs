int result = 5;
int f = 1;
var primes = new HashSet<int>();

while (true)
{
    if (!primes.Any(p => result % p == 0))
        primes.Add(result);
    else
    {
        bool found = false;
        for (int i = 1; i < result; i++)
        {
            if (primes.Contains(result - 2 * i * i))
            {
                found = true;
                break;
            }
        }

        if (!found)
            break;
    }

    result += 3 - f;
    f = -f;
}

Console.WriteLine(result);
