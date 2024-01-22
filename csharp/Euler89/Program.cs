
var lines = File.ReadAllLines("input.txt");
var saved = lines.Select(l => l.Length - MinimizeRomanNumerals(l).Length).Sum();
Console.WriteLine(saved);

static string MinimizeRomanNumerals(string input) =>
    new string(input.ToCharArray())
        .Replace("DCCCC", "CM")
        .Replace("CCCC", "CD")
        .Replace("LXXXX", "XC")
        .Replace("XXXX", "XL")
        .Replace("VIIII", "IX")
        .Replace("IIII", "IV");
