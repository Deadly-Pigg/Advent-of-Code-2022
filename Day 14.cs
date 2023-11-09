using System.Text.RegularExpressions;

string[] file = File.ReadAllLines("AoC14.txt");
int boundx = 400, boundy = 300;
char[,] grid = new char[boundx, boundy];
int x1, x2 = -1, y1, y2 = -1;
int maxY = 0;
int minX = 1000, maxX = 0, startX = 500-300;
bool intoTheAbyss = false, grounded = false;

for (int y = 0; y < boundy; y++)
{
    for (int x = 0; x < boundx; x++)
    {
        grid[x,y] = '.';
    }
}

foreach (string line in file)
{
    string lineT = line + "-> s,s -> s,s";
    string[] directions = lineT.Split("->");
    x2 = -1;
    y2 = -1;
            foreach(string d in directions)
            {
                x1 = x2;
                y1 = y2;
                string[] xy = Regex.Replace(d, @"[\s]", "").Split(',');
                Console.WriteLine(xy[0] + ", and " + xy[1]);
                if (xy.Contains("s") != true)
                {
                    x2 = Convert.ToInt32(xy[0])-300;
                    y2 = Convert.ToInt32(xy[1]);
                }
                if(y2 > maxY)
                { maxY = y2; }
                if(x2 > maxX)
                {
                    maxX = x2;
                }
                else if(x2 < minX)
                {
                minX = x2;
                }
                if(x1 != - 1 && y1 != -1)
                {
                    if (x1 == x2)
                    {
                        if (y1 >= y2)
                        {
                            for(int i = y1; i >= y2; i--)
                            {
                                grid[x1, i] = '#';
                            }
                        }
                        else if (y1 <= y2)
                        {
                        for (int i = y1; i <= y2; i++)
                            {
                                grid[x1, i] = '#';
                            }
                        }
                    }
                    else if (y1 == y2)
                    {
                        if (x1 >= x2)
                        {
                            for (int i = x1; i >= x2; i--)
                            {
                                grid[i, y1] = '#';
                            }
                        }
                        else if (x1 <= x2)
                        {
                            for (int i = x1; i <= x2; i++)
                            {
                                grid[i, y1] = '#';
                            }
                        }
                    }
                }
            }

}
Console.WriteLine("==========================================================================================================================");
x2 = 0;

for(int x = 0; x< boundx; x++)
{
    grid[x, maxY + 2] = '#';
}
while (intoTheAbyss == false)
{
    x2++;
    grounded = false;
    grid[startX, 0] = '+';
    x1 = startX;
    y1 = 0;
    while (grounded == false)
    {
        Console.WriteLine("y: " + y1 + ", x:" + x1);
        if (grid[startX, 0] != '+')
        {
            intoTheAbyss = true;
        }
        if (grid[x1,y1+1] == '.')
        {
            y1++;
        }
        else if (grid[x1-1,y1] == '.')
        {
            x1--;
        }
        else if (grid[x1+1, y1] == '.')
        {
            x1++;
        }
        else
        {
            grounded = true;
            grid[x1, y1] = 'o';
        }
        
        if (y1 >= boundy - 3)
        {
            intoTheAbyss = true;
            grounded = true;
            break;
        }
    }
    if(x2 > 5000)
    {
        break;
    }
}

int counter = 0;

for(int y = 0; y < boundy; y++)
{
    for(int x = 0; x < boundx; x++)
    {
        if (grid[x,y] == 'o')
        { counter++; }
        Console.Write(grid[x, y]);
    }
    Console.WriteLine();
}
Console.WriteLine(maxY);
Console.WriteLine("Min: " + minX + ", Max: " + maxX);
Console.WriteLine(counter);