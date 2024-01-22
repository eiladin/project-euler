var lines = File.ReadAllLines("input.txt");
var matrix = new int[lines.Length, lines[0].Split(',').Length];
for (var i = 0; i < lines.Length; i++)
{
    var values = lines[i].Split(',');
    for (var j = 0; j < values.Length; j++)
        matrix[i, j] = int.Parse(values[j]);
}

var result = FindMinimalPathSum(matrix);
Console.WriteLine(result);

static int FindMinimalPathSum(int[,] matrix)
{
    var rows = matrix.GetLength(0);
    var cols = matrix.GetLength(1);

    var dp = new int[rows, cols];
    for (var i = 0; i < rows; i++)
        for (var j = 0; j < cols; j++)
            dp[i, j] = int.MaxValue;

    dp[0, 0] = matrix[0, 0];

    Queue<(int, int)> queue = new();
    queue.Enqueue((0, 0));

    int[] dx = [-1, 0, 1, 0];
    int[] dy = [0, 1, 0, -1];

    while (queue.Count > 0)
    {
        var (x, y) = queue.Dequeue();

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];

            if (nx >= 0 && nx < rows && ny >= 0 && ny < cols)
            {
                int newSum = dp[x, y] + matrix[nx, ny];
                if (newSum < dp[nx, ny])
                {
                    dp[nx, ny] = newSum;
                    queue.Enqueue((nx, ny));
                }
            }
        }
    }

    return dp[rows - 1, cols - 1];
}
