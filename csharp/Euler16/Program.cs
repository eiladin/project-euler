var limit = 1000;
var ints = limit / 29;
int[] number = new int[ints + 1];
number[0] = 2;
for (int i = 2; i <= limit; i++)
    doubleNumber(number);
Console.WriteLine(number.Select(SumOfDigits).Sum());

static void doubleNumber(int[] n)
{
    var carry = 0;
    for (int i = 0; i < n.Length; i++)
    {
        n[i] <<= 1;
        n[i] += carry;
        if (n[i] >= 1000000000)
        {
            carry = 1;
            n[i] -= 1000000000;
        }
        else
            carry = 0;
    }
}

static int SumOfDigits(int number)
{
    var sum = 0;
    while (number > 0)
    {
        sum += number % 10;
        number /= 10;
    }
    return sum;
}