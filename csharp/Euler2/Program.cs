List<int> FibonacciNumbers = [1, 2];

while (FibonacciNumbers.Last() < 4_000_000)
{
    var previous = FibonacciNumbers[^1];
    var previous2 = FibonacciNumbers[^2];

    FibonacciNumbers.Add(previous + previous2);
}

Console.WriteLine(FibonacciNumbers.Where(x => x % 2 == 0).Sum());