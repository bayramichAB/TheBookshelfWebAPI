using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record BookForManipulationDto
    {
        [Required(ErrorMessage = "Book name is a required field.")]
        public string? Name { get; init; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price is a required fiels and please enter a positive price")]
        public decimal Price { get; init; }

        [Required(ErrorMessage = "Available is a required field.")]
        public bool? Available { get; init; } = false;

        [Required(ErrorMessage = "Page is a required field.")]
        public string? Pages { get; init; }

        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; init; }

        [Required(ErrorMessage = "Description is a required field.")]
        public string? Description { get; init; }
    }
}
