
bool found = false;
int n = 2;
while (!found)
{
    for (int i = n - 1; i > 0; i--)
    {
        int number1 = GetPentagonNumber(n);
        int number2 = GetPentagonNumber(n - i);
        if (IsPentagonal(number1 + number2) && IsPentagonal(number1 - number2))
        {
            Console.WriteLine(Math.Abs(GetPentagonNumber(n - i) - GetPentagonNumber(n)));
            return;
        }
    }
    n++;
}

static bool IsPentagonal(int num)
{
    var result = (Math.Sqrt(24 * num + 1) + 1) / 6;
    return Math.Floor(result) == result;
}

static int GetPentagonNumber(int num) => num * (3 * num - 1) / 2;
