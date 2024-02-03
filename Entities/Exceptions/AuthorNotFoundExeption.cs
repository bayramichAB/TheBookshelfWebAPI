using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class AuthorNotFoundExeption : Exception
    {
        public AuthorNotFoundExeption(Guid authorId):base($"The Author with id {authorId} doesn't exist in the database")
        {
            
        }
    }
}
