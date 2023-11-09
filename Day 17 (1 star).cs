using System.Text.RegularExpressions;

char[] instructions = File.ReadAllText("AoC17.txt").ToCharArray();
char[,] grid = new char[7, 5000];
int xy = 0;

for (int y = 0; y < 5000; y++)
{
    for (int x = 0; x < 7; x++)
    {
        grid[x, y] = '.';
        if (y == 4999)
        {grid[x, y] = '-';}
    }
}

int rockType = -1;
int inst = instructions.Length;
int posX, posY;
int ins = 0;
int curheight = 4999 - 4;
int max = curheight;
bool endloop = false;
int oldY = 0;

Console.WriteLine(instructions.Length + 1);

for (int round = 0; round < 1000; round++)
{
    rockType = (rockType + 1) % 5;
    posX = 2;

    if (max < curheight) { curheight = max; }
    else { max = curheight; }

    posY = curheight;
    grid[posX, posY] = 'Q';
    if (round <= 10)
    {
        drawConsole(grid);
    }
    grid[posX, posY] = '.';
    endloop = false;

    if (rockType == 0)
    {
        while (endloop == false)
        {
            grid[posX, posY] = '@';
            grid[posX + 1, posY] = '@';
            grid[posX + 2, posY] = '@';
            grid[posX + 3, posY] = '@';
            drawConsole(grid);
            grid[posX, posY] = '.';
            grid[posX + 1, posY] = '.';
            grid[posX + 2, posY] = '.';
            grid[posX + 3, posY] = '.';

            oldY = posY;
            posX += rock0x(grid, instructions, ins, posX, posY);
            ins = (ins + 1) % inst;
            posY += rock0y(grid, posX, posY);
            if (oldY == posY)
            {
                grid[posX, posY] = '#';
                grid[posX + 1, posY] = '#';
                grid[posX + 2, posY] = '#';
                grid[posX + 3, posY] = '#';
                curheight = posY - 4;
                endloop = true;
            }
        }
    }


    if (rockType == 1)
    {

        while (endloop == false)
        {
            grid[posX, posY - 1] = '@';
            grid[posX + 1, posY - 1] = '@';
            grid[posX + 2, posY - 1] = '@';
            grid[posX + 1, posY - 2] = '@';
            grid[posX + 1, posY] = '@';
            drawConsole(grid);
            grid[posX, posY - 1] = '.';
            grid[posX + 1, posY - 1] = '.';
            grid[posX + 2, posY - 1] = '.';
            grid[posX + 1, posY - 2] = '.';
            grid[posX + 1, posY] = '.';

            oldY = posY;
            posX += rock1x(grid, instructions, ins, posX, posY);
            ins = (ins + 1) % inst;
            posY += rock1y(grid, posX, posY);
            if (oldY == posY)
            {
                grid[posX, posY - 1] = '#';
                grid[posX + 1, posY - 1] = '#';
                grid[posX + 2, posY - 1] = '#';
                grid[posX + 1, posY - 2] = '#';
                grid[posX + 1, posY] = '#';
                curheight = posY - 6;
                endloop = true;
            }

        }

    }



    if (rockType == 2)
    {
        while (endloop == false)
        {
            grid[posX, posY] = '@';
            grid[posX + 1, posY] = '@';
            grid[posX + 2, posY] = '@';
            grid[posX + 2, posY - 1] = '@';
            grid[posX + 2, posY - 2] = '@';
            drawConsole(grid);
            grid[posX, posY] = '.';
            grid[posX + 1, posY] = '.';
            grid[posX + 2, posY] = '.';
            grid[posX + 2, posY - 1] = '.';
            grid[posX + 2, posY - 2] = '.';

            oldY = posY;
            posX += rock2x(grid, instructions, ins, posX, posY);
            ins = (ins + 1) % inst;
            posY += rock2y(grid, posX, posY);
            if (oldY == posY)
            {
                grid[posX, posY] = '#';
                grid[posX + 1, posY] = '#';
                grid[posX + 2, posY] = '#';
                grid[posX + 2, posY - 1] = '#';
                grid[posX + 2, posY - 2] = '#';
                curheight = posY - 6;
                endloop = true;
            }
        }
    }



    if (rockType == 3)
    {
        while (endloop == false)
        {
            grid[posX, posY] = '@';
            grid[posX, posY - 1] = '@';
            grid[posX, posY - 2] = '@';
            grid[posX, posY - 3] = '@';
            drawConsole(grid);
            grid[posX, posY] = '.';
            grid[posX, posY - 1] = '.';
            grid[posX, posY - 2] = '.';
            grid[posX, posY - 3] = '.';

            oldY = posY;
            posX += rock3x(grid, instructions, ins, posX, posY);
            ins = (ins + 1) % inst;
            posY += rock3y(grid, posX, posY);
            if (oldY == posY)
            {
                grid[posX, posY] = '#';
                grid[posX, posY - 1] = '#';
                grid[posX, posY - 2] = '#';
                grid[posX, posY - 3] = '#';
                curheight = posY - 7;
                endloop = true;
            }
        }
    }



    if (rockType == 4)
    {
        while (endloop == false)
        {
            grid[posX, posY] = '@';
            grid[posX + 1, posY] = '@';
            grid[posX, posY - 1] = '@';
            grid[posX + 1, posY - 1] = '@';
            drawConsole(grid);
            grid[posX, posY] = '.';
            grid[posX + 1, posY] = '.';
            grid[posX, posY - 1] = '.';
            grid[posX + 1, posY - 1] = '.';

            oldY = posY;
            posX += rock4x(grid, instructions, ins, posX, posY);
            ins = (ins + 1) % inst;
            posY += rock4y(grid, posX, posY);
            if (oldY == posY)
            {
                grid[posX, posY] = '#';
                grid[posX + 1, posY] = '#';
                grid[posX, posY - 1] = '#';
                grid[posX + 1, posY - 1] = '#';
                curheight = posY - 5;
                endloop = true;
            }

        }
    }
}

Console.WriteLine(curheight);

for (int y = 4000; y < 5000; y++)
{
    for (int x = 0; x < 7; x++)
    {
        Console.Write(grid[x, y]);
    }
    Console.WriteLine();
}
Console.WriteLine((5000 - curheight - 5) + "YES");


static int rock0x(char[,] grid, char[] instructions, int ins, int posX, int posY)
{
    if (instructions[ins] == '<' && posX > 0)
    {
        if (grid[posX - 1, posY] == '.') { return -1; }
    }
    else if (instructions[ins] == '>' && (posX + 4) < 7)
    {
        if (grid[posX + 4, posY] == '.') { return 1; }
    }
    return 0;
}

static int rock1x(char[,] grid, char[] instructions, int ins, int posX, int posY)
{
    if (instructions[ins] == '<' && posX > 0)
    {
        if (grid[posX, posY] == '.' && grid[posX - 1, posY - 1] == '.' && grid[posX, posY - 1] == '.')
        { return -1; ; }
    }
    else if (instructions[ins] == '>' && (posX + 3) < 7)
    {
        if (grid[posX + 2, posY] == '.' && grid[posX + 3, posY - 1] == '.' && grid[posX + 2, posY - 3] == '.')
        { return 1; }
    }
    return 0;
}

static int rock2x(char[,] grid, char[] instructions, int ins, int posX, int posY)
{
    if (instructions[ins] == '<' && posX > 0)
    {
        if (grid[posX - 1, posY] == '.' && grid[posX + 1, posY - 1] == '.' && grid[posX + 1, posY - 2] == '.')
        { return -1; }
    }
    else if (instructions[ins] == '>' && (posX + 3) < 7)
    {
        if (grid[posX + 3, posY] == '.' && grid[posX + 3, posY - 1] == '.' && grid[posX + 3, posY - 2] == '.')
        { return 1; }
    }
    return 0;
}

static int rock3x(char[,] grid, char[] instructions, int ins, int posX, int posY)
{
    if (instructions[ins] == '<' && posX > 0)
    {
        if (grid[posX - 1, posY] == '.' && grid[posX - 1, posY - 1] == '.' && grid[posX - 1, posY - 2] == '.' && grid[posX - 1, posY - 3] == '.')
        { return -1; }
    }
    else if (instructions[ins] == '>' && (posX + 1) < 7)
    {
        if (grid[posX + 1, posY] == '.' && grid[posX + 1, posY - 1] == '.' && grid[posX + 1, posY - 2] == '.' && grid[posX + 1, posY - 3] == '.')
        { return 1; }
    }
    return 0;
}

static int rock4x(char[,] grid, char[] instructions, int ins, int posX, int posY)
{
    if (instructions[ins] == '<' && posX > 0)
    {
        if (grid[posX - 1, posY] == '.' && grid[posX - 1, posY - 1] == '.')
        { return -1; }
    }
    else if (instructions[ins] == '>' && (posX + 2) < 7)
    {
        if (grid[posX + 2, posY] == '.' && grid[posX + 2, posY - 1] == '.')
        { return 1; }
    }
    return 0;
}


static int rock0y(char[,] grid, int posX, int posY)
{
    if (grid[posX, posY + 1] != '.' || grid[posX + 1, posY + 1] != '.' || grid[posX + 2, posY + 1] != '.' || grid[posX + 3, posY + 1] != '.')
    { return 0; }
    return 1;
}
static int rock1y(char[,] grid, int posX, int posY)
{
    if (grid[posX, posY] != '.' || grid[posX + 1, posY + 1] != '.' || grid[posX + 2, posY] != '.')
    {return 0;}
    return 1;
}
static int rock2y(char[,] grid, int posX, int posY)
{
    if (grid[posX, posY + 1] != '.' || grid[posX + 1, posY + 1] != '.' || grid[posX + 2, posY + 1] != '.')
    {return 0;}
    return 1;
}
static int rock3y(char[,] grid, int posX, int posY)
{
    if (grid[posX, posY + 1] != '.')
    {return 0;}
    return 1;
}
static int rock4y(char[,] grid, int posX, int posY)
{
    if (grid[posX, posY + 1] != '.' || grid[posX + 1, posY + 1] != '.')
    {return 0;}
    return 1;
}




static void drawConsole(char[,] grid)
{
    /*
    for (int y = 4900; y < 5000; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                Console.Write(grid[x, y]);
            }
            Console.WriteLine();
        }
    Console.ReadLine();
    Console.Clear(); */
}