using NeatBook.Domain.Common;
using NeatBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Entities
{
    public class User : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string? BioText { get; set; }

        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        public DateTime BirthDate { get; set; }
        public UserSex? UserSex { get; set; }
        public string? SocialLink { get; set; }
        
        public ICollection<UserFollows>? Followers { get; set; } = new List<UserFollows>();
        public ICollection<UserFollows>? Following { get; set; } = new List<UserFollows>();
        
        public ICollection<Book>? Books { get; set; } = new List<Book>();
        public ICollection<Article>? Articles { get; set; } = new List<Article>();
        
        public ICollection<BookComment>? BookComments { get; set; } = new List<BookComment>();
        public ICollection<ArticleComment>? ArticleComments { get; set; } = new List<ArticleComment>();
        
        public ICollection<UserLikesBooks>? LikedBooks { get; set; } = new List<UserLikesBooks>();
        public ICollection<UserLikesArticles>? LikedArticles { get; set; } = new List<UserLikesArticles>();
    }
}
