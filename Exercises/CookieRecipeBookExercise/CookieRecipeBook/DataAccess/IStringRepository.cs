
namespace CookieRecipeBook.DataAcess;

    public interface IStringRepository
    {
      public  List<string> Read(string filePath);
      public void Write(string filePath,List<string>strings);
    }
