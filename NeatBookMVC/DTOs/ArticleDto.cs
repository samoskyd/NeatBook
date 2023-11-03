using NeatBook.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NeatBookMVC.DTOs
{
    public class ArticleDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100000, MinimumLength = 3)]
        public string Text { get; set; }


        [Required]
        public ArticleGenre ArticleGenre { get; set; }
        
        [Required]
        public Language Language { get; set; }
        
        [Required]
        public bool AgeRestrictions { get; set; }
        
        [Required]
        public AuthorRights AuthorRights { get; set; }
        

        [Required]
        public bool Published { get; set; }    
    }
}
