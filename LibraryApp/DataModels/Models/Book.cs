using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Author Name")]
        public string? Author { get; set; }
        [Required]
        [DisplayName("Book Title")]
        public string? Title {get;set;}
        [Required]
        [DisplayName("ISBN")]
        [StringLength(10)]
        public string? Isbn {get;set;}
        [Required]
        [DisplayName("Publication Date")]
        public DateTime? PublishedDate { get; set; }
        [Required]
        [DisplayName("In stock")]
        public int Quantity { get; set; }
        [Required]
        [DisplayName("Price")]
        public decimal Price { get; set; }

    }
}
