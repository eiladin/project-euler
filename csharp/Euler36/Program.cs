int count = 0;

for (var i = 1; i < 1_000_000; i++)
    if (IsPalindrome(i.ToString()) && IsPalindrome(ToBinary(i)))
        count += i;

Console.WriteLine(count);

static string ToBinary(int n) => Convert.ToString(n, 2);

static bool IsPalindrome(string s) => s.Reverse().SequenceEqual(s);