
using Euler;

bool found = false;
int n = 2;
while (!found)
{
    for (int i = n - 1; i > 0; i--)
    {
        long number1 = Numerics.GetPentagonal(n);
        long number2 = Numerics.GetPentagonal(n - i);
        if (Numerics.IsPentagonal(number1 + number2) && Numerics.IsPentagonal(number1 - number2))
        {
            Console.WriteLine(Math.Abs(GetPentagonNumber(n - i) - GetPentagonNumber(n)));
            return;
        }
    }
    n++;
}



static int GetPentagonNumber(int num) => num * (3 * num - 1) / 2;
