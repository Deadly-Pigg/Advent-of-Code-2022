using System.Text.RegularExpressions;

string[] file = File.ReadAllLines("AoC10.txt");
int cycles = 0, x = 1, i = 0, y=0;
int total = 0;
string[,] bruh = new string[40,8];
for (int i3 = 0; i3 < 8; i3++)
{

    for (int i2 = 0; i2 < 40; i2++)
    {
        bruh[i2, i3] = "E";
    }
}
foreach (string line in file)
{
    if (line == "noop")
    {
        cycles++;
        total += function(cycles, x);
        if (i >= 40) { i -= 40; y++; }
        bruh[i, y] = painful(i, y, x);
    }
    else
    {
        cycles++;
        if (i >= 40) { i -= 40; y++; }
        bruh[i, y] = painful(i, y, x);
        i++;
        total += function(cycles, x);
        cycles++;
        if (i >= 40) { i -= 40; y++; }
        bruh[i, y] = painful(i, y, x);
        total += function(cycles, x);
        x += Convert.ToInt32(Regex.Replace(line, @"[addx ]", ""));
    }
    i++;
    
}

for (int i3 = 0; i3 < 8; i3++)
{
    Console.WriteLine();
    for (int i2 = 0; i2 < 40; i2++)
    {
        Console.Write(bruh[i2, i3]);
    }
}
Console.WriteLine();
Console.WriteLine("cycle:" + cycles + ", x:" + x + ", total: " + total);

static int function(int cycles, int x)
{
    int val = 0;
    if (cycles == 20 || cycles == 60 || cycles == 100 || cycles == 140 || cycles == 180 || cycles == 220)
    {
        val = cycles * x;
    }
    return val;
}
static string painful(int i, int y, int x)
{
    
        if (i >= x - 1 && i <= x + 1)
        {return "■"; }
        else
        {return " ";}
}