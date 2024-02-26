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
        void DeleteCategory(Guid categoryId, bool trackChanges);
        IEnumerable<CategoryDto> GetAllCategories(bool trackChanges);
        CategoryDto GetCategory(Guid categoryId,bool trackChanges);
        CategoryDto CreateCategory(CategoryForCreationDto category);
        IEnumerable<CategoryDto> GetByIds(IEnumerable<Guid> ids,bool trackChanges);
        (IEnumerable<CategoryDto> categories, string ids) CreateCategoryCollection(IEnumerable<CategoryForCreationDto> categoryCollection);
    }
}
