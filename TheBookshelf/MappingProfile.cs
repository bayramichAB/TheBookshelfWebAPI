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
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();

            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<BookForCreationDto,Book>();
            CreateMap<AuthorForCreationDto, Author>();

            CreateMap<BookForUpdateDto, Book>().ReverseMap();
            CreateMap<CategoryForUpdateDto, Category>();
            CreateMap<AuthorForUpdateDto, Author>();

            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
