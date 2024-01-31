using Euler;

var top = 10000;
var limit = 100000000;

long[,] tbl = new long[top + 1, top + 1];
tbl[1, 1] = 1;
var palindromes = new HashSet<long>();

for (long i = 2; i <= top; i++)
    for (long j = 1; j <= i; j++)
    {
        var sum = tbl[i - 1, j] + i * i;
        tbl[i, j] = sum;
        if (j < i && sum < limit && Numerics.IsPalindrome(sum))
            palindromes.Add(sum);
    }

Console.WriteLine(palindromes.Sum());
