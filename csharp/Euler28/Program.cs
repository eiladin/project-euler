var sum = 1;
var last = 1;
var delta = 2;

for (var i = 0; i < 500; i++)
{
    for (var j = 0; j < 4; j++)
    {
        last += delta;
        sum += last;
    }
    delta += 2;
}

Console.WriteLine(sum);
