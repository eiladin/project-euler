long sum = 0;
for (var i = 1; i <= 1000; i++)
    sum += NumberToWord(i);
Console.WriteLine(sum);

static long NumberToWord(int n)
{
    string words = "";
    string[] ones = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
    string[] teens = ["", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"];
    string[] tens = ["", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];

    if (n == 1000)
        return "onethousand".Length;
    if (n / 100 > 0)
    {
        words += ones[n / 100] + "hundred";
        n %= 100;
        if (n > 0)
            words += "and";
    }
    if (n > 10 && n < 20)
        words += teens[n % 10];
    else
    {
        if (n / 10 > 0)
        {
            words += tens[n / 10];
            n %= 10;
        }
        if (n > 0)
            words += ones[n];
    }
    return words.Length;
}