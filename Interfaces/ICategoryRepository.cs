﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category? GetCategory(Guid categoryId,bool trackChanges);
        void CreateCategory(Category category);
        IEnumerable<Category> GetByIds(IEnumerable<Guid> ids,bool trackChanges);
    }
}
