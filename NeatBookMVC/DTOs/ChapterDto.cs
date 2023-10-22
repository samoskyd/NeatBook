using NeatBook.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace NeatBookMVC.DTOs
{
    public class ChapterDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public int Order { get; set; }
        [Required]
        [StringLength(100000, MinimumLength = 3)]
        public string Text { get; set; }
        [Required]
        public bool Published { get; set; }
    }
}
