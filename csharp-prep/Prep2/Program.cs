using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        Console.Write("What is your grade percentage?: ");
        string inputFromUser = Console.ReadLine();
        int percentage = int.Parse(inputFromUser);

        string letter = "";
        if (percentage >= 90)
        {
            letter = "A";
        }

        else if (percentage >= 80)
        {
            letter = "B";
        }

        else if (percentage >= 70)
        {
            letter = "C";
        }

        else if (percentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        string sign = "";
        if ((percentage % 10) >= 7)
        {
            sign = "+";
        }
        else if ((percentage % 10) < 3)
        {
            sign = "-";
        }

        if (letter == "A" && sign == "+")
        {
            letter = "A";
            sign = "-";
        }
        else if (letter == "F" && (sign == "+" || sign == "-"))
        {
            letter = "F";
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (percentage >= 70)
        {
            Console.WriteLine("You passed!!!");
        }

        else 
        {
            Console.WriteLine("You can do better, try again.");
        }

    
    }
}