using Microsoft.EntityFrameworkCore;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
        // public DbSet<FluentAuthor> FluentAuthors { get; set; }
        // public DbSet<FluentPublisher> FluentPublishers { get; set; }
        // public DbSet<FluentBookAuthor> FluentBookAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookId });

            //BookDetails
            modelBuilder.Entity<FluentBookDetail>().HasKey(b => b.Id);
            modelBuilder.Entity<FluentBookDetail>().Property(b => b.NumberOfChapters).IsRequired();

            //Book
            modelBuilder.Entity<FluentBook>().HasKey(b => b.Id);
            modelBuilder.Entity<FluentBook>().Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<FluentBook>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<FluentBook>().Property(b => b.Price).IsRequired();
        }
    }
}