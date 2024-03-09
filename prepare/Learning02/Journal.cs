using System;
using Microsoft.Win32.SafeHandles;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                sw.WriteLine(entry.Date);
                sw.WriteLine(entry.Prompt);
                sw.WriteLine(entry.Response);
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader sr = new StreamReader(filename))
        {
            while (!sr.EndOfStream)
            {
                DateTime date = DateTime.Parse(sr.ReadLine());
                string prompt = sr.ReadLine();
                string response = sr.ReadLine();
                Entry entry = new Entry(prompt, response, date);
                _entries.Add(entry);
            }
        }
    }
}