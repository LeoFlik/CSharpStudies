using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandle.DataAccess;

public class DataRepository : IDataRepository
{
    private readonly IStringReader _stringReader;

    public DataRepository(IStringReader stringReader)
    {
        _stringReader =stringReader;
    }
    public void HandleExcp()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Game> Read(string fileToCheck)
    {
        if (ValidateFile(fileToCheck))
        {
            return _stringReader.Read(fileToCheck);
        }
        return new List<Game>();
          
    }

    public bool ValidateFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return false;
        }
        return true;
    }


  
}
