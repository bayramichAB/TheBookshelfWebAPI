using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetBooks(Guid categoryId,bool trackChanges);
    }
}
