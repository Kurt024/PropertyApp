using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;   

namespace propertyApp
{
    public class property
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public string? FullnameOwner { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
