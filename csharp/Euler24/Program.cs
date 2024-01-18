using Euler;

List<long> digits = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

var perms = Collections.GetPermutations(digits).ToList();
perms.Sort();
Console.WriteLine(perms.Skip(999999).First());