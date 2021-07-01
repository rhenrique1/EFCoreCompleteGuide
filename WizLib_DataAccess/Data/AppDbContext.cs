using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.FluentConfig;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BookDetailsFromView> BookDetailsFromView { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<FluentBook> FluentBooks { get; set; }
        public DbSet<FluentBookDetail> FluentBookDetails { get; set; }
        public DbSet<FluentAuthor> FluentAuthors { get; set; }
        public DbSet<FluentPublisher> FluentPublishers { get; set; }
        // public DbSet<FluentBookAuthor> FluentBookAuthors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category table name an column name
            modelBuilder.Entity<Category>().ToTable("tbl_category");
            modelBuilder.Entity<Category>().Property(c => c.Name).HasColumnName("CategoryName");

            //composite key
            modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailsConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());

            modelBuilder.Entity<BookDetailsFromView>().HasNoKey().ToView("GetOnlyBookDetails");
        }
    }
}