var blueDiscs = 15L;
var totalDiscs = 21L;

while (totalDiscs < 1_000_000_000_000)
{
    var newBlueDiscs = 3 * blueDiscs + 2 * totalDiscs - 2;
    var newTotalDiscs = 4 * blueDiscs + 3 * totalDiscs - 3;
    blueDiscs = newBlueDiscs;
    totalDiscs = newTotalDiscs;
}

Console.WriteLine(blueDiscs);
