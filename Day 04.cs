string[] input = File.ReadAllLines("Aoc4.txt");
string[] num = new string[4];
int i = 0;
int val = 0;
for(i = 0; i < input.Length; i++)
{
    num =  input[i].Split('-', ',');
    /* if (Convert.ToInt32(num[0]) <= Convert.ToInt32(num[2]) && Convert.ToInt32(num[1]) >= Convert.ToInt32(num[3]))
    {
        val++;
    }
    else if (Convert.ToInt32(num[2]) <= Convert.ToInt32(num[0]) && Convert.ToInt32(num[3]) >= Convert.ToInt32(num[1]))
    {
        val++;
    }    */ //Part 1
    Console.WriteLine(input[i]);
    if (Convert.ToInt32(num[1]) >= Convert.ToInt32(num[2]) && Convert.ToInt32(num[0]) <= Convert.ToInt32(num[3]))
    {
        val++;
    }
}

Console.WriteLine(val);
