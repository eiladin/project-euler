HashSet<string> sets = [];
GenerateDice([0, 1, 2, 3, 4, 5, 6, 7, 8, 9], [], [], (die1, die2) => sets.Add(GetHashcode(die1, die2)));
Console.WriteLine(sets.Select(Parse).Count(x => IsValid(x.Item1, x.Item2)));

static (HashSet<int>, HashSet<int>) Sort(HashSet<int> die1, HashSet<int> die2)
{
    List<int> sorted1 = [.. die1.OrderBy(x => x)];
    List<int> sorted2 = [.. die2.OrderBy(x => x)];

    var sum1 = sorted1.Sum();
    var sum2 = sorted2.Sum();

    List<int> min = sorted1;
    List<int> max = sorted2;

    if (sum2 > sum1)
    {
        min = sorted2;
        max = sorted1;
    }
    else if (sum1 == sum2)
    {
        for (int i = 0; i < sorted2.Count; i++)
        {
            sum1 -= sorted1[i];
            sum2 -= sorted2[i];

            if (sum2 > sum1)
            {
                min = sorted2;
                max = sorted1;
                break;
            }
            else if (sum2 < sum1)
                break;
        }
    }

    return (new HashSet<int>(min), new HashSet<int>(max));
}

static (HashSet<int>, HashSet<int>) Parse(string dice)
{
    var split = dice.Split('.');
    var die1 = split[0].Split(',').Select(x => int.Parse(x)).ToHashSet();
    var die2 = split[1].Split(',').Select(x => int.Parse(x)).ToHashSet();
    return (die1, die2);
}

static string GetHashcode(HashSet<int> die1, HashSet<int> die2)
{
    var (min, max) = Sort(die1, die2);
    return $"{string.Join(",", min)}.{string.Join(",", max)}";
}



static void GenerateDice(List<int> choices, HashSet<int> partialOne, HashSet<int> partialTwo, Action<HashSet<int>, HashSet<int>> callback)
{
    if (partialOne.Count < (6 - choices.Count) || partialTwo.Count < (6 - choices.Count))
        return;

    if (partialOne.Count == 6 && partialTwo.Count == 6)
    {
        callback(partialOne, partialTwo);
        return;
    }

    if (choices.Count == 1)
    {
        HashSet<int> newPartialOne = partialOne;
        HashSet<int> newPartialTwo = partialTwo;
        if (partialOne.Count < 6)
            newPartialOne = new HashSet<int>(partialOne) { choices[0] };
        if (partialTwo.Count < 6)
            newPartialTwo = new HashSet<int>(partialTwo) { choices[0] };

        GenerateDice([], newPartialOne, newPartialTwo, callback);
        return;
    }
    List<int> newChoices = choices.Skip(1).ToList();
    if (choices[0] == 7 || choices[0] == 6)
        GenerateDice(newChoices, partialOne, partialTwo, callback);

    HashSet<int> leftPartialOne = partialOne;
    if (partialOne.Count < 6)
    {
        leftPartialOne = new HashSet<int>(partialOne) { choices[0] };
        GenerateDice(newChoices, leftPartialOne, partialTwo, callback);
    }

    HashSet<int> rightPartialTwo = partialTwo;
    if (partialTwo.Count < 6)
    {
        rightPartialTwo = new HashSet<int>(partialTwo) { choices[0] };
        GenerateDice(newChoices, partialOne, rightPartialTwo, callback);
    }

    if (partialOne.Count < 6 && partialTwo.Count < 6)
        GenerateDice(newChoices, leftPartialOne, rightPartialTwo, callback);
}

static bool IsValid(HashSet<int> die1, HashSet<int> die2) =>
    SetsMatch((0, 1), die1, die2) &&
    SetsMatch((0, 4), die1, die2) &&
    SetsMatchAny([(0, 6), (0, 9)], die1, die2) &&
    SetsMatchAny([(1, 6), (1, 9)], die1, die2) &&
    SetsMatch((2, 5), die1, die2) &&
    SetsMatchAny([(3, 6), (3, 9)], die1, die2) &&
    SetsMatchAny([(4, 6), (4, 9)], die1, die2) &&
    SetsMatch((8, 1), die1, die2);

static bool SetsMatch((int a, int b) pair, HashSet<int> one, HashSet<int> two) =>
    one.Contains(pair.a) && two.Contains(pair.b) || one.Contains(pair.b) && two.Contains(pair.a);

static bool SetsMatchAny(List<(int a, int b)> pairs, HashSet<int> one, HashSet<int> two) =>
    pairs.Any(pair => SetsMatch(pair, one, two));