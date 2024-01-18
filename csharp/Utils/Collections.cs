namespace Euler;

public class Collections
{
    public static IEnumerable<long> GetPermutations(List<long> digits)
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

    public static List<string> GetPermutations(string s)
    {
        List<string> permutations = [];
        if (s.Length == 1)
        {
            permutations.Add(s);
            return permutations;
        }
        foreach (string subPermutation in GetPermutations(s[1..]))
            for (int i = 0; i <= subPermutation.Length; i++)
                permutations.Add(subPermutation[..i] + s[0] + subPermutation[i..]);
        return permutations;
    }
}