using Euler;

var last = 1;
var delta = 2;
var count = 1;
var primeCount = 0;
var result = 1;

for (var i = 1; i < 20000; i++)
{
    for (var j = 0; j < 4; j++)
    {
        last += delta;
        if (Primes.IsPrime(last))
            primeCount++;
    }
    count += 4;
    if ((double)primeCount / count < 0.1)
    {
        result += delta;
        break;
    }
    delta += 2;
}

Console.WriteLine(result);
