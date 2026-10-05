using Library2_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Library2_WebAPI.Data
{
    public class AppDbContext:DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        public DbSet<Models.Book> Books { get; set; }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.Borrowing> Borrowings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configurations
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();
            modelBuilder.Entity<Models.Member>()
                .HasIndex(m => m.Email)
                .IsUnique();
            modelBuilder.Entity<Models.Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            //Relationships
            modelBuilder.Entity<Models.Borrowing>()
                .HasOne(b => b.Member)
                .WithMany(m => m.Borrowings)
                .HasForeignKey(b => b.MemberId);

            modelBuilder.Entity<Models.Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.Borrowings)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            // Seed Data


            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category 
                { CategoryId = 1,
                    Name = "Fiction",
                    Description = "Fictional books" },

                new Category { CategoryId = 2, Name = "Non-Fiction",
                    Description = "Non-fictional books" }
            );

            // Seed Books
            modelBuilder.Entity<Book>()
                .HasData(
                new Book
                {
                    BookId = 1,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    ISBN = "9780743273565",
                    Price = 10.99m,
                    IsAvailable = true,
                    CategoryId = 1
                },
                new Book
                {
                    BookId = 2,
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    ISBN = "9780062316097",
                    Price = 14.99m,
                    IsAvailable = false,
                    CategoryId = 2
                }
                );

            // Seed Members
            modelBuilder.Entity<Member>()
                .HasData(
                new Member
                {
                    MemberId = 1,
                    FullName = "John Doe",
                    Email="j@123",
                    Phone = "123-456-7890",
                },
                new Member
                {
                    MemberId = 2,
                    FullName = "Jane Smith",
                    Email = "j@1234",
                    Phone = "987-654-3210",
                }
                );

            // Seed Borrowings
            modelBuilder.Entity<Borrowing>()
                .HasData(
                new Borrowing
                {
                    BorrowingId = 1,
                    BorrowedDate = new DateOnly(2023, 1, 15),
                    ReturnedDate = new DateTime(2023, 2, 15),
                    MemberId = 1,
                    BookId = 1
                },
                new Borrowing
                {
                    BorrowingId = 2,
                    BorrowedDate = new DateOnly(2023, 3, 10),
                    ReturnedDate = null,
                    MemberId = 2,
                    BookId = 2
                }
                );

        }

    }
}
