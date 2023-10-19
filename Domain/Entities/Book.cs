using NeatBook.Domain.Common;
using NeatBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Domain.Entities
{
    public class Book : BaseAuditableEntity
    {
        public string Name { get; set; }
        public BookGenre BookGenre { get; set; }
        public Language Language { get; set; }
        public string Description { get; set; }
        public BookStatus BookStatus { get; set; }
        public AuthorRights AuthorRights { get; set; }
        public bool AgeRestriction { get; set; }
        public bool Published { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime PublishingDate { get; set; }
        public int ViewCount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Chapter>? Chapters { get; set; } = new List<Chapter>();
        public ICollection<BookComment>? Comments { get; set; } = new List<BookComment>();
        public ICollection<UserLikesBooks>? Likes { get; set; } = new List<UserLikesBooks>();
    }
}
