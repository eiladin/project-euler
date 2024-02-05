var table = new int[2000 * 2000];

for (int k = 1; k <= 55; ++k)
    table[k - 1] = (int)((100003L - 200003L * k + 300007L * k * k * k) % 1000000 - 500000);
for (int i = 55; i < 2000 * 2000; ++i)
    table[i] = (table[i - 24] + table[i - 55] + 1000000) % 1000000 - 500000;


var result = long.MinValue;
var max = new long[2000];

for (int i = 0; i < 2000; ++i)
{
    max[0] = table[i * 2000];
    result = Math.Max(result, max[0]);
    for (int j = 1; j < 2000; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[i * 2000 + j];
        result = Math.Max(result, max[j]);
    }
}

for (int i = 0; i < 2000; ++i)
{
    max[0] = table[i];
    result = Math.Max(result, max[0]);
    for (int j = 1; j < 2000; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[j * 2000 + i];
        result = Math.Max(result, max[j]);
    }
}

for (int i = 0; i < 2000; ++i)
{
    max[0] = table[i * 2000];
    result = Math.Max(result, max[0]);
    for (int j = 1; j < 2000 - i; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[(i + j) * 2000 + j];
        result = Math.Max(result, max[j]);
    }

    max[0] = table[i];
    result = Math.Max(result, max[0]);
    for (int j = 1; j < 2000 - i; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[j * 2000 + (i + j)];
        result = Math.Max(result, max[j]);
    }
}

for (int i = 0; i < 2000; ++i)
{
    max[0] = table[(i + 1) * 2000 - 1];
    result = Math.Max(result, max[0]);
    for (int j = 1; j < 2000 - i; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[(i + j) * 2000 + (1999 - j)];
        result = Math.Max(result, max[j]);
    }

    max[0] = table[i];
    result = Math.Max(result, max[0]);
    for (int j = 1; j <= i; ++j)
    {
        max[j] = Math.Max(max[j - 1], 0) + table[j * 2000 + i - j];
        result = Math.Max(result, max[j]);
    }
}

Console.WriteLine(result);
