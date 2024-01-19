using Euler;

var primes = Primes.Get(80);
var max = 80;
var target = 0;
var sum = 0;
var ints = new int[max + 1, max + 1];

for (var i = 0; i < max; i++)
{
    ints[i, 0] = 0;
    ints[0, i] = 1;
}

int n = 2;
while (sum < 5000)
{
    if (n % 2 == 0)
        ints[n, 1] = 1;
    else
        ints[n, 1] = 0;
    for (var j = 2; j <= primes.Count; j++)
    {
        var k = n - primes[j - 1];
        if (k >= 0)
            ints[n, j] = ints[n, j - 1] + ints[k, j];
        else
            ints[n, j] = ints[n, j - 1];
        if (ints[n, j] > 5000)
        {
            target = n;
            sum = ints[n, j];
            break;
        }
    }
    n++;
}

Console.WriteLine(target);
