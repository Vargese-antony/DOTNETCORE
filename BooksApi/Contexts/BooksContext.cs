using BooksApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Contexts
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author()
                {
                    Id = Guid.Parse("B9383602-01FC-4281-8EAD-C451E1BE8F94"),
                    FirstName = "George",
                    LastName = "R R Martin"
                },
                new Author()
                {
                    Id = Guid.Parse("0B5A6CD6-C441-4C08-8EA5-514D37F516EB"),
                    FirstName = "Stephan",
                    LastName = "Fry"
                },
                new Author()
                {
                    Id = Guid.Parse("85AB217F-2701-4C6B-B712-8473E01C7603"),
                    FirstName = "Douglas",
                    LastName = "Adams"
                }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    Id = Guid.Parse("5DABB349-E361-49C1-8BF1-5B38E7371A4B"),
                    Title = "The winds of winter",
                    Description = "George RR Martin is the author",
                    AuthorId = Guid.Parse("B9383602-01FC-4281-8EAD-C451E1BE8F94")
                },
                new Book()
                {
                    Id = Guid.Parse("77C77E7D-DCAD-41A4-AE79-C1933805975A"),
                    Title = "Game of thrones",
                    Description = "Game of thrones description",
                    AuthorId = Guid.Parse("B9383602-01FC-4281-8EAD-C451E1BE8F94")
                },
                new Book()
                {
                    Id = Guid.Parse("794DC277-533B-4FD0-B4EA-1B3F44475242"),
                    Title = "AutoBioraphy by stephan fry",
                    Description = "A book by stepahane fry",
                    AuthorId = Guid.Parse("0B5A6CD6-C441-4C08-8EA5-514D37F516EB")
                },
                new Book()
                {
                    Id = Guid.Parse("A7285FFA-47D4-441F-B137-8865417D2D9B"),
                    Title = "Book of fire",
                    Description = "A book by Douglas adams",
                    AuthorId = Guid.Parse("85AB217F-2701-4C6B-B712-8473E01C7603")
                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
