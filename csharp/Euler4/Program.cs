

static bool IsPalindrome(long s)
{
    var str = s.ToString();
    var len = str.Length;
    for (int i = 0; i < len / 2; i++)
        if (str[i] != str[len - i - 1])
            return false;
    return true;
}

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