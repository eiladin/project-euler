var solutions = new List<long>();

var current = 17L;
solutions.Add(current);
var sum = current;

var previous = 1L;
for (int i = 2; i <= 12; i++)
{
    var next = current * 18 - previous;
    previous = current;
    current = next;
    sum += current;
    solutions.Add(sum);
}

var smallest = 12L;
var index = smallest - 1;
if (index >= solutions.Count)
    return;

Console.WriteLine(solutions[(int)index]);
