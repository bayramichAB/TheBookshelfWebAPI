using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AvailableBookBadRequestException : BadRequestException
    {
        public AvailableBookBadRequestException(): base("There are not books with this condition ")
        {
            
        }
    }
}
