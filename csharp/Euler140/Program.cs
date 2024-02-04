var result = EquationSolver(15, 0, 1)
        .Concat(EquationSolver(15, 0, -1))
        .Concat(EquationSolver(15, -3, -2))
        .Concat(EquationSolver(15, -3, 2))
        .Concat(EquationSolver(15, -4, -5))
        .Concat(EquationSolver(15, -4, 5))
        .Concat(EquationSolver(15, 2, -7))
        .Concat(EquationSolver(15, 2, -7))
        .Distinct()
        .OrderBy(n => n)
        .Take(30)
        .Sum();

Console.WriteLine(result);


static List<long> EquationSolver(int x, long startx, long starty)
{
    var x1 = startx;
    var y1 = starty;
    var solutions = new List<long>();
    while (solutions.Count != x)
    {
        var xn = -9 * x1 - 4 * y1 - 14;
        var yn = -20 * x1 - 9 * y1 - 28;
        if (xn > 0)
            solutions.Add(xn);
        x1 = xn;
        y1 = yn;
    }
    return solutions;
}

