using Entities.LinkModels;
using Entities.Models;
using Interfaces;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;

namespace TheBookshelf.Utility
{
    public class BookLinks : IBookLinks
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly IDataShaper<BookDto> _dataShaper;

        public BookLinks(LinkGenerator linkGenerator, IDataShaper<BookDto> dataShaper)
        {
            _linkGenerator = linkGenerator;
            _dataShaper = dataShaper;
        }

        public LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string? fields, Guid categoryId, HttpContext httpContext)
        {
            var shapedBook = ShapedData(booksDto,fields!);

            if (ShouldGenerateLinks(httpContext))
            {
                return ReturnLinkedBooks(booksDto,fields!, categoryId, httpContext,shapedBook);
            }

            return ReturnShapedBooks(shapedBook);                           //1
        }

        // method for GetBooksForCategoryAndAuthorAsync
        public LinkResponse TryGenerateLinks(IEnumerable<BookDto> booksDto, string? fields, Guid categoryId, Guid authorId, HttpContext httpContext)
        {
            var shapedBook = ShapedData(booksDto, fields!);

            if (ShouldGenerateLinks(httpContext))
            {
                return ReturnLinkedBooks(booksDto, fields!, categoryId,authorId, httpContext, shapedBook);
            }

            return ReturnShapedBooks(shapedBook);               //2
        }



        //all methods in below are private that means they work only for this class
        private List<Entity> ShapedData(IEnumerable<BookDto> booksDto, string fields) => 
            _dataShaper.ShapeData(booksDto, fields).Select(e => e.Entity).ToList();

        private bool ShouldGenerateLinks(HttpContext httpContext)
        {
            var mediaType = (MediaTypeHeaderValue?)httpContext.Items["AcceptHeaderMediaType"];
            return mediaType!.SubTypeWithoutSuffix.EndsWith("hateoas", StringComparison.InvariantCultureIgnoreCase);
        }

        private LinkResponse ReturnShapedBooks(List<Entity> shapedBook) => new LinkResponse { ShapedEntities = shapedBook };
    
        private LinkResponse ReturnLinkedBooks(IEnumerable<BookDto> booksDto, string fields, 
            Guid categoryId, HttpContext httpContext, List<Entity> shapedBooks)
        {
            var BookDtoList = booksDto.ToList();
            for (var index=0;index< BookDtoList.Count();index++)
            {
                var bookLinks = CreateLinksForBook(httpContext, categoryId, BookDtoList[index].Id,fields);
                shapedBooks[index].Add("Links", bookLinks);
            }

            var bookCollection = new LinkCollectionWrapper<Entity>(shapedBooks);
            var linkedBooks = CreateLinksForBooks(httpContext, bookCollection);     //1

            return new LinkResponse { HasLinks=true, LinkedEntities=linkedBooks};
        }


        // method for GetBooksForCategoryAndAuthorAsync 

        private LinkResponse ReturnLinkedBooks(IEnumerable<BookDto> booksDto, string fields,
            Guid categoryId,Guid authorId, HttpContext httpContext, List<Entity> shapedBooks)
        {
            var BookDtoList = booksDto.ToList();
            for (var index = 0; index < BookDtoList.Count(); index++)
            {
                var bookLinks = CreateLinksForBook(httpContext, categoryId, authorId, BookDtoList[index].Id, fields);
                shapedBooks[index].Add("Links", bookLinks);
            }

            var bookCollection = new LinkCollectionWrapper<Entity>(shapedBooks);
            var linkedBooks = CreateLinksForBooksForCategoryAndAuthor(httpContext, bookCollection);       //2

            return new LinkResponse { HasLinks = true, LinkedEntities = linkedBooks };
        }

        private List<Link> CreateLinksForBook(HttpContext httpContext,Guid categoryId, Guid Id,string fields="")
        {
            var links = new List<Link>()
            {
                new Link(_linkGenerator.GetUriByAction(httpContext,"GetBooksForCategory", values:new {categoryId,Id,fields}),"self","GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"DeleteBooksForCategory",values:new{categoryId,Id}),"delete_book","DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"UpdateBooksForCategory",values:new{categoryId,Id}),"update_book","PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"PartiallyUpdateBooksForCategory",values:new{categoryId,Id}),"partially_update_book","PATCH")
            };

            return links;
        }


        // method for GetBooksForCategoryAndAuthorAsync
        private List<Link> CreateLinksForBook(HttpContext httpContext, Guid categoryId, Guid authorId, Guid Id, string fields = "")
        {
            var links = new List<Link>()
            {
                new Link(_linkGenerator.GetUriByAction(httpContext,"GetBookForCategoryAndAuthor", values:new {categoryId,authorId,Id,fields}),"self","GET"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"DeleteBookForCategoryAndAuthor",values:new{categoryId,authorId,Id}),"delete_book","DELETE"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"UpdateBookForCategoryAndAuthor",values:new{categoryId,authorId,Id}),"update_book","PUT"),
                new Link(_linkGenerator.GetUriByAction(httpContext,"PartiallyUpdateBookForCategory",values:new{categoryId,authorId,Id}),"partially_update_book","PATCH")
            };

            return links;
        }

        private LinkCollectionWrapper<Entity> CreateLinksForBooks(HttpContext httpContext,LinkCollectionWrapper<Entity> bookWrapper)
        {
            bookWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetBooksForCategory", values: new { }), "self", "GET"));
            return bookWrapper;
        }

        // 
        private LinkCollectionWrapper<Entity> CreateLinksForBooksForCategoryAndAuthor(HttpContext httpContext, LinkCollectionWrapper<Entity> bookWrapper)
        {
            bookWrapper.Links.Add(new Link(_linkGenerator.GetUriByAction(httpContext, "GetBooksForCategoryAndAuthor", values: new { }), "self", "GET"));
            return bookWrapper;
        }

    }
}
