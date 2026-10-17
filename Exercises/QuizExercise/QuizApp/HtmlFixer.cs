using System.Net;
namespace QuizApp
{
    public static class HtmlFixer
    {
        public static string Fix(string text)=>
        WebUtility.HtmlDecode(text);
    }
}