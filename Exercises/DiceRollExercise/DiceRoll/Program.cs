using DiceRoll.Entities;
using DiceRoll.Services;

GameManager gameManager = new GameManager(new UserInterfaceService(), new Dice());

Console.WriteLine("Hello! Welcome to the Dice Roll Game!");
Console.WriteLine("Try to guess the number rolled on the dice!");
gameManager.StartGame();
