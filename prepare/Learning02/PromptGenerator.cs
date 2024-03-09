using System;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion i felt today?",
        "If i had one thing I could do over today, what would it be",
        "Did you have fun today?",
        "What did you do right today?",
        "What did you think about and why did you think about it?",
        "What are your goals"
    };

    public void AddCustomPrompt(string prompt)
    {
        _prompts.Add(prompt);
    }

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}