var target = 2_000_000;
var bestDist = 2_000_000;
var result = 0;

for (var i = 1; i < 2000; i++)
{
    var n = (int)Math.Floor(Math.Sqrt(1 + 16 * target / (i * i + i) - 1.0) / 2.0);
    for (var j = 0; j < 2; j++)
    {
        var sum = n * (i + 1) * i * (n + 1) / 4;
        var dist = Math.Abs(sum - target);
        if (dist < bestDist)
        {
            bestDist = dist;
            result = n * i;
        }
        n++;
    }
}
Console.WriteLine(result);
