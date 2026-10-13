using ExceptionHandle.DataAccess;

namespace ExceptionHandle.App
{
    public interface IPrintResults
    {

        public void PrintGamesInfo(IEnumerable<Game> games);
    }
}