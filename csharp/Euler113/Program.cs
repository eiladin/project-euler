ulong Modulo = 1_000_000_000_000_000_000UL;

const uint numDigits = 100_000;
var solutions = new ulong[numDigits + 1];

var increase = new ulong[numDigits][];
var decrease = new ulong[numDigits][];
for (int i = 0; i < numDigits; i++)
{
    increase[i] = new ulong[10];
    decrease[i] = new ulong[10];
}

ulong sum = 9;
for (int i = 0; i < 10; i++)
{
    increase[0][i] = 1;
    decrease[0][i] = 1;
}

for (uint i = 1; i < numDigits; i++)
{
    for (uint current = 0; current <= 9; current++)
    {
        decrease[i][current] = 0;
        for (uint smaller = 0; smaller <= current; smaller++)
            decrease[i][current] = (decrease[i][current] + decrease[i - 1][smaller]) % Modulo;

        increase[i][current] = 0;
        for (uint bigger = current; bigger <= 9; bigger++)
            increase[i][current] = (increase[i][current] + increase[i - 1][bigger]) % Modulo;
    }

    for (uint x = 0; x < 10; x++)
    {
        sum += increase[i][x];
        sum += decrease[i][x];
    }

    sum = (sum - increase[i][0] - 10) % Modulo;
    solutions[i] = sum;
}

Console.WriteLine(solutions[99]);

