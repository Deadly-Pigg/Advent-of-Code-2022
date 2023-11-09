string[] file = File.ReadAllLines("AoC18.txt");
int c = 0;
int surfaceArea = file.Length * 6;
int[] cubeX = new int[file.Length];
int[] cubeY = new int[file.Length];
int[] cubeZ = new int[file.Length];

foreach (string line in file)
{
    string[] coords = line.Split(',');
    for (int i = 0; i < 3; i++)
    {
        switch (i % 3)
        {
            case 0:
                cubeX[c] = Convert.ToInt32(coords[i]);
                break;
            case 1:
                cubeY[c] = Convert.ToInt32(coords[i]);
                break;
            case 2:
                cubeZ[c] = Convert.ToInt32(coords[i]);
                break;
                
        }
    }
    Console.WriteLine(cubeX[c] + "," + cubeY[c] + "," + cubeZ[c]);
    c++;
}

for (int i = 0; i < file.Length; i++)
{
    surfaceArea -= Compare(cubeX, cubeY, cubeZ, i);
    surfaceArea -= Compare(cubeY, cubeZ, cubeX, i);
    surfaceArea -= Compare(cubeX, cubeZ, cubeY, i);
} //part 1 sol

static int Compare(int[] cube1, int[] cube2, int[] cube3, int i)
{
    int val = 0;

    for(int j = 0; j < cube1.Length; j++)
    {
        if (cube1[i] == cube1[j] && cube2[i] == cube2[j] && Math.Abs(cube3[i] - cube3[j]) == 1)
        { val++; }
    }

    return val;
} //part 1 sol

Console.WriteLine(surfaceArea + " is the surface area (part 1)");



// surfaceArea = file.Length * 6;




