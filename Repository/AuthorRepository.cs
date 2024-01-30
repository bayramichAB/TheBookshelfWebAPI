﻿using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    // repository user class
    public class AuthorRepository:RepositoryBase<Author>,IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
    }
}
