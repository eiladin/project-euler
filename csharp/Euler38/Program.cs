var max = 0;

for (var i = 1; i < 10000; i++)
{
    var concatProduct = string.Empty;

    for (int j = 1; j < 10; j++)
    {
        concatProduct += (i * j).ToString();
        if (concatProduct.Length > 9)
            break;

        if (IsPandigital(concatProduct) && int.Parse(concatProduct) > max)
            max = int.Parse(concatProduct);
    }
}
Console.Write(max);

static bool IsPandigital(string s) => s.ToCharArray().Distinct().Count() == 9 && !s.Contains('0');