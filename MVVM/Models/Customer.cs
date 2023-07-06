using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMaui.Abstractions;

namespace UdemyMaui.MVVM.Models
{
    [Table("Customers")]
    public class Customer : TableData
    {
        [Column("Name"), Indexed, NotNull]
        public string Name { get; set; }

        [Unique]
        public string Phone { get; set; }
        
        public int Age { get; set; }
        
        [MaxLength(100)]
        public string Address { get; set; }

        [Ignore]
        public bool IsYoung =>
            Age > 50 ? true : false;
    }
}
