using System.Text.RegularExpressions;

// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines("AoC9.txt");
int tempNum = 0;
int Umax = 0, Rmax = 0, Dmax = 0, Lmax = 0;
int x = 0, y = 0;

foreach(string line in file)
{
    tempNum = Int32.Parse(Regex.Replace(line, @"[^\d]", ""));
    switch (Regex.Replace(line, @"[\d|\s]", ""))
    {
        case ("U"):
            Umax += tempNum;
            break;
        case ("R"):
            Rmax += tempNum;
            break;
        case ("D"):
            Dmax += tempNum;
            break;
        case ("L"):
            Lmax += tempNum;
            break;
    }
    if(x < Math.Abs(Rmax - Lmax)) {x = Math.Abs(Rmax - Lmax);}
    if(y < Math.Abs(Umax - Dmax)) {y = Math.Abs(Umax - Dmax);}
}

int moveX = x, moveY = y;
int oldX = moveX, oldY = moveY;
x = x * 2 + 10;
y = y * 2 + 10;

string[,] grid = new string[x,y];
int[] xy = new int[2];
string[,] grid2 = new string[x, y];

foreach (string line in file)
{
    tempNum = Int32.Parse(Regex.Replace(line, @"[^\d]", ""));
    switch (Regex.Replace(line, @"[\d|\s]", ""))
    {
        case ("U"):
            for(int i = 0; i<tempNum; i++)
            {
                grid[moveX, moveY] = ".";
                moveY--;
                grid[moveX, moveY] = "H";
                xy = nearbyCheck(grid, oldX, oldY, moveX, moveY);
                oldX += xy[0];
                oldY += xy[1];
                grid2[oldX, oldY] = "#";
            }
            break;
        case ("R"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX, moveY] = ".";
                moveX++;
                grid[moveX, moveY] = "H";
                xy = nearbyCheck(grid, oldX, oldY, moveX, moveY);
                oldX += xy[0];
                oldY += xy[1];
                grid2[oldX, oldY] = "#";
            }
            break;
        case ("D"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX, moveY] = ".";
                moveY++;
                grid[moveX, moveY] = "H";
                xy = nearbyCheck(grid, oldX, oldY, moveX, moveY);
                oldX += xy[0];
                oldY += xy[1];
                grid2[oldX, oldY] = "#";
            }
            break;
        case ("L"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX, moveY] = ".";
                moveX--;
                grid[moveX, moveY] = "H";
                xy = nearbyCheck(grid, oldX, oldY, moveX, moveY);
                oldX += xy[0];
                oldY += xy[1];
                grid2[oldX, oldY] = "#";
            }
            break;
    }
}

Umax = 0;
foreach (string s in grid2)
{
    if (s == "#") { Umax++; }
}

Console.WriteLine(Umax);

static int[] nearbyCheck(string[,] grid, int oldX, int oldY, int moveX, int moveY)
{
    int[] xy = new int[2];
    int val = 0;
    xy[0] = 0;
    xy[1] = 0;

    if (grid[oldX + 1, oldY + 1] == "H") { return xy; }
    if (grid[oldX + 1, oldY    ] == "H") { return xy; }
    if (grid[oldX + 1, oldY - 1] == "H") { return xy; }
    if (grid[oldX,     oldY + 1] == "H") { return xy; }
    if (grid[oldX,     oldY    ] == "H") { return xy; }
    if (grid[oldX,     oldY - 1] == "H") { return xy; }
    if (grid[oldX - 1, oldY + 1] == "H") { return xy; }
    if (grid[oldX - 1, oldY    ] == "H") { return xy; }
    if (grid[oldX - 1, oldY - 1] == "H") { return xy; }


    val = (moveX - oldX) == 0 ? xy[0] = 0 : val = (moveX-oldX) > 0 ? xy[0] = 1 : xy[0] = -1;
    val = (moveY - oldY) == 0 ? xy[1] = 0 : val = (moveY-oldY) > 0 ? xy[1] = 1 : xy[1] = -1;

    return xy;
}
