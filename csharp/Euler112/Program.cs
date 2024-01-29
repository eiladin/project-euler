using Euler;
var bouncyCount = 0;
long num;

for (num = 100; num < 10_000_000; num++)
{
    if (IsBouncy(num))
        bouncyCount++;

    if (bouncyCount * 100 == num * 99)
        break;
}
Console.WriteLine(num);

static bool IsBouncy(long num)
{
    var digits = Numerics.GetDigits(num).ToArray();
    var increasing = true;
    var decreasing = true;
    for (var i = 1; i < digits.Length; i++)
    {
        if (decreasing && digits[i] > digits[i - 1])
            decreasing = false;
        else if (increasing && digits[i] < digits[i - 1])
            increasing = false;
        if (!increasing && !decreasing)
            return true;
    }

    return false;
}