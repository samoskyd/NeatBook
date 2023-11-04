﻿using NeatBook.Domain.Entities;

namespace NeatBookMVC.Models.CompositeViewModels
{
    public class SearchResultViewModel
    {
        public List<Book> Books { get; set; }
        public List<Article> Articles { get; set; }
        public List<User> Users { get; set; }
    }
}
