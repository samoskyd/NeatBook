namespace NeatBookMVC.Models.Chapters
{
    public class ChapterDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string? Text { get; set; }

        public int Order { get; set; }
        public int BookId { get; set; }
    }
}
