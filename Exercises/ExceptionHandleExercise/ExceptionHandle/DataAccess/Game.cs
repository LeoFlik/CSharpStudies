

namespace ExceptionHandle.DataAccess
{
    public class Game
    {
        public string Title{get;init;}
        public int ReleaseYear {get;init;}
        public decimal Rating {get;init;}

      
        public override string ToString()
        =>$"{Title}, released in: {ReleaseYear}, overall rating: {Rating}";
       
    }
}