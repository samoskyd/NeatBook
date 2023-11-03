using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;
using NeatBookMVC.Models.CompositeViewModels;

namespace NeatBookMVC.MockData
{
    public class MockHomeModel
    {
        public HomePageViewModel GenerateMockData()
        {
            var viewModel = new HomePageViewModel
            {
                Books = GenerateMockBooks(10),
                Articles = GenerateMockArticles(10),
                Users = GenerateMockUsers(10)
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

        private List<Article> GenerateMockArticles(int count)
        {
            var articles = new List<Article>();

            for (int i = 1; i <= count; i++)
            {
                var article = new Article
                {
                    Name = $"Article {i}",
                    CreationDate = DateTime.UtcNow,
                    Published = true,
                    PublishingDate = DateTime.UtcNow,
                    ArticleGenre = ArticleGenre.Personal,
                    Language = Language.English,
                    AgeRestrictions = false,
                    AuthorRights = AuthorRights.None,
                    ViewCount = 500,
                    Text = $"Text for Article {i}",
                    UserId = i
                };
                articles.Add(article);
            }

            return articles;
        }

        private List<User> GenerateMockUsers(int count)
        {
            var users = new List<User>();

            for (int i = 1; i <= count; i++)
            {
                var user = new User
                {
                    Name = $"User {i}",
                    Nickname = $"Nickname{i}",
                    Surname = $"Surname{i}",
                    BirthDate = DateTime.UtcNow,
                    UserSex = UserSex.Male,
                    BioText = $"Bio for User {i}",
                    SocialLink = $"https://www.example.com/user{i}",
                    Password = "password123",
                    Email = $"user{i}@example.com"
                };
                users.Add(user);
            }

            return users;
        }
    }
}
