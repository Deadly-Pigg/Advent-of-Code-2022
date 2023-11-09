using System.Text.RegularExpressions;

string[] file = File.ReadAllLines("AoC9.txt");
int tempNum = 0;
int Umax = 0, Rmax = 0, Dmax = 0, Lmax = 0;
int x = 0, y = 0;

foreach (string line in file)
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
    if (x < Math.Abs(Rmax - Lmax)) { x = Math.Abs(Rmax - Lmax); }
    if (y < Math.Abs(Umax - Dmax)) { y = Math.Abs(Umax - Dmax); }
}

int length = 2;
int[] moveX = new int[length], moveY = new int[length];
for(int i = 0; i < length; i++)
{
    moveX[i] = x;
    moveY[i] = y;
}
x = x * 2 + 10;
y = y * 2 + 10;

string[,] grid = new string[x, y];
int[] xy = new int[2];
string[,] grid2 = new string[x, y];
grid[moveX[0], moveY[0]] = "s";

foreach (string line in file)
{
    tempNum = Int32.Parse(Regex.Replace(line, @"[^\d]", ""));
    switch (Regex.Replace(line, @"[\d|\s]", ""))
    {
        case ("U"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX[0], moveY[0]] = "";
                moveY[0]--;
                grid[moveX[0], moveY[0]] = "H";
                for (int i2 = 1; i2 < length; i2++)
                {
                    xy = nearbyCheck(grid, moveX[i2], moveY[i2], moveX[i2 - 1], moveY[i2 - 1], i2);
                    moveX[i2] += xy[0];
                    moveY[i2] += xy[1];
                    grid[moveX[i2], moveY[i2]] = i2.ToString();
                    grid2[moveX[length - 1], moveY[length - 1]] = "#";
                }
                
            }
            break;
        case ("R"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX[0], moveY[0]] = "";
                moveX[0]++;
                grid[moveX[0], moveY[0]] = "H";
                for (int i2 = 1; i2 < length; i2++)
                {
                    xy = nearbyCheck(grid, moveX[i2], moveY[i2], moveX[i2 - 1], moveY[i2 - 1], i2);
                    moveX[i2] += xy[0];
                    moveY[i2] += xy[1];
                    grid[moveX[i2], moveY[i2]] = i2.ToString();
                    grid2[moveX[length - 1], moveY[length - 1]] = "#";
                }
            }
            break;
        case ("D"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX[0], moveY[0]] = "";
                moveY[0]++;
                grid[moveX[0], moveY[0]] = "H";
                for (int i2 = 1; i2 < length; i2++)
                {
                    xy = nearbyCheck(grid, moveX[i2], moveY[i2], moveX[i2 - 1], moveY[i2 - 1], i2);
                    moveX[i2] += xy[0];
                    moveY[i2] += xy[1];
                    grid[moveX[i2], moveY[i2]] = i2.ToString();
                    grid2[moveX[length - 1], moveY[length - 1]] = "#";
                }
                
            }
            break;
        case ("L"):
            for (int i = 0; i < tempNum; i++)
            {
                grid[moveX[0], moveY[0]] = "";
                moveX[0]--;
                grid[moveX[0], moveY[0]] = "H";
                for (int i2 = 1; i2 < length; i2++)
                {
                    xy = nearbyCheck(grid, moveX[i2], moveY[i2], moveX[i2 - 1], moveY[i2 - 1], i2);
                    moveX[i2] += xy[0];
                    moveY[i2] += xy[1];
                    grid[moveX[i2], moveY[i2]] = i2.ToString();
                    grid2[moveX[length - 1], moveY[length - 1]] = "#";
                }
                

            }
            break;
    }
}

int counter = 0;
Console.WriteLine(x * y);
foreach (string s in grid2)
{
    if (s != null) { counter++; }
}

Console.WriteLine(Umax);

for (int ix = 0; ix < x; ix++)
{
    for (int iy = 0; iy < y; iy++)
    {
        if (grid2[ix, iy] != null)
        { Console.Write(grid2[ix,iy]); }
        else { Console.Write("."); }
    }
    Console.WriteLine();
}


static int[] nearbyCheck(string[,] grid, int oldX, int oldY, int moveX, int moveY, int n)
{
    int[] xy = new int[2];
    int val = 0;
    xy[0] = 0;
    xy[1] = 0;

    if (oldX + 1 == moveX && oldY + 1 == moveY) { return xy; }
    if (oldX + 1 == moveX && oldY == moveY) { return xy; }
    if (oldX + 1 == moveX && oldY - 1 == moveY) { return xy; }
    if (oldX == moveX && oldY + 1 == moveY) { return xy; }
    if (oldX == moveX && oldY == moveY) { return xy; }
    if (oldX == moveX && oldY - 1 == moveY) { return xy; }
    if (oldX - 1 == moveX && oldY + 1 == moveY) { return xy; }
    if (oldX - 1 == moveX && oldY == moveY) { return xy; }
    if (oldX - 1 == moveX && oldY - 1 == moveY) { return xy; }


    val = (moveX - oldX) == 0 ? xy[0] = 0 : val = (moveX - oldX) > 0 ? xy[0] = 1 : xy[0] = -1;
    val = (moveY - oldY) == 0 ? xy[1] = 0 : val = (moveY - oldY) > 0 ? xy[1] = 1 : xy[1] = -1;

    return xy;
}
