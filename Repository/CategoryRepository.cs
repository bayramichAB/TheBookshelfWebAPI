using Entities.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public async Task<Category?> GetCategoryAsync(Guid categoryId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(categoryId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)=>
            await FindAll(trackChanges).OrderBy(c=>c.Name).ToListAsync();

         public async Task<IEnumerable<Category>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) => 
            await FindByCondition(c => ids.Contains(c.Id), trackChanges).ToListAsync();

         public void CreateCategory(Category category) => Create(category);

         public void DeleteCategory(Category category) => Delete(category);
    }
}
