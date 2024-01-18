var input = File.ReadAllText("input.txt").Split(',').Select(x => int.Parse(x)).ToArray();
var result = string.Empty;
var decrypted = new List<int>();
var found = false;

for (var a = 97; a < 122 && !found; a++)
    for (var b = 97; b < 122 && !found; b++)
        for (var c = 97; c < 122 && !found; c++)
        {
            decrypted.Clear();
            var key = new[] { a, b, c };
            var keyIndex = 0;
            foreach (var i in input)
            {
                decrypted.Add(i ^ key[keyIndex]);
                keyIndex = (keyIndex + 1) % 3;
            }
            if (decrypted.All(x => x >= 32 && x <= 122))
            {
                var str = string.Join("", decrypted.Select(x => (char)x));
                if (str.Contains("Euler"))
                    found = true;
            }
        }

Console.WriteLine(decrypted.Sum());

