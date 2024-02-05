var result = Enumerable.Range(1, 43).Select(r => Enumerable.Range(1, 47).Select(c => count(r, c)).Sum()).Sum();

Console.WriteLine(result);


static int count(int r, int c)
{
    int ret = r * (r + 1) / 2 * c * (c + 1) / 2;
    int[] start = new int[r + c - 1];
    int[] end = new int[r + c - 1];
    for (int i = r - 1; i > 0; --i)
    {
        start[r - 1 - i] = i;
        end[r - 1 - i] = i + 2 * Math.Min(r - i, c);
    }
    for (int i = 0; i < c; ++i)
    {
        start[r - 1 + i] = i;
        end[r - 1 + i] = i + 2 * Math.Min(c - i, r);
    }
    for (int i = 0; i < start.Length; ++i)
    {
        for (int j = i + 1; j < start.Length; ++j)
        {
            int s = Math.Max(start[i], start[j]);
            int e = Math.Min(end[i], end[j]);
            if (s < e)
            {
                ret += (e - s) * (e - s + 1) / 2;
            }
        }
    }
    return ret;
}