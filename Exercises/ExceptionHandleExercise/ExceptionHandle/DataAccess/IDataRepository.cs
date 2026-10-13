namespace ExceptionHandle.DataAccess;


public interface IDataRepository
{

  IEnumerable<Game> Read(string fileToCheck);
  bool ValidateFile(string fileTocheck);
}
