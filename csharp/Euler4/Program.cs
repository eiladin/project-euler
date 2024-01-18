
var max = 0L;
for (int i = 999; i >= 100; i--)
{
    for (int j = 999; j >= 100; j--)
    {
        var p = i * j;
        if (IsPalindrome(p) && p > max)
            max = p;
    }
}

Console.WriteLine(max);

static bool IsPalindrome(long s) => s.ToString().Reverse().SequenceEqual(s.ToString());