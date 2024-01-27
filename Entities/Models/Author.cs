using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        [Column("AuthorID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter a Author name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a Author's bio")]
        public string? Biography { get; set; }

        ICollection<Book>? Books { get; set; }
    }
}
