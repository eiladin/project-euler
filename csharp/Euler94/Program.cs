var sum = 0;
var s = 5;
var t = -1;
var prev = 1;
while (s < 333_333_334)
{
    sum += 3 * s - t;
    var p = s;
    s = 4 * s - prev + 2 * t;
    t *= -1;
    prev = p;
}

Console.WriteLine(sum);