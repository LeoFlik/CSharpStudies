

namespace CookieRecipeBook.DataAcess;

    public abstract class StringRepository : IStringRepository
    {
        
        public List<string> Read(string filePath)
        {
            if (File.Exists(filePath))
            {
                var fileContents = File.ReadAllText(filePath);
                return TextToString(fileContents);
            }
            
            return new List<string>();
        }

    protected abstract List<string> TextToString(string fileContents);
 

    public void Write(string filePath, List<string> strings)
        {
            File.WriteAllText(filePath, StringsToText(strings));
        }

    protected abstract string StringsToText(List<string> strings);
}
