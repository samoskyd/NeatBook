using NeatBook.Domain.Enums;

namespace NeatBookMVC.Models.Articles
{
    public class ArticleDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Text { get; set; }

        public ArticleGenre ArticleGenre { get; set; }
        public Language Language { get; set; }
        public bool AgeRestrictions { get; set; }
        public AuthorRights AuthorRights { get; set; }
        public DateTime? PublishingDate { get; set; }
    }
}
