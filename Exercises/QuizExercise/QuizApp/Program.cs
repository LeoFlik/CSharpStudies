using QuizApp.Models;
using System.Text.Json;
using System.Net.Http;

var client = new HttpClient();
var triviaPath = "https://opentdb.com/api.php?amount=15&type=boolean";
var response = await client.GetAsync(triviaPath);
string filesContent = "";
if (response.IsSuccessStatusCode)
{
    filesContent = await response.Content.ReadAsStringAsync();
}
else
{
    Console.WriteLine($"An Error Occour: {response.StatusCode}");
}


//var path = Path.Combine(AppContext.BaseDirectory, "questions.json");

//var filesContent = File.ReadAllText(path);
var data = JsonSerializer.Deserialize<TriviaResponse>(filesContent) ?? new();
var index = 0;
var score = 0;
while (index < data.results.Count)
{
    Console.WriteLine($"Trivia Level: {data.results[index].difficulty?.ToUpper() ?? "UNKNOWN"}");
    Console.WriteLine($"Trivia Category: {data.results[index].CategoryRevised}");
    Console.Write($"Q.{index + 1}: {data.results[index].QuestionRevised}(True or False):");
    var userInput = Console.ReadLine();
    if (userInput == data.results[index].correct_answer)
    {
        Console.WriteLine("You got the correct answer!");
        score++;
    }
    else
    {
        Console.WriteLine("Ops, wrong answer!");
    }
    Console.WriteLine($"The correct answer is: {data.results[index].correct_answer}");
    Console.WriteLine($"Your score is: {score.ToString("D2")}/{data.results.Count}");
    Console.WriteLine();
    ++index;


}
Console.WriteLine("End of Game!");
Console.WriteLine($"Your final score was: {score.ToString("D2")}/{data.results.Count}");
Console.WriteLine($"{Result(score)}!!");
Console.WriteLine("Press any key to exit the application");
Console.ReadKey();
static string Result(int score) => score switch
{
    >=10 => "Nerd!!",
    >=7 =>"You know a lot about it",
    >=5 =>"Not bad",
    _ =>"You are patetic!"
};








