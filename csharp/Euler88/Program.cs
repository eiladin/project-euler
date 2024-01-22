using Euler;

var limit = 12000;
var minK = new int[limit + 1];

for (var i = 0; i < minK.Length; i++)
    minK[i] = int.MaxValue;


var remaining = limit - 1;
for (var n = 4; remaining > 0; n++)
    remaining -= GetMinK(n, n, n);

Console.WriteLine(minK.Where(v => v != int.MaxValue).Distinct().Sum());


bool Valid(int n, int k)
{
    if (k >= minK.Length)
        return false;

    if (minK[k] > n)
    {
        minK[k] = n;
        return true;
    }

    return false;
}

int GetMinK(int n, int product, int sum, int depth = 1, int minFactor = 2)
{
    if (product == 1)
        return Valid(n, depth + sum - 1) ? 1 : 0;

    var result = 0;
    if (depth > 1)
    {
        if (product == sum)
            return Valid(n, depth) ? 1 : 0;

        if (Valid(n, depth + sum - product))
            result++;
    }

    var other = 0;
    for (var i = minFactor; i * i <= product; i++)
        if (product % i == 0)
            other = i;

    var factors = Numerics.GetFactors(product).Where(f => f >= minFactor);
    foreach (var factor in factors)
        result += GetMinK(n, product / factor, sum - factor, depth + 1, factor);

    return result;
}