string[] file = File.ReadAllLines("AoC11.txt");
List<long>[] monkeyItems = new List<long>[8];
long i = 0, worry = 0;
long[] throws = new long[8];
long[] inspects = new long[8];
long funniNumber = 9699690;

for (i = 0; i < 8; i++)
{
    monkeyItems[i] = new List<long>();
}

i = 0;
foreach(string line in file)
{
    string[] tempArray = line.Split(",");
    foreach(string s in tempArray)
    {
        monkeyItems[i].Add(Convert.ToInt64(s));
    }
    i++;
}

foreach (List<long> list in monkeyItems)
{
    foreach(long val in list)
    {
        Console.Write(val + ",");
    }
    Console.WriteLine("");
}

for (i = 0; i < 10000; i++)
{
    Console.WriteLine(worry + "Round: " + i);
    foreach (long l in monkeyItems[0]) //correct
    {
        worry = l * 17;
        inspects[0]++;
        if (worry % 2 == 0)
        {
            monkeyItems[1].Add(worry% (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[1]++;
        }
        else
        {
            monkeyItems[6].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[6]++;
        }
    }
    monkeyItems[0].Clear();

    foreach (long l in monkeyItems[1]) //correct
    {
        worry = l + 1;
        inspects[1]++;
        if (worry % 17 == 0)
        {
            monkeyItems[6].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[6]++;
        }
        else
        {
            monkeyItems[3].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[3]++;
        }
    }
    monkeyItems[1].Clear();

    foreach (long l in monkeyItems[2]) // correct
    {
        worry = l + 3;
        inspects[2]++;
        if (worry % 19 == 0)
        {
            monkeyItems[7].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[7]++;
        }
        else
        {
            monkeyItems[5].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[5]++;
        }
    }
    monkeyItems[2].Clear();

    foreach (long l in monkeyItems[3]) // correct
    {
        worry = l + 5;
        inspects[3]++;
        if (worry % 3 == 0)
        {
            monkeyItems[7].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[7]++;
        }
        else
        {
            monkeyItems[2].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[2]++;
        }
    }
    monkeyItems[3].Clear();

    foreach (long l in monkeyItems[4]) // correct
    {
        worry = l * l;
        inspects[4]++;
        if (worry % 5 == 0)
        {
            monkeyItems[0].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[0]++;
        }
        else
        {
            monkeyItems[1].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[1]++;
        }
    }
    monkeyItems[4].Clear();

    foreach (long l in monkeyItems[5]) // correct
    {
        worry = l + 2;
        inspects[5]++;
        if (worry % 13 == 0)
        {
            monkeyItems[4].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[4]++;
        }
        else
        {
            monkeyItems[0].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[0]++;
        }
    }
    monkeyItems[5].Clear();

    foreach (long l in monkeyItems[6]) // correct
    {
        worry = l + 4;
        inspects[6]++;
        if (worry % 7 == 0)
        {
            monkeyItems[3].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[3]++;
        }
        else
        {
            monkeyItems[2].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[2]++;
        }
    }
    monkeyItems[6].Clear();

    foreach (long l in monkeyItems[7]) // correct
    {
        worry = l * 19;
        inspects[7]++;
        if (worry % 11 == 0)
        {
            monkeyItems[4].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[4]++;
        }
        else
        {
            monkeyItems[5].Add(worry % (2 * 17 * 19 * 3 * 5 * 13 * 7 * 11));
            throws[5]++;
        }
    }
    monkeyItems[7].Clear();
    
    Console.WriteLine(worry);
}


Array.Sort(inspects);

foreach (long val in inspects)
{ Console.WriteLine(val); }

Console.WriteLine(inspects[7] * inspects[6]);

static long Divide(long worry, long mod)
{
    long bruh = 0;
    if(worry % mod == 0)
    {
        return worry / mod;
    }
    return worry;
}