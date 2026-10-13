using ExceptionHandle.DataAccess;

namespace ExceptionHandle.App
{
    public class PrintResults:IPrintResults,IPrintMessages
    {
         public void PrintGamesInfo(IEnumerable<Game> games)
        {

            if (games.Count() > 0)
            {
                ShowMessage("Loaded Games are:");
                foreach (var game in games)
                {
                    ShowMessage(game.ToString());
                }
            }
            else
            {
                ShowMessage("There are no games to print");
            }
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine("Messages");
        }
    }
}