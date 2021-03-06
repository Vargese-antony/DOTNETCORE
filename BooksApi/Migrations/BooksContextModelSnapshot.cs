﻿// <auto-generated />
using System;
using BooksApi.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BooksApi.Migrations
{
    [DbContext(typeof(BooksContext))]
    partial class BooksContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BooksApi.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"),
                            FirstName = "George",
                            LastName = "R R Martin"
                        },
                        new
                        {
                            Id = new Guid("0b5a6cd6-c441-4c08-8ea5-514d37f516eb"),
                            FirstName = "Stephan",
                            LastName = "Fry"
                        },
                        new
                        {
                            Id = new Guid("85ab217f-2701-4c6b-b712-8473e01c7603"),
                            FirstName = "Douglas",
                            LastName = "Adams"
                        });
                });

            modelBuilder.Entity("BooksApi.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2500)")
                        .HasMaxLength(2500);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5dabb349-e361-49c1-8bf1-5b38e7371a4b"),
                            AuthorId = new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"),
                            Description = "George RR Martin is the author",
                            Title = "The winds of winter"
                        },
                        new
                        {
                            Id = new Guid("77c77e7d-dcad-41a4-ae79-c1933805975a"),
                            AuthorId = new Guid("b9383602-01fc-4281-8ead-c451e1be8f94"),
                            Description = "Game of thrones description",
                            Title = "Game of thrones"
                        },
                        new
                        {
                            Id = new Guid("794dc277-533b-4fd0-b4ea-1b3f44475242"),
                            AuthorId = new Guid("0b5a6cd6-c441-4c08-8ea5-514d37f516eb"),
                            Description = "A book by stepahane fry",
                            Title = "AutoBioraphy by stephan fry"
                        },
                        new
                        {
                            Id = new Guid("a7285ffa-47d4-441f-b137-8865417d2d9b"),
                            AuthorId = new Guid("85ab217f-2701-4c6b-b712-8473e01c7603"),
                            Description = "A book by Douglas adams",
                            Title = "Book of fire"
                        });
                });

            modelBuilder.Entity("BooksApi.Entities.Book", b =>
                {
                    b.HasOne("BooksApi.Entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
