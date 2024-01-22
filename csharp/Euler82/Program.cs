string[] lines = File.ReadAllLines("input.txt");
var length = lines.Length;
var matrix = new int[length, length];
var scores = new int[length, length];

for (var i = 0; i < length; i++)
{
    var line = lines[i].Split([',']);
    for (var j = 0; j < length; j++)
        matrix[i, j] = int.Parse(line[j]);
}

for (var i = 0; i < length; i++)
    scores[i, 0] = matrix[i, 0];

for (var j = 1; j < length; j++)
{
    for (var i = 0; i < length; i++)
        scores[i, j] = scores[i, j - 1] + matrix[i, j];
    for (var i = 1; i < length; i++)
        scores[i, j] = Math.Min(scores[i, j], scores[i - 1, j] + matrix[i, j]);
    for (var i = length - 2; i >= 0; i--)
        scores[i, j] = Math.Min(scores[i, j], scores[i + 1, j] + matrix[i, j]);
}

var min = int.MaxValue;
for (var i = 0; i < length; i++)
    min = Math.Min(scores[i, length - 1], min);

Console.WriteLine(min);