
using ExceptionHandle.DataAccess;

namespace ExceptionHandle.App
{
    public class ConsoleUserInteration : IConsoleUserInteraction
    {
        const string FileExtension = "json";

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }


        public void Exit()
        {
            Console.WriteLine();
            Console.Write("Press any key to exit the application.");
            Console.ReadKey();
        }

        public string ReadUserInput()
        {
            string userInput = string.Empty;
            bool isValid = false;
            do
            {
                ShowMessage("Enter the name of file you want to read:");
                userInput = Console.ReadLine();
                if (userInput is null)
                {
                    ShowMessage("The file cannot be null");
                }
                else if (userInput.Length <= 0)
                {
                    ShowMessage("The file cannot be empty");
                }
                else if (!userInput.EndsWith(FileExtension))
                {
                    ShowMessage("File not found");
                }
                else
                {
                    isValid = true;
                }
            }
            while (!isValid);
            return userInput;
        }

       
    }
}
