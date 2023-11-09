using System; //This is only part 2. I didn't save part 1, though if you have enough coding experience, you should be able to edit this code to change it accordingly.
using System.IO; //or just make it yourself. That'd be wise.

string temp = File.ReadAllText("AoC2.txt"); //Reads from file
string[] tempArray = temp.Split(' '); //Splits file into bits to add to array
string[] userChoice = new string[tempArray.Length/2];
string[] opponentChoice = new string[tempArray.Length/2];
int i = 0, uc = 0, oc = 0;
char c = ' ';
char c2 = ' ';

foreach(string a in tempArray) //adding instructions into respective arrays
{
    if(i % 2 == 0)
    {
        opponentChoice[oc] = a;
        oc++;
    }
    else
    {
        userChoice[uc] = a;
        uc++;
    }
    i++;
}
oc = 0;
 for(i = 0; i < userChoice.Length; i++) //values for each rock-paper-scissors choice
{
    Console.WriteLine(userChoice[i] + "T" + opponentChoice[i]);
    Console.WriteLine(Convert.ToChar(Convert.ToInt32(Convert.ToChar(userChoice[i])) - 23));
}

for (i = 0; i < userChoice.Length; i++) //adding score to total. I don't exactly remember this too much.
{
    c = Convert.ToChar(userChoice[i]);
    c2 = Convert.ToChar(opponentChoice[i]);

    switch (c)
    { 
        case('X'):
            oc += 1;
            switch(c2)
            {
                case ('A'):
                    oc += 2;
                    break;
                case ('C'):
                    oc += 1;
                    break;
            }
            break;
        case('Y'):
            oc += 3;
            oc += Convert.ToInt32(c2) - 64;
            break;
        case ('Z'):
            oc += 7;
            switch (c2)
            {
                case ('A'):
                    oc += 1;
                    break;
                case ('B'):
                    oc += 2;
                    break;
            }
            break;
    }
}
    
    




Console.WriteLine(oc);
