using System.Text.Json;
using ExceptionHandle.DataAccess;

namespace ExceptionHandle.App
{
    public class ExceptionHandleApp
    {
        private readonly IConsoleUserInteraction _consoleUserInteraction;
        private readonly IDataRepository _dataRepository;
        private readonly IPrintResults _printResults;

        public ExceptionHandleApp(IConsoleUserInteraction userInteraction,
        IDataRepository dataRepository,IPrintResults printResults)
        {
            _consoleUserInteraction = userInteraction;
            _dataRepository = dataRepository;
            _printResults = printResults;
        }
        public void Run()
        {
            var fileToRead = _consoleUserInteraction.ReadUserInput();
            var files = _dataRepository.Read(fileToRead);
            _printResults.PrintGamesInfo(files);
            _consoleUserInteraction.Exit();
        }
    }
}