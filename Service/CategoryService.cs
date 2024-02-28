using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class CategoryService:ICategoryService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public CategoryDto GetCategory(Guid categoryId, bool trackChanges)
        {
            var category=_repository.Category.GetCategory(categoryId, trackChanges);
            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            var categoryDto=_mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
        
        public IEnumerable<CategoryDto> GetAllCategories(bool trackChanges)
        {
            var categories = _repository.Category.GetAllCategories(trackChanges);

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }
        
        public IEnumerable<CategoryDto> GetByIds(IEnumerable<Guid> ids,bool trackChanges)
        {
            if (ids is null)
            {
                throw new IdParametersBadRequestException();
            }

            var categoryEntities = _repository.Category.GetByIds(ids, trackChanges: false);

            if (ids.Count() != categoryEntities.Count())
            {
                throw new CollectionByIdsBadRequestException();
            }

            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            return categoriesToReturn;
        }

        public void DeleteCategory(Guid categoryId, bool trackChanges)
        {
            var category = _repository.Category.GetCategory(categoryId,trackChanges);
            if (category is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            _repository.Category.DeleteCategory(category);
            _repository.Save();
        }
        
        public CategoryDto CreateCategory(CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(categoryEntity);
            _repository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);
            return categoryToReturn;
        }

        public (IEnumerable<CategoryDto> categories,string ids) CreateCategoryCollection(IEnumerable<CategoryForCreationDto> categoryCollection)
        {
            if (categoryCollection is null) 
            {
                throw new CategoryCollectionBadRequest();
            }

            var categoryEntities = _mapper.Map<IEnumerable<Category>>(categoryCollection);
            foreach (var category in categoryEntities)
            {
                _repository.Category.CreateCategory(category);
            }
            _repository.Save();

            var categoryCollectionToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categoryEntities);
            var ids = string.Join(",", categoryCollectionToReturn.Select(c => c.Id));

            return (categories: categoryCollectionToReturn,ids:ids);
        }

        public void UpdateCategory(Guid categoryId, CategoryForUpdateDto categoryForUpdate,bool trackChanges)
        {
            var categoryEntity = _repository.Category.GetCategory(categoryId,trackChanges);
            if (categoryEntity is null)
            {
                throw new CategoryNotFoundException(categoryId);
            }

            _mapper.Map(categoryForUpdate,categoryEntity);
            _repository.Save();
        }
    }
}
