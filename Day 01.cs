using System;
using System.Collections.Generic;
using System.IO;

#region Part 1 //This is effectively just finding max
Console.WriteLine("Day 1 - Part 1:");
string[] input = File.ReadAllLines("AdventOfCode_Day1.txt"); //reads from the file
List<int> totals = new List<int>();
int total = 0;

foreach (string calorie in input)
{

    Console.WriteLine(calorie + ", this is a variable in the input array"); //debug message

    if (calorie.Length >= 4) //filters out shorter calories
    { total += int.Parse(calorie.Trim(' ')); }
    else
    {
        totals.Add(total);
        total = 0;
    }
}

totals.Sort((a, b) => {
    return b - a;
}); // sort list DESC
Console.WriteLine(totals[0]);
#endregion

#region Part 2
Console.WriteLine("Day 1 - Part 2:");
Console.WriteLine(totals[0] + totals[1] + totals[2]);
#endregion
