// i added a feature for customisable prompts to my code in my promptGenerator.
using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 World!");
        // Job job1 = new Job();

        // job1._jobTitle = "Software Engineer";
        // job1._company = "Microsoft";
        // job1._startYear = 2022;
        // job1._endYear = 2023;

        

        // Job job2 = new Job();

        // job2._jobTitle = "Manager";
        // job2._company = "Apple";
        // job2._startYear = 2023;
        // job2._endYear = 2024;

        // Resume resume = new Resume();
        // resume._personName = "Thomas Agbese";

        // resume._jobs.Add(job1);
        // resume._jobs.Add(job2);

        // resume.DisplayResumeDetails();
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        bool running = true;
        while (running)
        {
            Console.WriteLine("1: Write a new entry");
            Console.WriteLine("2: Display the Journal");
            Console.WriteLine("3: Save the journal to a file");
            Console.WriteLine("4: Load Joural from a file");
            Console.WriteLine("5: Exit");
            Console.Write("Enter your choice here: ");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    Entry entry = new Entry(prompt, response, DateTime.Now);
                    journal.AddEntry(entry);
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    Console.Write("Enter Filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case 5:
                    Console.Write("Thank you for writing today, Good Bye!!!");
                    running = false;
                    break;


            }

        }
    }
}