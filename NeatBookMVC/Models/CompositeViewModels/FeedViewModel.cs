using NeatBook.Domain.Entities;

namespace NeatBookMVC.Models.CompositeViewModels
{
    public class FeedViewModel
    {
        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
        //public List<User> Users { get; set; }
        //public List<BookComment> BookComments { get; set; }
        //public List<ArticleComment> ArticleComments { get; set; }
    }
}
