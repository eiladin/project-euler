﻿var numbers = Enumerable.Range(1, 999).Where(x => x % 3 == 0 || x % 5 == 0).Sum();
Console.WriteLine(numbers);
