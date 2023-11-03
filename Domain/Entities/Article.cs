using NeatBook.Domain.Common;
using NeatBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Entities
{
    public class Article : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public ArticleGenre ArticleGenre { get; set; }
        public Language Language { get; set; }
        public bool AgeRestrictions { get; set; }
        public AuthorRights AuthorRights { get; set; }

        public DateTime CreationDate { get; set; }
        public bool Published { get; set; }
        public DateTime? PublishingDate { get; set; }
        
        public int ViewCount { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ArticleComment>? Comments { get; set; } = new List<ArticleComment>();
        public ICollection<UserLikesArticles>? Likes { get; set; } = new List<UserLikesArticles>();
    }
}
