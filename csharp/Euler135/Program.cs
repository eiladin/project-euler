var limit = 1_000_000;
var solutions = new int[limit];
for (var m = 1; m < limit * 2; m++)
{
    for (var k = m / 5 + 1; k < (m + 1) / 2; k++)
    {
        var temp = (m - k) * (k * 5 - m);
        if (temp >= limit)
            break;
        solutions[temp]++;
    }
}

Console.WriteLine(solutions.Count(x => x == 10));