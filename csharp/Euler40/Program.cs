using System.Text;

var i = 1;
StringBuilder sb = new();
while (sb.Length < 1_000_000)
    sb.Append(i++);

var result = 1;
var s = sb.ToString();
for (var j = 1; j <= 1_000_000; j *= 10)
    result *= int.Parse(s[j - 1].ToString());

Console.WriteLine(result);