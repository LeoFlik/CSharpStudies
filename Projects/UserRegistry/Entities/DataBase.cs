namespace UserRegistry.Entities
{
    public class DataBase
    {
        public List<Usuary> UsuaryList { get; set; } 
        
        public DataBase()
        {
            UsuaryList = new List<Usuary>();
        }

        public void AddUsuary(Usuary usuary)
        {
            UsuaryList.Add(usuary);
        }

        public void RemoveUsuary(Usuary usuary)
        {
            UsuaryList.Remove(usuary);
        }

        public List<Usuary> GetAllUsuaries()
        {
            return UsuaryList;
        }

        public List<Usuary>? GetUsuaryByDocNumber(string? docNumber)
        {
            List<Usuary> usuaryListByDocNumber = UsuaryList.Where(u => u.DocNumber == docNumber).ToList();
            if(usuaryListByDocNumber.Count > 0)
            {
                return usuaryListByDocNumber;
            }
            else
            {
                return null;
            }
        }

        public List<Usuary>? RemoveUsuaryByDocNumber(string? docNumber)
        {
            List<Usuary> usuaryListByDocNumber = UsuaryList.Where(u => u.DocNumber == docNumber).ToList();
            if(usuaryListByDocNumber.Count > 0)
            {
                foreach (var usuary in usuaryListByDocNumber)
                {
                    UsuaryList.Remove(usuary);
                }
                return usuaryListByDocNumber;
            }
            else
            {
                return null;
            }
        }
    }
}