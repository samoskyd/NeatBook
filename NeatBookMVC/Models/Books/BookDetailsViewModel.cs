using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;

namespace NeatBookMVC.Models.Books
{
    public class BookDetailsViewModel
    {
        public string Name { get; set; }
        public string CoverImagePath { get; set; } = "C:\\Users\\maksm\\source\\repos\\NeatBook\\NeatBookMVC\\wwwroot\\images\\book_cover.jpg";
        public BookGenre BookGenre { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public BookStatus BookStatus { get; set; }
        public AuthorRights AuthorRights { get; set; }
        public bool AgeRestriction { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PublishingDate { get; set; }
        public int ViewCount { get; set; }
        public int UserId { get; set; }
        public string UserNickname { get; set; }
        public int ChaptersCount { get; set; }
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }
    }
}
