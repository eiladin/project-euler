var ans = 1.0m;
var BOPS = (from i in Enumerable.Range(1, 10) select new decimal[] { Op(i) }).Cast<decimal[]>().ToArray();
for (int i = 2; i <= BOPS.Length; i++)
{
    var BOPSsubset = BOPS.Take(i).Cast<decimal[]>().ToArray();
    List<List<decimal>> ReversedPowers = [];
    for (var j = 1; j <= BOPSsubset.Length; j++)
    {
        List<decimal> rp = [];
        for (var k = 0; k < BOPSsubset.Length; k++)
            rp.Add((decimal)Math.Pow(j, k));
        rp.Reverse();
        ReversedPowers.Add(rp);
    }
    var MatrixProduct = getMatrixMultiplication(getMatrixInverse(ReversedPowers.Select(Enumerable.ToArray).ToArray()), BOPSsubset);
    Array.Reverse(MatrixProduct);
    decimal[] FlattenedMatrixProduct = MatrixProduct.SelectMany(n => n).ToArray();
    for (int j = 0; j < FlattenedMatrixProduct.Length; j++)
        ans += FlattenedMatrixProduct[j] * (decimal)Math.Pow(FlattenedMatrixProduct.Length + 1, j);
}
Console.WriteLine(Math.Round(ans));

static long Op(int n) =>
    1 - n + (long)Math.Pow(n, 2) - (long)Math.Pow(n, 3) + (long)Math.Pow(n, 4) - (long)Math.Pow(n, 5) + (long)Math.Pow(n, 6) - (long)Math.Pow(n, 7) + (long)Math.Pow(n, 8) - (long)Math.Pow(n, 9) + (long)Math.Pow(n, 10);

static decimal[][] getMatrixTranspose(decimal[][] m) =>
    Enumerable.Range(0, m.Length)
        .Select(r => Enumerable.Range(0, m[r].Length)
            .Select(c => c == r ? m[r][c] : m[c][r])
            .ToArray())
        .ToArray();

static decimal[][] getMatrixMinor(decimal[][] m, int i, int j) =>
    m.Where((row, rowIndex) => rowIndex != i)
        .Select(row => row.Where((_, colIndex) => colIndex != j).ToArray())
        .ToArray();

static decimal getMatrixDeterminant(decimal[][] m) =>
    m.Length == 2 ? m[0][0] * m[1][1] - m[0][1] * m[1][0] :
    Enumerable.Range(0, m.Length)
        .Select(c => (decimal)Math.Pow(-1, c) * m[0][c] * getMatrixDeterminant(getMatrixMinor(m, 0, c)))
        .Sum();

static decimal[][] getMatrixInverse(decimal[][] m)
{
    decimal determinant = getMatrixDeterminant(m);
    if (m.Length == 2)
        return [[m[1][1] / determinant, -1 * m[0][1] / determinant], [-1 * m[1][0] / determinant, m[0][0] / determinant]];

    var cofactors = Enumerable.Range(0, m.Length)
        .Select(r => Enumerable.Range(0, m.Length)
            .Select(c => (decimal)Math.Pow(-1, r + c) * getMatrixDeterminant(getMatrixMinor(m, r, c)))
            .ToArray())
        .ToArray();

    var C = getMatrixTranspose(cofactors)
                .Select(row => row.Select(value => value / determinant).ToArray()).ToArray();

    return C;
}

static decimal[][] getMatrixMultiplication(decimal[][] a, decimal[][] b)
{
    decimal[][] c = new decimal[a[0].Length][];
    for (var i = 0; i < a[0].Length; i++)
    {
        c[i] = new decimal[b[0].Length];
        for (var j = 0; j < b[1].Length; j++)
        {
            c[i][j] = 0;
            for (int k = 0; k < a[1].Length; k++)
                c[i][j] += a[i][k] * b[k][j];
        }
    }
    return c;
}
