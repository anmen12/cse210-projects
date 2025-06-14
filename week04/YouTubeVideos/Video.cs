public class Video
{
    private List<Comment> _comments = new List<Comment>();
    private string _title;
    private string _author;
    private int _seconds;

    public Video(string title, string author, int seconds)
    {
        _title = title;
        _author = author;
        _seconds = seconds;
    }

    public List<string> GetDisplayText()
    {
        List<string> displayText = new List<string>();
        displayText.Add(_title + " - " + _author + " (" + _seconds + " Seconds) : " + GetNumberOfComments() + " Comments");
        foreach (Comment comment in _comments)
        {
            displayText.Add(comment.GetDisplayText());
        }
        return displayText;
    }
    public void AddComment(string author, string text)
    {
        _comments.Add(new Comment(author, text));
    }
    private int GetNumberOfComments()
    {
        return _comments.Count;
    }
}