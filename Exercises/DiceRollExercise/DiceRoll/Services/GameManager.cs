using DiceRoll.Entities;

namespace DiceRoll.Services;

public class GameManager
{
    private readonly int _maxAttempts = 3;
    private UserInterfaceService _userInterfaceService;
    private Dice _dice;

    public GameManager(UserInterfaceService userInterfaceService, Dice dice)
    {
        _userInterfaceService = userInterfaceService;
        _dice = dice;
    }


    public void StartGame()
    {
        int attempts = 0;
        bool isCorrect = false;
        int rolledValue = _dice.Roll();
        while (attempts < _maxAttempts && !isCorrect)
        {
            int userGuess = _userInterfaceService.GetUserInput();
            isCorrect = userGuess == rolledValue;
            string resultMessage = _userInterfaceService.DisplayResult(isCorrect, rolledValue);
            Console.WriteLine(resultMessage);
            attempts++;
            if(isCorrect)
            {
                RestartGame();
                break;
            }
            else
            {
                Console.WriteLine($"Attempts left: {_maxAttempts - attempts}");
            }
        }

        if (!isCorrect && attempts >= _maxAttempts)
        {
            Console.WriteLine("Game over! You've used all your attempts.");
            Console.WriteLine($"The correct number was: {rolledValue}");
            GameOver();
            RestartGame();
        }


    }
    public void GameOver()
    {
        Console.WriteLine();
        Console.WriteLine("Thank you for playing the Dice Roll Game!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public void RestartGame()
    {
        Console.WriteLine();
        Console.WriteLine("Do you want to play again? (y/n)");
        string? input = Console.ReadLine();
        if (input?.ToLower() == "y")
        {
            StartGame();
        }
        else
        {
            GameOver();
        }
    }
}
