using ExceptionHandle.DataAccess;

namespace ExceptionHandle.App
{
   public interface IConsoleUserInteraction
    {
        void Exit();
        string ReadUserInput();
        void ShowMessage(string v);
       
    }
}