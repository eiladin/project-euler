using Euler;

var maxLength = 0;
var result = new int[4];

Func<double, double, double>[] operations =
[
    (a, b) => a + b,
    (a, b) => a - b,
    (a, b) => a * b,
    (a, b) => (double)a / b
];

for (var a = 1; a <= 6; a++)
    for (var b = a + 1; b <= 7; b++)
        for (var c = b + 1; c <= 8; c++)
            for (var d = c + 1; d <= 9; d++)
            {
                var sequences = GetSequences([a, b, c, d]);

                foreach (var sequence in sequences)
                {
                    var length = GetLongestConsecutiveLength(sequence);
                    if (length > maxLength)
                    {
                        maxLength = length;
                        result = sequence;
                    }
                }
            }

Console.WriteLine(string.Join("", result));

List<int[]> GetSequences(int[] digits)
{
    var sequences = new List<int[]>();

    for (int i = 0; i < 4; i++)
        for (int j = 0; j < 4; j++)
            for (int k = 0; k < 4; k++)
                if (i != j && i != k && j != k)
                    sequences.Add([digits[i], digits[j], digits[k], digits[6 - i - j - k]]);

    return sequences;
}

int GetLongestConsecutiveLength(int[] digits)
{
    var results = new HashSet<double>();

    foreach (var perm in Collections.GetPermutations(digits))
        foreach (var op1 in operations)
            foreach (var op2 in operations)
                foreach (var op3 in operations)
                {
                    var result = op3(op2(op1(perm[0], perm[1]), perm[2]), perm[3]);
                    if (result > 0 && Math.Abs(result - Math.Round(result)) < 0.0001)
                        results.Add(result);

                    result = op3(op1(perm[0], perm[1]), op2(perm[2], perm[3]));
                    if (result > 0 && Math.Abs(result - Math.Round(result)) < 0.0001)
                        results.Add(result);
                }

    var length = 0;
    while (results.Contains(length + 1))
        length++;

    return length;
}