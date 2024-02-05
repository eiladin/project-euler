var (x0, y0) = (0.0, 10.1);
var (x1, y1) = (1.4, -9.6);
double nextX;
double nextY;
var count = 0;
do
{
    (nextX, nextY) = NextPoint(x0, y0, x1, y1);
    (x0, y0, x1, y1) = (x1, y1, nextX, nextY);
    count++;
}
while (Math.Abs(nextX) > 0.01 || nextY <= 0);

Console.WriteLine(count);

static (double x, double y) NextPoint(double x0, double y0, double x1, double y1)
{
    var i = (y1 - y0) / (x1 - x0);
    var n = y1 / (4 * x1);
    var r = (-i + 2 * n + i * n * n) / (1 + 2 * i * n - n * n);
    var m = y1 - r * x1;
    var nextX = -2 * r * m / (4 + r * r) - x1;
    var nextY = r * nextX + m;
    return (nextX, nextY);
}