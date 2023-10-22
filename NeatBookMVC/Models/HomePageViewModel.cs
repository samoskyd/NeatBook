using NeatBook.Domain.Entities;

namespace NeatBookMVC.Models
{
    public class HomePageViewModel
    {
        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
        public List<User> Users { get; set; }
    }
}
