
int target = 1000000;
int[] partitions = new int[target + 1];
partitions[0] = 1;
var result = 0;

for (int i = 1; i <= target; i++)
{
    int j = 1;
    int pentagonal = 1;
    partitions[i] = 0;

    while (pentagonal <= i)
    {
        int sign = (j % 2 == 0) ? -1 : 1;
        partitions[i] += sign * partitions[i - pentagonal];

        partitions[i] %= target;
        if (partitions[i] < 0)
            partitions[i] += target;

        j = (j < 0) ? -j + 1 : -j;
        pentagonal = j * (3 * j - 1) / 2;
    }

    if (partitions[i] == 0)
    {
        result = i;
        break;
    }
}

Console.WriteLine(result);