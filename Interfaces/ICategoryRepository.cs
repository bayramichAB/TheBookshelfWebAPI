using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICategoryRepository
    {   
        Task<Category?> GetCategoryAsync(Guid categoryId,bool trackChanges);

        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);

        Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<Guid> ids,bool trackChanges);
        
        void CreateCategory(Category category);

        void DeleteCategory(Category category);
    }
}
