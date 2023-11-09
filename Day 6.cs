string input = File.ReadAllText("AoC6.txt");
char[] foundLetters = new char[14];
char newLetter = ' ';
int i = 0, count = 0;
string alphabet = "abcdefghijklmnopqrstuvwxyz";

Console.WriteLine(input.Length);
foreach(char c in input)
{
    i++;
    if (i < 15)
    {
        foundLetters[i-1] = c;
    }
    else
    {
        foreach(char s in foundLetters)
        {
            Console.Write(s);
        }
        if (foundLetters.Distinct().Count() == 14)
        { Console.WriteLine(i);
            throw new NotImplementedException(); }
        newLetter = c;
        foundLetters[0] = foundLetters[1];
        foundLetters[1] = foundLetters[2];
        foundLetters[2] = foundLetters[3];
        foundLetters[3] = foundLetters[4];
        foundLetters[4] = foundLetters[5];
        foundLetters[5] = foundLetters[6];
        foundLetters[6] = foundLetters[7];
        foundLetters[7] = foundLetters[8];
        foundLetters[8] = foundLetters[9];
        foundLetters[9] = foundLetters[10];
        foundLetters[10] = foundLetters[11];
        foundLetters[11] = foundLetters[12];
        foundLetters[12] = foundLetters[13];
        foundLetters[13] = c;
    }
        
}
