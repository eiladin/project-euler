
int[][] matrix = File.ReadAllText("input.txt")
    .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
    .Select(line => line.Split(',').Select(int.Parse).ToArray())
    .ToArray();

int result = FindMinimumPathSum(matrix);
Console.WriteLine(result);

static int FindMinimumPathSum(int[][] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix[0].GetLength(0);

    int[,] dp = new int[rows, cols];
    dp[0, 0] = matrix[0][0];

    for (int j = 1; j < cols; j++)
        dp[0, j] = dp[0, j - 1] + matrix[0][j];

    for (int i = 1; i < rows; i++)
        dp[i, 0] = dp[i - 1, 0] + matrix[i][0];

    for (int i = 1; i < rows; i++)
        for (int j = 1; j < cols; j++)
            dp[i, j] = matrix[i][j] + Math.Min(dp[i - 1, j], dp[i, j - 1]);

    return dp[rows - 1, cols - 1];
}
