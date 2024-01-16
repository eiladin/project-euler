var result = Calc(0, 200);
Console.WriteLine(result);

static int[] Values() => [200, 100, 50, 20, 10, 5, 2, 1];

static int Calc(int index, int r)
{
    int count = 0;
    if (r == 0 || index == Values().Length - 1)
    {
        count++;
        return count;
    }
    for (int i = 0; i <= r / Values()[index]; i++)
        count += Calc(index + 1, r - i * Values()[index]);
    return count;
}