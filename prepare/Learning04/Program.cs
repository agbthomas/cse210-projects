using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!");
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            int choice = GetChoice(1, 4);

            switch (choice)
            {
                case 1:
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.StartActivity();
                    break;
                case 2:
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.StartActivity();
                    break;
                case 3:
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.StartActivity();
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    return;
            }
        }
    }

    static int GetChoice(int min, int max)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < min || choice > max)
        {
            Console.WriteLine("Invalid input. Please enter a number between {0} and {1}.", min, max);
        }
        return choice;
    }
}

abstract class MindfulnessActivity
{
    public int Duration { get; set; }

    public abstract void StartActivity();

    protected void CommonStartingMessage(string activityName, string description)
    {
        Console.WriteLine("Starting {0} Activity:", activityName);
        Console.WriteLine(description);
        Console.WriteLine("Enter the duration of the activity in seconds:");
        Duration = GetPositiveInteger();
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected void CommonEndingMessage(string activityName)
    {
        Console.WriteLine("Well done! You have completed the {0} Activity for {1} seconds.", activityName, Duration);
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    protected int GetPositiveInteger()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
        return value;
    }
}

class BreathingActivity : MindfulnessActivity
{
    public override void StartActivity()
    {
        CommonStartingMessage("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < Duration; i++)
        {
            Console.WriteLine(i % 2 == 0 ? "Breathe in..." : "Breathe out...");
            Thread.Sleep(1000); // Pause for 1 second
        }

        CommonEndingMessage("Breathing");
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private string[] prompts = new string[]
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = new string[]
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void StartActivity()
    {
        CommonStartingMessage("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);

        foreach (string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000); // Pause for 3 seconds
        }

        CommonEndingMessage("Reflection");
    }
}

class ListingActivity : MindfulnessActivity
{
    private string[] prompts = new string[]
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void StartActivity()
    {
        CommonStartingMessage("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("Press Enter to start listing...");
        Console.ReadLine();

        Console.WriteLine("Start listing items...");

        // Simulate listing items for the specified duration
        Thread.Sleep(Duration * 1000);

        Console.WriteLine("You listed {0} items.", Duration);
        CommonEndingMessage("Listing");
    }
}
