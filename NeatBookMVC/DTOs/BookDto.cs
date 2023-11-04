using NeatBook.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NeatBookMVC.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public BookGenre BookGenre { get; set; }
        
        [Required]
        public Language Language { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        [Required]
        public BookStatus BookStatus { get; set; }
        
        [Required]
        public AuthorRights AuthorRights { get; set; }
        
        [Required]
        public bool AgeRestriction { get; set; }
        
        [Required]
        public bool Published { get; set; }
    }
}
