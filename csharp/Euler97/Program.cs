using System.Numerics;

var power = 2L;
for (var n = 2; n <= 7830457; n++)
    power = power * 2 % 10000000000;
Console.WriteLine((28433 * power + 1) % 10000000000);