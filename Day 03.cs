// See https://aka.ms/new-console-template for more information
string t1 = File.ReadAllText("AoC3.txt");
string t2 = "";
string t3 = "";
string[] textArray = t1.Split("\n");
int val = 0;

foreach(string t in textArray) // Part 1
{
    if (t.Length > 2)
    {
        t1 = t.Substring(0, t.Length / 2);
        t2 = t.Substring((t.Length / 2), t.Length/2);

        foreach(char c in t1)
        {
            if(t2.Contains(c))
            {
                if (char.ToUpper(c) == c)
                    { val += Convert.ToInt32(c) - 38; }
                else
                    { val += Convert.ToInt32(c) - 96; }
                break;
            }
        }
    }
} 

Console.WriteLine(val);
val = 0;

string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 
for(int i = 0; i < textArray.Length; i++) // Part 2
{
    if ((i + 1)% 3 == 1)
        { t1 = textArray[i]; }
    else if((i + 1)% 3 == 2)
        { t2 = textArray[i];}
    else
    {
        t3 = textArray[i];
        foreach (char c in alphabet)
        {
           if(t1.Contains(c) == true && t2.Contains(c) == true && t3.Contains(c) == true)
            {
                if (char.ToUpper(c) == c)
                    { val += Convert.ToInt32(c) - 38; }
                else
                    { val += Convert.ToInt32(c) - 96; }
                break;
            }
        }
    }
}

Console.WriteLine(val);
