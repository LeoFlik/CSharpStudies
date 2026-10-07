
namespace DiceRoll.Services;

public class UserInterfaceService
{

    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }
    public int GetUserInput()
    {
        Console.Write("Enter your guess (1-6): ");
        int input;
        while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 6)
        {
            Console.Write("Invalid input. Please enter a number between 1 and 6: ");
        }
        return input;
    }

    public string DisplayResult(bool isCorrect, int rolledValue)
    {
        if (isCorrect)
        {
            return $"Congratulations! You guessed correctly. The dice rolled: {rolledValue}.";
        }
        else
        {
            return $"Sorry, your guess was incorrect";
        }
    }
  
}
