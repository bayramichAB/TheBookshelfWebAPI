using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Column("BookId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Book name is a required field.")]
        //[MaxLength(90, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public bool Available { get; set; } = false;

        [Required(ErrorMessage = "Please enter a page number")]
        public string? Pages { get; set; }

        [Required(ErrorMessage = "Please enter a data")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string? Description { get; set; }


        [ForeignKey(nameof(Category))]
        public Guid CategoryID { get; set; }

        public Category? Category { get; set; }


        [ForeignKey(nameof(Author))]
        public Guid? AuthorID { get; set; }

        public Author? Author { get; set; }
    }
}
