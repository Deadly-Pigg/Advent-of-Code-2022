using System.Text.RegularExpressions;

int length = 2; //This is for the rope length (iirc). 2 == part 1, 10 == part 2.
//you can add other values if you want for fun though.

string[] file = File.ReadAllLines("AoC9.txt"); //Reads file
int Umax = 0, Rmax = 0, Dmax = 0, Lmax = 0;
int tempNum = 0;
int x = 0, y = 0;  //Variables. the max stuff is to measure the 'grid' (since I didn't want to measure the grid myself/set a size), x and y are just the lengths of the 2d array.
//tempNum is just a temporary variable, mainly used for reading and storing the value in the file.

foreach (string line in file) //reading each line of the file
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

int[] moveX = new int[length], moveY = new int[length]; //I forgot what this was for. I believe this just dictates where the head goes?
for(int i = 0; i < length; i++) 
{
    moveX[i] = x;
    moveY[i] = y;
}
x = x * 2 + 10; //incase the rope decides it wants to only go in one direction.
y = y * 2 + 10;

string[,] grid = new string[x, y];
int[] xy = new int[2];
string[,] grid2 = new string[x, y];
grid[moveX[0], moveY[0]] = "s"; //creating the grid; one grid was for the already occupied areas, the other is for the Head position (because I couldn't think of a better way to ensure the Head doesn't replace #'s)

foreach (string line in file) //the nasty code. Just follows the instructions and leads the head + body where it needs to go.
{
    tempNum = Int32.Parse(Regex.Replace(line, @"[^\d]", ""));
    switch (Regex.Replace(line, @"[\d|\s]", ""))
    {
        case ("U"):
            for (int i = 0; i < tempNum; i++) //dictates the amount of steps the rope snake takes
            {
                grid[moveX[0], moveY[0]] = "";
                moveY[0]--;
                grid[moveX[0], moveY[0]] = "H";
                for (int i2 = 1; i2 < length; i2++) //this is for all the points after the head. Calculates the movement.
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
Console.WriteLine(x * y); //just shows the grid dimensions
foreach (string s in grid2) //counts each and every character in grid2, adding it to the counter
{
    if (s != null) { counter++; }
}

Console.WriteLine(counter);

for (int ix = 0; ix < x; ix++) //displays the path of the rope snake for debugging purposes.
{
    for (int iy = 0; iy < y; iy++)
    {
        if (grid2[ix, iy] != null)
        { Console.Write(grid2[ix,iy]); }
        else { Console.Write("."); }
    }
    Console.WriteLine();
}


static int[] nearbyCheck(string[,] grid, int oldX, int oldY, int moveX, int moveY, int n) //checks if a part of the body is already in contact with it's leading part. 
{ //stays stationary if so, otherwise, it moves it towards the leading part.
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
