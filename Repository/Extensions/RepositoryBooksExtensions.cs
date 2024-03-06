﻿using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryBooksExtensions
    {
        public static IQueryable<Book> FilterBooks(this IQueryable<Book> books, decimal minPrice, decimal maxPrice) =>
            books.Where(b => (b.Price >= minPrice && b.Price <= maxPrice));

        public static IQueryable<Book> IsBookAvailable(this IQueryable<Book> books, bool? availableBook)
        {
            if (availableBook is null)
            {
                return books;
            }
            var isBookExist = books.Where(b=>b.Available == availableBook);
            return isBookExist.Count() == 0 ? throw new AvailableBookBadRequestException() : isBookExist; //books.Where(b=>b.Available == availableBook);
        }

        public static IQueryable<Book> Search(this IQueryable<Book> books, string? searchBook)
        {
            if (string.IsNullOrWhiteSpace(searchBook))
            {
                return books;
            }
            var lowerCase = searchBook.Trim().ToLower();
            return books.Where(b => b.Name!.ToLower().Contains(lowerCase));
        }
    }
}
