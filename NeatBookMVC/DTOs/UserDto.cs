using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace NeatBookMVC.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a correct name.")]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Nickname { get; set; }
        
        [StringLength(20)]
        public string Surname { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }
        
        public UserSex UserSex { get; set; }
        
        [StringLength(60)]
        public string BioText { get; set; }
        
        public string SocialLink { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 10)]
        public string Password { get; set; }
        
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
