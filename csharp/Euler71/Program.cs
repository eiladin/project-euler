var a = 2;
var b = 5;
var c = 3;
var d = 7;
while (b + d <= 1_000_000)
{
    a += c;
    b += d;
}
Console.WriteLine(a);