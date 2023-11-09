using System.Text.RegularExpressions;
using System.Collections.Generic;

string[] file = File.ReadAllLines("AoC5.txt"); //Declaration of variables
string[] file2 = File.ReadAllLines("AoC5(2).txt");
int c = 1;
string text = "";
string[] move = new string[3];
int listval = 0;

List<string>[] list = new List<string>[30];//Declares a List Array
for (int i = 0; i < list.Length; i++)
{
    list[i] = new List<string>();
}

foreach (string s in file2)
{
    for (int i = 0; i < (list.Length*2-1); i += 2)
    {
        if (s.Substring(i, 1) != " ")
        {
            list[i / 2].Add(s.Substring(i, 1));
        }
    }
    c++;
} //Stores the values from the file into the list array (file2 contents)

c = 0;
foreach(List<string> l in list) 
{
    list[c].Reverse();
    c++;

} //Reverses the list, and also counts how many values are in every list, for whatever reason
Console.WriteLine(listval);
listval = 0;

foreach (string s in file)
{
    Console.WriteLine("-----------------------------------------------------");
    text = (Regex.Replace(s, @"[a-z]", "")).TrimStart(' ');
    move = text.Split("  ");
    text = "";
    for (int i = 0; i < Convert.ToInt32(move[0]); i++)
    {
        foreach (string f in list[Convert.ToInt32(move[1]) - 1])
        {
            listval++;
        }//counts the amount of elements in the list
        text += list[Convert.ToInt32(move[1]) - 1].Last();
        list[Convert.ToInt32(move[1]) - 1].RemoveAt(listval-1);
        listval = 0;
    }//Moves crates around

    char[] array = text.ToCharArray(); //Part 2 code; appends the position of the crates, but does it for multiple at once
    Array.Reverse(array); // Yeah, Part 2's code is incredibly easy to code in bruh
    text = new string(array);

    Console.WriteLine(text);
    foreach(char ch in text)
    {
        list[Convert.ToInt32(move[2]) - 1].Add(Convert.ToString(ch));
    }
    foreach (List<string> l in list)
    {
        foreach (string s2 in l)
        { Console.Write("[" + s2 + "]"); }
        Console.WriteLine();
    }//Outputting the crates; doesn't do much, just displays it for debugging
} //Part 1 code; appends the position of the crates (1 crate at a time) also includes Part 2 code
bool check = false;

foreach (List<string> l in list)
{
        Console.Write(l.Last());
} //Outputs the final solution because I'm lazy and can't add it up myself