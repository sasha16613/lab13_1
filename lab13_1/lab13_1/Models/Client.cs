using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace lab13_1.Models
{
    [Table("Client")]
    public class Client
    {
        [PrimaryKey, AutoIncrement]
        public int ClientID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        //public ICollection<Tour> Tours { get; set; }
    }
}
