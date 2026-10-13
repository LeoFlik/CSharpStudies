using ExceptionHandle;
using ExceptionHandle.App;
using ExceptionHandle.DataAccess;
using ExceptionHandle.Logs;

var logHandle = new LogHandle("log.txt");

var exceptionHandleApp = new ExceptionHandleApp(new ConsoleUserInteration(),
new DataRepository(new JsonFileHandler()),new PrintResults());

try
{
    exceptionHandleApp.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Sorry,the application has to been closed due to an unexpected error!");
    logHandle.Log(ex);
    
}




