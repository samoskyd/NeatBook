using NeatBook.Domain.Entities;

namespace NeatBookMVC.Models.Users
{
    public class UserDetailsViewModel
    {
        public int Id { get; set; } 
        public string AvatarImagePath { get; set; } = "C:\\Users\\maksm\\source\\repos\\NeatBook\\NeatBookMVC\\wwwroot\\images\\user_avatar.jpg";

        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? BioText { get; set; }
        public string Nickname { get; set; }
        public string? SocialLink { get; set; }

        public int FollowersCount { get; set; }
        public int FollowingCount { get; set; }

        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
    }
}
