using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;

namespace NeatBookMVC.Models
{
    public class UserProfileViewModel
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string? Surname { get; set; }
        public string? BioText { get; set; }
        public string? SocialLink { get; set; }
        public ICollection<User>? Followers { get; set; }
        public ICollection<User>? Following { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<Article>? Articles { get; set; }
    }
}
