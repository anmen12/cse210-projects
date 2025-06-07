public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (string word in words)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random randomGenerator = new Random();
        for (int i = 0; i <= numberToHide; i++)
        {
            if (!IsCompletelyHidden())
            {
                int wordToHide = 0;
                while (wordToHide != -1)
                {
                    wordToHide = randomGenerator.Next(0, _words.Count);
                    if (!_words[wordToHide].IsHidden())
                    {
                        _words[wordToHide].Hide();
                    }
                    else
                    {
                        wordToHide = -1;
                    }
                }
            }
            else
            {
                break;
            }
        }
    }
    public string GetDisplayText()
    {
        string fullText = "";
        fullText += _reference.GetDisplayText() + " ";
        Console.WriteLine($"{_words}");
        foreach (Word word in _words)
        {
            fullText += word + " ";
        }
        return fullText;
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}