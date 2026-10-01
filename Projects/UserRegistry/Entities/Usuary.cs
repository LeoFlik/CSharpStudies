namespace UserRegistry.Entities
{
    public class Usuary
    {
        public string? Name { get; set; }
        public string? DocNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public uint HouseNumber { get; set; }

        public Usuary(string? name, string? docNumber, DateTime birthDate, string? address, uint houseNumber)
        {
            Name = name;
            DocNumber = docNumber;
            BirthDate = birthDate;
            Address = address;
            HouseNumber = houseNumber;
        }

        override public string ToString()
        {
            return $"Name: {Name}\nDocNumber: {DocNumber}\nBirthDate: {BirthDate.ToShortDateString()}\nAddress: {Address}\nHouseNumber: {HouseNumber}";
        }
    }
}