using System;
using System.Collections.Generic;

// Interface for a video
interface IVideo
{
    string Title { get; set; }
    string Author { get; set; }
    int LengthInSeconds { get; set; }
    List<IComment> Comments { get; set; }

    int GetNumberOfComments();
}

// Interface for a comment
interface IComment
{
    string CommenterName { get; set; }
    string CommentText { get; set; }
}

// Video class implementing IVideo interface
class Video : IVideo
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public List<IComment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<IComment>();
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}


class Comment : IComment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class YouTubeVideoManager
{
    static void Main()
    {
        List<IVideo> videos = new List<IVideo>();

        // Create videos and add comments
        IVideo video1 = new Video("Program Essentials", "Ibrahim Soto", 120);
        video1.Comments.Add(new Comment("James", "Great video!"));
        video1.Comments.Add(new Comment("Nasiru", "Interesting topic."));
        video1.Comments.Add(new Comment("Grace", "Thanks so much for this."));
        video1.Comments.Add(new Comment("Oladeji", "There probably are books that explain it better than this."));

        IVideo video2 = new Video("Programming like a Pro", "James Ahmed", 180);
        video2.Comments.Add(new Comment("Alex", "I learned a lot."));
        video2.Comments.Add(new Comment("Emmanuel", "Could be better."));
        video2.Comments.Add(new Comment("Brian", "This is it guys."));

        IVideo video3 = new Video("Software Engineering", "Alexis Sanchez", 134);
        video3.Comments.Add(new Comment("Cynthia", "I learned a lot."));
        video3.Comments.Add(new Comment("Lisa", "not bad Could be better."));
        video3.Comments.Add(new Comment("Noris", "Could you possibly make a timelapse video of this too?"));

        IVideo video4 = new Video("Learn CAD", "Emmanuel Fortress", 168);
        video4.Comments.Add(new Comment("Seyi", "I learned a lot, but can you talk more about it."));
        video4.Comments.Add(new Comment("Ameer", "Most concepts have not been talked about"));
        video4.Comments.Add(new Comment("Bashir", "I prefer revit to this, this looks really slow"));
        video4.Comments.Add(new Comment("Maxwell", "was really good but you didn't follow design principles while doing it."));



        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        
        foreach (var video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length (seconds): " + video.LengthInSeconds);
            Console.WriteLine("Number of comments: " + video.GetNumberOfComments());

            foreach (var comment in video.Comments)
            {
                Console.WriteLine("Comment by " + comment.CommenterName + ": " + comment.CommentText);
            }

            Console.WriteLine();
        }
    }
}