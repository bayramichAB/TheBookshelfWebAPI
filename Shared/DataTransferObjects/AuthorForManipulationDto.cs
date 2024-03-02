using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record AuthorForManipulationDto
    {
        [Required(ErrorMessage = "Author name is a required field.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Biography is a required field.")]
        public string? Biography { get; init; }
    }
}
