
var input = File.ReadAllText("input.txt").Replace("\n", "");
long max = 0;
for (var i = 0; i < 988; i++)
{
    var product = 1L;
    for (var j = 0; j < 13; j++)
        product *= int.Parse(input[i + j].ToString());
    max = Math.Max(max, product);
}
Console.WriteLine(max);