
var date = DateTime.Parse("1901-01-01");
var max = DateTime.Parse("2000-12-31");
var sum = 0;
while (date < max)
{
    sum += date.DayOfWeek == DayOfWeek.Sunday ? 1 : 0;
    date = date.AddMonths(1);
}
Console.WriteLine(sum);