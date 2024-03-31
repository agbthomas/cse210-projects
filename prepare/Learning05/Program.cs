using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create an instance of the game
        EternalQuestGame game = new EternalQuestGame();

        // Run the game
        game.Run();
    }
}

class EternalQuestGame
{
    private List<Goal> goals = new List<Goal>();
    private int score = 0;

    public void Run()
    {
        bool running = true;
        while (running)
        {
            // Display menu
            Console.WriteLine("1. Add goal");
            Console.WriteLine("2. Record event");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Show score");
            Console.WriteLine("5. Save goals and score");
            Console.WriteLine("6. Load goals and score");
            Console.WriteLine("7. Quit");

            // Get user input
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddGoal();
                    break;
                case 2:
                    RecordEvent();
                    break;
                case 3:
                    ShowGoals();
                    break;
                case 4:
                    ShowScore();
                    break;
                case 5:
                    SaveGoalsAndScore();
                    break;
                case 6:
                    LoadGoalsAndScore();
                    break;
                case 7:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private void AddGoal()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Eternal");
        Console.WriteLine("3. Checklist");

        int type = int.Parse(Console.ReadLine());

        Goal goal;
        switch (type)
        {
            case 1:
                goal = new SimpleGoal(name);
                break;
            case 2:
                goal = new EternalGoal(name);
                break;
            case 3:
                Console.WriteLine("Enter number of times to complete:");
                int times = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, times);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(goal);
    }

    private void RecordEvent()
    {
        Console.WriteLine("Enter goal name:");
        string name = Console.ReadLine();

        Goal goal = goals.Find(g => g.Name == name);
        if (goal != null)
        {
            goal.Complete();
            score += goal.GetPoints();
            Console.WriteLine("Event recorded.");
        }
        else
        {
            Console.WriteLine("Goal not found.");
        }
    }

    private void ShowGoals()
    {
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.ToString());
        }
    }

    private void ShowScore()
    {
        Console.WriteLine("Score: " + score);
    }

    private void SaveGoalsAndScore()
    {
        // Save goals and score to a file
    }

    private void LoadGoalsAndScore()
    {
        // Load goals and score from a file
    }
}

abstract class Goal
{
    public string Name { get; }
    protected bool completed;

    public Goal(string name)
    {
        Name = name;
        completed = false;
    }

    public abstract void Complete();

    public abstract int GetPoints();

    public override string ToString()
    {
        return Name + (completed ? " [X]" : " [ ]");
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name) : base(name)
    {
    }

    public override void Complete()
    {
        completed = true;
    }

    public override int GetPoints()
    {
        return 1000;
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name) : base(name)
    {
    }

    public override void Complete()
    {
        // Eternal goals are never completed
    }

    public override int GetPoints()
    {
        return 100;
    }
}

class ChecklistGoal : Goal
{
    private int times;
    private int completedTimes = 0;

    public ChecklistGoal(string name, int times) : base(name)
    {
        this.times = times;
    }

    public override void Complete()
    {
        completedTimes++;
        if (completedTimes >= times)
        {
            completed = true;
        }
    }

    public override int GetPoints()
    {
        if (completed)
        {
            return 500;
        }
        else
        {
            return 50;
        }
    }

    public override string ToString()
    {
        return Name + " Completed " + completedTimes + "/" + times + " times";
    }
}
