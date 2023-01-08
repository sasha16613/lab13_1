using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace lab13_1.Models
{
    [Table("Tour")]
    public class Tour
    {
        [PrimaryKey, AutoIncrement]
        public int TourID { get; set; }
        public int Client { get; set; }
        public int Price { get; set; }
        public string Country { get; set; }
        public int Visa_t { get; set; }

        //public Client Clients { get; set; }
        //public Visa Visas { get; set; }
    }
}
