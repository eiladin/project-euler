using Euler;

List<int> digits = [1, 2, 3, 4, 5, 6, 7, 8, 9];
var permutations = Collections.GetPermutations(digits).Where(p => p.Last() % 2 != 0 || p.Count > 1 || p.Last() != 2);
var solutions = permutations.SelectMany(p => Search(p, []).ToList());
Console.WriteLine(solutions.Count());

static IEnumerable<List<int>> Search(List<int> digits, List<int> merged, int firstPos = 0)
{
    if (firstPos == digits.Count)
        yield return new List<int>(merged);

    int current = 0;
    while (firstPos < digits.Count)
    {
        current *= 10;
        current += digits[firstPos++];

        if (merged.Count > 0 && current < merged.Last())
            continue;

        if (Primes.IsPrime(current))
        {
            merged.Add(current);
            foreach (var x in Search(digits, merged, firstPos))
                yield return x;
            merged.RemoveAt(merged.Count - 1);
        }
    }
}