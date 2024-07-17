using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DTO
{
    public class BookCreateDTO
    {
        public string author { get; set; }
        public string title { get; set; }
        public string ISBN { get; set; }
        public DateTime? publishedDate { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
    }
}
