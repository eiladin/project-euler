var result = Math.Round(Evaluate([1, 0, 0, 0, 0]), 6);
Console.WriteLine(result);

static double Evaluate(List<int> sheets)
{
    int numSheets = sheets.Sum();

    var single = 0d;
    if (numSheets == 1)
    {
        if (sheets.Last() == 1)
            return 0;

        if (sheets.First() == 0)
            single = 1;
    }

    for (var i = 0; i < sheets.Count; i++)
    {
        if (sheets[i] == 0)
            continue;

        var next = new List<int>(sheets);
        next[i]--;
        for (var j = i + 1; j < next.Count; j++)
            next[j]++;

        var probability = sheets[i] / (double)numSheets;
        single += Evaluate(next) * probability;
    }

    return single;
}