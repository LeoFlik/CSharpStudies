using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistry.Entities
{
    public class Usuary
    {
        public string? Name { get; set; }
        public uint DocNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Address { get; set; }
        public uint HouseNumber { get; set; }

        public Usuary(string? name, uint docNumber, DateTime birthDate, string? address, uint houseNumber)
        {
            Name = name;
            DocNumber = docNumber;
            BirthDate = birthDate;
            Address = address;
            HouseNumber = houseNumber;
        }

        override public string ToString()
        {
            return $"Name: {Name}, DocNumber: {DocNumber}, BirthDate: {BirthDate.ToShortDateString()}, Address: {Address}, HouseNumber: {HouseNumber}";
        }
    }
}