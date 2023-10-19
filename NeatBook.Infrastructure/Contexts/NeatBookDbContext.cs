using Microsoft.EntityFrameworkCore;
using NeatBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Infrastructure.Contexts
{
    public class NeatBookDbContext: DbContext
    {
        public NeatBookDbContext(DbContextOptions<NeatBookDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<BookComment> BookCommments { get; set; }
        public virtual DbSet<ArticleComment> ArticleComments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFollows> UserFollows { get; set; }
        public virtual DbSet<UserLikesArticles> UserLikesArticles { get; set; }
        public virtual DbSet<UserLikesBooks> UserLikesBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFollows>()
            .HasKey(uf => new { uf.FollowerId, uf.FollowingId });

            modelBuilder.Entity<UserFollows>()
                .HasOne(uf => uf.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFollows>()
                .HasOne(uf => uf.Following)
                .WithMany(u => u.Following)
                .HasForeignKey(uf => uf.FollowingId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Articles)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(p => p.BookComments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(p => p.ArticleComments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Books)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(p => p.LikedBooks)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<User>()
                .HasMany(p => p.LikedArticles)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserLikesBooks>()
                .HasOne(c => c.User)
                .WithMany(p => p.LikedBooks)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserLikesBooks>()
                .HasOne(c => c.Book)
                .WithMany(p => p.Likes)
                .HasForeignKey(c => c.BookId);
            
            modelBuilder.Entity<UserLikesArticles>()
                .HasOne(c => c.User)
                .WithMany(p => p.LikedArticles)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserLikesArticles>()
                .HasOne(c => c.Article)
                .WithMany(p => p.Likes)
                .HasForeignKey(c => c.ArticleId);

            modelBuilder.Entity<Chapter>()
                .HasOne(c => c.Book)
                .WithMany(p => p.Chapters)
                .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<Article>()
               .HasOne(c => c.User)
               .WithMany(p => p.Articles)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Article>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Article)
               .HasForeignKey(c => c.ArticleId);
            
            modelBuilder.Entity<Article>()
               .HasMany(p => p.Likes)
               .WithOne(c => c.Article)
               .HasForeignKey(c => c.ArticleId);

            modelBuilder.Entity<Book>()
               .HasOne(c => c.User)
               .WithMany(p => p.Books)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Book>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Book)
               .HasForeignKey(c => c.BookId);
            
            modelBuilder.Entity<Book>()
               .HasMany(p => p.Likes)
               .WithOne(c => c.Book)
               .HasForeignKey(c => c.BookId);
            
            modelBuilder.Entity<Book>()
               .HasMany(p => p.Chapters)
               .WithOne(c => c.Book)
               .HasForeignKey(c => c.BookId);

            modelBuilder.Entity<BookComment>()
               .HasOne(c => c.User)
               .WithMany(p => p.BookComments)
               .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<BookComment>()
               .HasOne(c => c.Book)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.BookId);
            
            modelBuilder.Entity<ArticleComment>()
               .HasOne(c => c.User)
               .WithMany(p => p.ArticleComments)
               .HasForeignKey(c => c.UserId);
            
            modelBuilder.Entity<ArticleComment>()
               .HasOne(c => c.Article)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.ArticleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
