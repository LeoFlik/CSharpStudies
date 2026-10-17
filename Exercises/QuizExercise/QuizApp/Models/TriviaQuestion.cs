using QuizApp;

namespace QuizApp.Models;

public class TriviaQuestion
{
    public string? question { get; set; }
    public string? correct_answer { get; set; }
    public string? difficulty { get; set; }
    public string? category { get; set; }

    public string? QuestionRevised => HtmlFixer.Fix(question ?? string.Empty);
    public string? CategoryRevised => HtmlFixer.Fix(category ?? string.Empty);


    public TriviaQuestion(string difficulty, string category, string question, string correct_answer)
    {
        this.difficulty = difficulty;
        this.category = category;
        this.question = question;
        this.correct_answer = correct_answer;
    }
}
