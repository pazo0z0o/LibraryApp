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
        [Required(ErrorMessage = "Author name is required")]
        [DisplayName("Author Name")]
        public string? Author { get; set; }
        [Required(ErrorMessage = "Book title is required")]
        [DisplayName("Book Title")]
        public string? Title {get;set;}
        [Required(ErrorMessage = "ISBN code is required")]
        [DisplayName("ISBN")]
        [StringLength(10)]
        public string? Isbn {get;set;}
        [Required(ErrorMessage = "Publication date of book is required")]
        [DisplayName("Publication Date")]
        public DateTime? PublishedDate { get; set; }
        [Required(ErrorMessage = "Quantity in stock is required")]
        [DisplayName("In stock")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Price of book is required")]
        [DisplayName("Price")]
        public decimal Price { get; set; }

    }
}
