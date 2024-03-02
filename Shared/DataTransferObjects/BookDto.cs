using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record BookDto {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public decimal Price { get; init; }
        public bool? Available { get; init; }
        public string? Pages {  get; init; }
        public DateTime Date {  get; init; }
        public string? Description {  get; init; }
    };
}
