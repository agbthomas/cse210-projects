using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");
        
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son, that whoever believes in him should not perish but have eternal life.");

        
        DisplayScripture(scripture);

        
        while (!scripture.AllWordsHidden)
        {
            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            HideWords(scripture);
            DisplayScripture(scripture);
        }

        Console.WriteLine("Program ended.");
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.ToString());
    }

    static void HideWords(Scripture scripture)
    {
        Random random = new Random();
        List<Word> visibleWords = scripture.Words.Where(w => !w.Hidden).ToList();
        int wordsToHide = Math.Min(visibleWords.Count, random.Next(1, 4));

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(0, visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }
}

class Scripture
{
    public string Reference { get; }
    public string Text { get; }
    public List<Word> Words { get; }

    public bool AllWordsHidden => Words.All(w => w.Hidden);

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public override string ToString()
    {
        return $"{Reference}: {string.Join(" ", Words)}";
    }
}

class Word
{
    public string Text { get; }
    public bool Hidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        Hidden = false;
    }

    public void Hide()
    {
        Hidden = true;
    }

    public override string ToString()
    {
        return Hidden ? new string('*', Text.Length) : Text;
    }
}