using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record AuthorDto
    {
        public Guid Id {  get; init; }
        public string? Name {  get; init; }
        public string? Biography {  get; init; }
    };
}
