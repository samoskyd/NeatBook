using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;
using NeatBookMVC.Models;

namespace NeatBookMVC.MockData
{
    public class MockBookList
    {
        public BookListViewModel GenerateMockData()
        {
            var viewModel = new BookListViewModel
            {
                Books = GenerateMockBooks(20)
            };

            return viewModel;
        }

        private List<Book> GenerateMockBooks(int count)
        {
            var books = new List<Book>();

            for (int i = 1; i <= count; i++)
            {
                var book = new Book
                {
                    Name = $"Book {i}",
                    BookGenre = BookGenre.Science,
                    Language = Language.English,
                    Description = $"Description for Book {i}",
                    BookStatus = BookStatus.Finished,
                    AuthorRights = AuthorRights.CreativeCommons,
                    AgeRestriction = false,
                    CreationDate = DateTime.UtcNow,
                    PublishingDate = DateTime.UtcNow,
                    ViewCount = 1000,
                    UserId = i
                };
                books.Add(book);
            }

            return books;
        }
    }
}
