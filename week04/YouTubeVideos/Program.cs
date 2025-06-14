using System;

class Program
{
    static List<string> titles =   ["5 Epic Dance Moves",
                                    "You'll Never Believe What This Is",
                                    "The Strangest Object in The World",
                                    "10 Mysterious Places",
                                    "How to build a rocket",
                                    "Fixing an iPhone 9",
                                    "Random Facts You May Not Know"];
    static List<string> usernames =    ["user",
                                        "ninja",
                                        "coder",
                                        "collector",
                                        "strnager",
                                        "soldier"];
    static List<string> comments = ["Cool Video!",
                                    "Bad Video :(",
                                    "Too short",
                                    "Too long",
                                    "Epic!",
                                    "Awesome!"];
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Random randomGenerator = new Random();

        //create videos
        for (int i = randomGenerator.Next(0, 2); i < 4; i++)
        {
            videos.Add(new Video(GetRandomTitle(), GetRandomUsername(), GetRandomSeconds()));
        }
        //create comments
        foreach (Video video in videos)
        {
            for (int i = randomGenerator.Next(0, 2); i < 4; i++)
            {
                video.AddComment(GetRandomUsername(), GetRandomComment());
            }
        }
        //print videos and comments
        foreach (Video video in videos)
        {
            foreach (string line in video.GetDisplayText())
            {
                Console.WriteLine($"{line}"); ;
            }
        }
    }

    static string GetRandomTitle()
    {
        Random randomGenerator = new Random();
        return titles[randomGenerator.Next(0, titles.Count)];
    }
    static string GetRandomUsername()
    {
        Random randomGenerator = new Random();
        return usernames[randomGenerator.Next(0, usernames.Count)] + randomGenerator.Next(0, 10000);
    }
    static int GetRandomSeconds()
    {
        Random randomGenerator = new Random();
        return randomGenerator.Next(1, 3601);
    }
    static string GetRandomComment()
    {
        Random randomGenerator = new Random();
        return comments[randomGenerator.Next(0, comments.Count)];
    }
}