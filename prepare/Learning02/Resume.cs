using System;

public class Resume
{
    public string _personName;

    public List<Job> _jobs = new List<Job>();

    public Resume()
    {
        _jobs = new List<Job>();
    }

    public void DisplayResumeDetails()
    {
        Console.WriteLine($"Person's Name: {_personName}");
        Console.WriteLine("Jobs:");
        
        foreach (Job job in _jobs)
        {
            job.DisplayJobDetails();
        }
    }
}