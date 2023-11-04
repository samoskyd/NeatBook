using NeatBook.Domain.Entities;

namespace NeatBookMVC.Models.Chapters
{
    public class ChapterListViewModel
    {
        public int BookId { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
