using AutoMapper;
using NeatBook.Domain.Entities;
using NeatBookMVC.Models.Articles;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Chapters;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.AutoMapperProfiles
{
    public class OutputDtoProfile : Profile
    {
        public OutputDtoProfile() 
        {
            CreateMap<Book, BookDetailsViewModel>();
            CreateMap<User, UserDetailsViewModel>();
            CreateMap<Article, ArticleDetailsViewModel>();
            CreateMap<Chapter, ChapterDetailsViewModel>();

            CreateMap<BookDetailsViewModel, Book>();
            CreateMap<UserDetailsViewModel, User>();
            CreateMap<ArticleDetailsViewModel, Article>();
            CreateMap<ChapterDetailsViewModel, Chapter>();
        }
    }
}
