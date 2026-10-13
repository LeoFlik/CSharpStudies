using System.Text.Json;

namespace ExceptionHandle.DataAccess
{
    public class JsonFileHandler : IStringReader
    {
        public List<Game> Read(string filePath)
        {
                 var fileContents = File.ReadAllText(filePath);
            try
            {
                 return JsonSerializer.Deserialize<List<Game>>(fileContents)?? new List<Game>();
            }
            catch(JsonException ex)
            {
                throw new JsonException($"{ex.Message}. The file is:{filePath}",
                ex);
            }
           
        }

    }
}