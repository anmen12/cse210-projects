using System;
using System.Formats.Asn1;

class Program
{
    static List<List<String>> Scriptures = [["Matthew", "2", "1", "Now when Jesus was born in Bethlehem of Judæa in the days of Herod the king, behold, there came wise men from the east to Jerusalem"],
                                            ["Matthew", "2", "2", "Saying, Where is he that is born King of the Jews? for we have seen his star in the east, and are come to worship him"]];
    static void Main(string[] args)
    {
        //create scriptures
        List<Scripture> matthew1 = new List<Scripture>();
        foreach (List<String> verse in Scriptures)
        {
            matthew1.Add(new Scripture(new Reference(verse[0], int.Parse(verse[1]), int.Parse(verse[2])), verse[3]));
        }

        string answer = " ";
        while (answer != "quit")
        {
            Console.Clear();
            DisplayVerse(matthew1[0]);
            answer = Console.ReadLine();
            if (answer == "")
            {
                matthew1[0].HideRandomWords(1);
            }
        }
    }

    static void DisplayVerse(Scripture scripture)
    {
        Console.WriteLine($"{scripture.GetDisplayText()}");
    }
}