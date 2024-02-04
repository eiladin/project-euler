using Euler;

var limit = 1000;
var result = 0;
for (var x = 1; x < limit && result == 0; x++)
{
    var x2 = x * x;
    for (var y = x + 1; y < limit && result == 0; y++)
    {
        var y2 = y * y;
        if (!Numerics.IsSquare(y2 - x2))
            continue;
        var offset = 2 - x % 2;
        for (var z = y + offset; z <= (int)Math.Sqrt(y2 + x2) + 1 && result == 0; z += 2)
        {
            var z2 = z * z;
            if (Numerics.IsSquare(z2 - x2) && Numerics.IsSquare(z2 - y2) && Numerics.IsSquare(y2 - x2))
            {
                result = (x2 + y2 + z2) / 2;
                break;
            }
        }
    }
}

Console.WriteLine(result);
