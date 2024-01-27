using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        [Column("CategoryID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter a Category name")]
        public string? Name { get; set; }

        ICollection<Book>? Books { get; set; }
    }
}
