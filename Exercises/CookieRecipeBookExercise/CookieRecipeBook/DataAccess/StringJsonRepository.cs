using System.Text.Json;


namespace CookieRecipeBook.DataAcess;

public class StringJsonRepository : StringRepository
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToString(string fileContents)
    {
       return JsonSerializer.Deserialize<List<string>>(fileContents) ?? new List<string>();
    }
}

