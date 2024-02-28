using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ICategoryService
    {   
        CategoryDto GetCategory(Guid categoryId,bool trackChanges);

        IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);
        
        IEnumerable<CategoryDto> GetByIds(IEnumerable<Guid> ids,bool trackChanges);

        CategoryDto CreateCategory(CategoryForCreationDto category);

        (IEnumerable<CategoryDto> categories, string ids) CreateCategoryCollection(IEnumerable<CategoryForCreationDto> categoryCollection);
        
        void DeleteCategory(Guid categoryId, bool trackChanges);

        void UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdate, bool trackChanges);
    }
}
