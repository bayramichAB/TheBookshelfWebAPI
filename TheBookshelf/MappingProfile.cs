using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace TheBookshelf
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
