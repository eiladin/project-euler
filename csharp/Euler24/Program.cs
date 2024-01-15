List<long> digits = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

var perms = GetPermutations(digits).ToList();
perms.Sort();
Console.WriteLine(perms.Skip(999999).First());

static IEnumerable<long> GetPermutations(List<long> digits)
{
    if (digits.Count == 1)
    {
        yield return digits[0];
        yield break;
    }
    foreach (long digit in digits)
    {
        List<long> subDigits = new(digits);
        subDigits.Remove(digit);
        foreach (var subPermutation in GetPermutations(subDigits))
            yield return digit * (long)Math.Pow(10, subDigits.Count) + subPermutation;
    }
}