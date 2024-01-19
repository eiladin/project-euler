int[,] ints = new int[101, 101];
for (var i = 0; i <= 100; i++)
{
    ints[i, 0] = 0;
    ints[0, i] = 1;
}

for (var i = 1; i <= 100; i++)
{
    ints[i, 1] = 1;
    for (var j = 2; j <= 100; j++)
    {
        int k = i - j;
        if (k >= 0)
            ints[i, j] = ints[i, j - 1] + ints[k, j];
        else
            ints[i, j] = ints[i, j - 1];
    }
}

Console.WriteLine(ints[100, 99]);