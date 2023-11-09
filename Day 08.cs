using System;

// See https://aka.ms/new-console-template for more information
string[] file = File.ReadAllLines("AoC8.txt");
char[,] grid = new char[file.Length, file[0].Length];
int x=0, y = 0;
int i = 0, bruh = 0, val = 0, max = 0;

foreach (string s in file)
{
    Console.WriteLine(s);
}

foreach(string s in file)
{
    foreach(char c in s)
    {
        grid[x,y] = c;
        x++;
    }
    x = 0;
    y++;
} //puts the data into a 2D array


string div1 = "", div2 = ""; // Console.ReadLine();

if (div1 == "1")
{
    for (int iy = 0; iy < y; iy++)
    {
        for (int ix = 0; ix < x; ix++)
        {
            if (iy > 0 && iy < y - 1 && ix > 0 && ix < x - 1)
            {
                for (i = 0; i < ix; i++) { div1 += grid[i, iy]; }
                for (i = i + 1; i < x; i++) { div2 += grid[i, iy]; }
                bruh = Convert.ToInt32(Char.GetNumericValue(grid[ix, iy]));
                if (bruh > Char.GetNumericValue(div2.ToCharArray().Max()) || bruh > Char.GetNumericValue(div1.ToCharArray().Max()))
                {val++;}
                else
                {
                    div1 = "";
                    div2 = "";
                    for (i = 0; i < iy; i++) { div1 += grid[ix, i]; }
                    for (i = i + 1; i < y; i++) { div2 += grid[ix, i]; }
                    if (bruh > Char.GetNumericValue(div2.ToCharArray().Max()) || bruh > Char.GetNumericValue(div1.ToCharArray().Max()))
                    {val++;}
                }
                div1 = "";
                div2 = "";
            }
            else
            {
                val++;
            }
        }
    }
} // Part 1

string div3 = "", div4 = "";
string temp = "";
int[] total = new int[4];

for (int iy = 0; iy < y; iy++)
{
    for (int ix = 0; ix < x; ix++)
    {
        for (i = 0; i < ix; i++) { div1 += grid[i, iy]; }
        for (i = i + 1; i < x; i++) { div2 += grid[i, iy]; }
        for (i = 0; i < iy; i++) { div3 += grid[ix, i]; }
        for (i = i + 1; i < y; i++) { div4 += grid[ix, i]; }

        temp = div1;
        div1 = "";

        foreach(char a in temp.ToCharArray().Reverse()) {div1 += a;}

        temp = div3;
        div3 = "";

        foreach (char a in temp.ToCharArray().Reverse()) {div3 += a;}

        bruh = Convert.ToInt32(Char.GetNumericValue(grid[ix, iy]));
        total[0] = treeChecker(div1, bruh);
        total[1] = treeChecker(div2, bruh);
        total[2] = treeChecker(div3, bruh);
        total[3] = treeChecker(div4, bruh);

        div1 = "";
        div2 = "";
        div3 = "";
        div4 = "";

        val = total[0] * total[1] * total[2] * total[3];
        if(max < val) {max = val;}

    }
} // Part 2

static int treeChecker(string div, int bruh)
{
    int treeMax = bruh;
    int total = 1;
    if (div.Length <= 1) {return div.Length;}
    foreach (char c in div)
    {
            if (treeMax > Char.GetNumericValue(c))
            {
                total++;
            }
            else {return total;}
     
    }
    return div.Length;
} //Checks trees to see if they can see over other trees

Console.WriteLine(max);
