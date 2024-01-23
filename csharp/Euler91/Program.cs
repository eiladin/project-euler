var limit = 50;

var triangles = new List<(int, int, int, int)>();

for (var x1 = 0; x1 <= limit; x1++)
    for (var y1 = 0; y1 <= limit; y1++)
        for (var x0 = 0; x0 <= limit; x0++)
            for (var y0 = 0; y0 <= limit; y0++)
            {
                if (IsValidRightTriangle(x0, y0, x1, y1) && !triangles.Contains((x0, y0, x1, y1)) && !triangles.Contains((x1, y1, x0, y0)))
                    triangles.Add((x0, y0, x1, y1));
            }

Console.WriteLine(triangles.Count);

static bool IsValidRightTriangle(int x0, int y0, int x1, int y1)
{
    if ((x0 == 0 && y0 == 0) || (x1 == 0 && y1 == 0))
        return false;

    if ((x0 == 0 && x1 == 0) || (y0 == 0 && y1 == 0))
        return false;

    if (x0 == x1 && y0 == y1)
        return false;

    var a = x0 * x0 + y0 * y0;
    var b = x1 * x1 + y1 * y1;
    var c = (x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0);

    return a + b == c || a + c == b || b + c == a;
}