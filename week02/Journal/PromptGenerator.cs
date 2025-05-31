public class PromptGenerator
{
    public List<string> _prompts = ["Who was the most interesting person I interacted with today?",
                                    "What was the best part of my day?",
                                    "How did I see the hand of the Lord in my life today?",
                                    "What was the strongest emotion I felt today?",
                                    "If I had one thing I could do over today, what would it be?",
                                    "What was one thing I am grateful for today?",
                                    "What was one thing I forgot to do today?",
                                    "What was a scripture that I found impactful today and How so?",
                                    "How much did I exercise today?",
                                    "How closely did I follow my schedule today?"];

    public string GetRandomPrompt()
    {
        Random randomGenerator = new Random();
        return _prompts[randomGenerator.Next(0, _prompts.Count)];
    }
}