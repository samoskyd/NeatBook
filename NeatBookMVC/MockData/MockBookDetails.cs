using NeatBook.Domain.Enums;
using NeatBookMVC.Models.DetailsViewModels;

namespace NeatBookMVC.MockData
{
    public class MockBookDetails
    {
        public BookDetailsViewModel GenerateMockData()
        {
            var viewModel = new BookDetailsViewModel
            {
                Name = "TestBook",
                BookGenre = BookGenre.Detective,
                Language = Language.Ukrainian,
                Description = "Test",
                BookStatus = BookStatus.Finished,
                AuthorRights = AuthorRights.CreativeCommons,
                AgeRestriction = false,
                CreationDate = DateTime.UtcNow,
                PublishingDate = DateTime.UtcNow,
                ViewCount = 12,
                UserId = 2,
                UserNickname = "Test",
                ChaptersCount = 12,
                CommentsCount = 3,
                LikesCount = 34
            };

            return viewModel;
        }
    }
}
