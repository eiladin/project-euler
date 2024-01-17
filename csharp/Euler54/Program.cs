var player1Wins = 0;
var input = File.ReadAllLines("input.txt");
foreach (var line in input)
{
    var cards = line.Split(' ');
    var hand1 = new Hand(cards.Take(5).ToArray());
    var hand2 = new Hand(cards.Skip(5).ToArray());
    if (hand1.Score > hand2.Score)
        player1Wins++;
}
Console.WriteLine(player1Wins);

enum HandCategory
{
    HighCard = 1,
    Pair = 2,
    TwoPair = 3,
    ThreeOfAKind = 4,
    Straight = 5,
    Flush = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    StraightFlush = 9,
    RoyalFlush = 10
}

internal class Card(char value, char suit)
{
    public string Suit { get; set; } = suit.ToString();
    public int Value { get; set; } = "23456789TJQKA".IndexOf(value.ToString()) + 2;
    public override string ToString() => $"{value}{suit}";
}

internal class Hand(string[] cards)
{
    private readonly List<Card> _cards = cards.Select(c => new Card(c[0], c[1])).ToList();
    private double _score = 0;
    public double Score => _score == 0 ? ScoreHand() : _score;
    public HandCategory Category { get; private set; }

    private void SetScore(HandCategory category, params int[] kickers)
    {
        _score = (int)category * 10_000_000_000;
        int kickval = 100_000_000;
        for (int i = 0; i < kickers.Length; i++)
        {
            _score += kickers[i] * kickval;
            kickval /= 100;
        }
        Category = category;
    }

    private double ScoreHand()
    {
        var valueList = _cards.Select(c => c.Value);
        var highcard = valueList.Max();
        var groups = valueList.GroupBy(x => x);
        var isStraight = valueList.Max() - valueList.Min() == 4 && groups.Count() == 5;
        var isFlush = _cards.All(c => c.Suit == _cards.First().Suit);
        var hasPairs = groups.Any(g => g.Count() > 1);
        var fourOfAKind = groups.FirstOrDefault(g => g.Count() == 4);
        var threeOfAKind = groups.FirstOrDefault(g => g.Count() == 3);
        var pairs = groups.Where(g => g.Count() == 2);

        if (isStraight && isFlush && highcard == 14)
            SetScore(HandCategory.RoyalFlush);
        else if (isStraight && isFlush)
            SetScore(HandCategory.StraightFlush, highcard);
        else if (isFlush)
            SetScore(HandCategory.Flush, highcard);
        else if (isStraight)
            SetScore(HandCategory.Straight, highcard);
        else if (fourOfAKind != null)
            SetScore(HandCategory.FourOfAKind, fourOfAKind.Key, valueList.Where(x => x != fourOfAKind.Key).Max());
        else if (threeOfAKind != null && pairs.Any())
            SetScore(HandCategory.FullHouse, threeOfAKind.Key, pairs.First().Key);
        else if (threeOfAKind != null)
            SetScore(HandCategory.ThreeOfAKind,
                     threeOfAKind.Key,
                     valueList.Where(x => x != threeOfAKind.Key).Max(),
                     valueList.Where(x => x != threeOfAKind.Key).Min());
        else if (pairs.Count() == 2)
            SetScore(HandCategory.TwoPair,
                     pairs.Select(p => p.Key).Max(),
                     pairs.Select(p => p.Key).Min(),
                     groups.First(g => g.Count() == 1).Key);
        else if (pairs.Count() == 1)
            SetScore(HandCategory.Pair,
                     groups.OrderByDescending(x => x.Count()).Select(g => g.Key).ToArray());
        else
            SetScore(HandCategory.HighCard, [.. valueList.OrderByDescending(x => x)]);

        return _score;
    }

    public override string ToString() => $"{Category} - {string.Join(" ", _cards)}";
}