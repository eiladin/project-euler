var sum = 0;
var a = 0;
while (sum < 1_000_000)
    sum += Count(++a);
Console.WriteLine(a);

static int Combinations(int a, int b_c) =>
    2 * a < b_c ? 0 :
    a >= b_c ? b_c / 2 :
    a - (b_c - 1) / 2;

static int Count(int a)
{
    var sum = 0;
    for (int b_c = 1; b_c <= 2 * a; b_c++)
        if (Math.Sqrt(a * a + b_c * b_c) % 1 == 0)
            sum += Combinations(a, b_c);
    return sum;
}