using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BookDto(
        Guid Id,
        string Name,
        decimal Price,
        bool Available,
        string Pages,
        DateTime Date,
        string Description);
}
