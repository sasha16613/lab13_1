using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab13_1.Models
{
    [Table("Visa")]
    public class Visa
    {
        [PrimaryKey, AutoIncrement]
        public int VisaID { get; set; }
        public string VisaName { get; set; }
        public int VisaPrice { get; set; }

        //public ICollection<Tour> Tours { get; set; }
    }
}
