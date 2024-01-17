using System.Numerics;

var total = 0;
for (var i = 10; i < 10_000; i++)
    total += IsLychrelNumber(i) ? 1 : 0;

Console.WriteLine(total);

static bool IsLychrelNumber(int number)
{
    var num = number.ToString();
    for (var i = 0; i < 50; i++)
    {
        num = (BigInteger.Parse(num) + BigInteger.Parse(new string(num.Reverse().ToArray()))).ToString();
        if (IsPalindrome(num))
            return false;
    }
    return true;
}

static bool IsPalindrome(string s) => s.Reverse().SequenceEqual(s.ToCharArray());