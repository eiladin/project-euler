var power = 2L;
for (var n = 2; n <= 7830457; n++)
    power = power * 2 % 10_000_000_000;
Console.WriteLine((28433 * power + 1) % 10_000_000_000);