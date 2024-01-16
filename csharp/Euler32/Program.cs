var result = 0;
List<int> seen = [];
result += GetPandigital(99, 999, seen);
result += GetPandigital(9, 9999, seen);
Console.WriteLine(result);

static int GetPandigital(int aMax, int bMax, List<int> seen)
{
    var result = 0;
    for (var a = 1; a <= aMax; a++)
        for (var b = 100; b <= bMax; b++)
        {
            var c = a * b;
            if (c.ToString().Length > 5)
                break;
            var s = a.ToString() + b.ToString() + c.ToString();
            var digits = s.ToCharArray().OrderBy(x => x).ToArray();
            if (new string(digits) == "123456789")
                if (!seen.Contains(c))
                {
                    result += c;
                    seen.Add(c);
                }
        }
    return result;
}
