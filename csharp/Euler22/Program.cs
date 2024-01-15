var input = File.ReadAllText("input.txt");

var score = input.Split(",")
                 .Select(x => x.Trim('"'))
                 .OrderBy(x => x)
                 .Select((name, index) => (index + 1) * name.Sum(x => x - 'A' + 1))
                 .Sum();

Console.WriteLine(score);
