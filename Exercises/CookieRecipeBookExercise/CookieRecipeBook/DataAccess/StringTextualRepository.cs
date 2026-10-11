
namespace CookieRecipeBook.DataAcess;

public class StringTextualRepository : StringRepository
{
    private static readonly string _separator = Environment.NewLine;

    protected override string StringsToText(List<string> strings)
    {
        return String.Join(_separator,strings);
    }

    protected override List<string> TextToString(string fileContents)
    {
        return fileContents.Split(_separator).ToList();
    }
}
