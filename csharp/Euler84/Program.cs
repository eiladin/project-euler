
var board = new int[40];
var currentPosition = 0;
var doublesCount = 0;
var totalRolls = 0;
Random random = new();
List<int> ChanceDeck = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16];
List<int> CommunityChestDeck = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16];
var chanceIndex = 0;
var communityChestIndex = 0;

for (int i = 0; i < 2_000_000; i++)
{
    int dice1 = RollDice();
    int dice2 = RollDice();

    currentPosition = (currentPosition + dice1 + dice2) % 40;
    currentPosition = currentPosition switch
    {
        30 => 10,
        2 or 17 or 33 => HandleCommunityChest(currentPosition),
        7 or 22 or 36 => HandleChance(currentPosition),
        _ => currentPosition,
    };

    doublesCount = (dice1 == dice2) ? doublesCount + 1 : 0;

    if (doublesCount == 3)
    {
        currentPosition = 10;
        doublesCount = 0;
    }

    totalRolls++;
    board[currentPosition]++;
}

List<(int, double)> probabilities = board.ToList().Select((b, idx) => (idx, (double)b / totalRolls)).ToList();
probabilities.Sort((x, y) => y.Item2.CompareTo(x.Item2));
var result = probabilities.Take(3).Select(x => x.Item1).Aggregate("", (acc, x) => acc + x.ToString("D2"));
Console.WriteLine(result);

int RollDice() => random.Next(1, 5);

int HandleCommunityChest(int currentPosition)
{
    if (communityChestIndex == 16)
        communityChestIndex = 0;
    return CommunityChestDeck[communityChestIndex++] switch
    {
        1 => 0, // Go
        2 => 10, // Go to Jail
        _ => currentPosition,
    };
}

int HandleChance(int currentPosition)
{
    if (chanceIndex == 16)
        chanceIndex = 0;
    return ChanceDeck[chanceIndex++] switch
    {
        1 => 0, // Go
        2 => 10, // Go to Jail
        3 => 11, // C1
        4 => 24, // E3
        5 => 39, // H2
        6 => 5, // R1
        7 or 8 => currentPosition switch // Next Railway
        {
            7 => 15,
            22 => 25,
            36 => 5,
            _ => currentPosition,
        },
        9 => currentPosition switch // Next Utility
        {
            7 or 36 => 12,
            22 => 28,
            _ => currentPosition,
        },
        10 => currentPosition - 3, // Go back 3 squares
        _ => currentPosition,
    };
}