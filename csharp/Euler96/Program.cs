
var input = File.ReadAllText("input.txt");
var sum = 0;
input.Split("Grid", StringSplitOptions.RemoveEmptyEntries).Select(p => new SudokuSolver(p)).ToList().ForEach(p =>
{
    p.Solve();
    sum += p.Value;
});
Console.WriteLine(sum);

internal class SudokuSolver
{
    private readonly int[,] board;
    public int[,] Board => board;
    public int Value => board[0, 0] * 100 + board[0, 1] * 10 + board[0, 2];

    public SudokuSolver(string input)
    {
        board = new int[9, 9];
        input.Split("\n", StringSplitOptions.RemoveEmptyEntries).Skip(1).Select((row, i) => (row, i)).ToList().ForEach(r => r.row.Select((c, j) => (c, j)).ToList().ForEach(c => board[r.i, c.j] = int.Parse(c.c.ToString())));
    }

    public bool Solve()
    {

        if (!FindEmptyCell(out int row, out int col))
            return true;

        for (int num = 1; num <= 9; num++)
            if (IsValidMove(row, col, num))
            {
                board[row, col] = num;

                if (Solve())
                    return true;

                board[row, col] = 0;
            }

        return false;
    }

    private bool FindEmptyCell(out int row, out int col)
    {
        for (row = 0; row < 9; row++)
            for (col = 0; col < 9; col++)
                if (board[row, col] == 0)
                    return true;

        row = -1;
        col = -1;
        return false;
    }

    private bool IsValidMove(int row, int col, int num)
    {
        for (int i = 0; i < 9; i++)
            if (board[row, i] == num)
                return false;

        for (int i = 0; i < 9; i++)
            if (board[i, col] == num)
                return false;

        int boxRow = row - row % 3;
        int boxCol = col - col % 3;

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (board[boxRow + i, boxCol + j] == num)
                    return false;

        return true;
    }
}
