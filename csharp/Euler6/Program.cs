static long SumOfSquares(int n)
{
    long sum = 0;
    for (int i = 1; i <= n; i++)
        sum += i * i;
    return sum;
}

static long SquareOfSum(int n)
{
    long sum = 0;
    for (int i = 1; i <= n; i++)
        sum += i;
    return sum * sum;
}

Console.WriteLine(SquareOfSum(100) - SumOfSquares(100));
