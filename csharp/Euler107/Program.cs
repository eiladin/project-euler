
var graph = ReadGraphFromFile("input.txt");
var result = CalculateTotalWeight(graph) - CalculateMinimumSpanningTreeWeight(graph);
Console.WriteLine(result);

static int[,] ReadGraphFromFile(string filePath)
{
    string[] lines = File.ReadAllLines(filePath);
    int size = lines.Length;
    int[,] graph = new int[size, size];

    for (int i = 0; i < size; i++)
    {
        string[] weights = lines[i].Split(',');
        for (int j = 0; j < size; j++)
        {
            if (weights[j] != "-")
                graph[i, j] = int.Parse(weights[j]);
        }
    }

    return graph;
}

static int CalculateTotalWeight(int[,] graph)
{
    int size = graph.GetLength(0);
    int totalWeight = 0;

    for (int i = 0; i < size; i++)
        for (int j = i + 1; j < size; j++)
            totalWeight += graph[i, j];

    return totalWeight;
}

static int CalculateMinimumSpanningTreeWeight(int[,] graph)
{
    int size = graph.GetLength(0);
    List<Edge> edges = [];

    for (int i = 0; i < size; i++)
        for (int j = i + 1; j < size; j++)
            if (graph[i, j] > 0)
                edges.Add(new Edge(i, j, graph[i, j]));

    var ordered = edges.OrderBy(edge => edge.Weight);

    int[] parent = new int[size];
    for (int i = 0; i < size; i++)
        parent[i] = i;

    int minimumWeight = 0;

    foreach (Edge edge in ordered)
    {
        var root1 = Find(parent, edge.Source);
        var root2 = Find(parent, edge.Destination);

        if (root1 != root2)
        {
            minimumWeight += edge.Weight;
            parent[root1] = root2;
        }
    }

    return minimumWeight;
}

static int Find(int[] parent, int node)
{
    while (parent[node] != node)
        node = parent[node];

    return node;
}

internal record Edge(int Source, int Destination, int Weight);