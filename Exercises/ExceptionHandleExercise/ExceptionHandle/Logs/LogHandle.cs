namespace ExceptionHandle.Logs;
public class LogHandle
{

   private readonly string _filePath;

   public LogHandle(string filePath)
    {
        _filePath = filePath;
    }

    public void Log(Exception ex)
    {
        var entrty = $@"[{DateTime.Now}],
        Execpetion:{ex.Message},
        Stack Trace: {ex.StackTrace}
        ----------------------------------------------------------------------------------

        ";
        File.AppendAllText(_filePath,entrty);
    }
    
}