using AutoMapper;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Articles;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Chapters;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.AutoMapperProfiles
{
    public class InputDtoProfile : Profile
    {
        public InputDtoProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<User, UserDto>();
            CreateMap<Article, ArticleDto>();
            CreateMap<Chapter, ChapterDto>();

            CreateMap<BookDto, Book>();
            CreateMap<UserDto, User>();
            CreateMap<ArticleDto, Article>();
            CreateMap<ChapterDto, Chapter>();
        }
    }
}
