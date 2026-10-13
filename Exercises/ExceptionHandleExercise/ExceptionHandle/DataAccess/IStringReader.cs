using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionHandle.DataAccess
{
    public interface IStringReader
    {
        List<Game> Read(string filePath);

    }
}