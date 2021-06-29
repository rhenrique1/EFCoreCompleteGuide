using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
        {
            //Book
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.Price).IsRequired();

            //one to one relation between book and book detail
            modelBuilder.HasOne(b => b.BookDetail).WithOne(b => b.Book).HasForeignKey<FluentBook>("BookDetailId");

            //one to many relation between book and publisher       
            modelBuilder.HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey(b => b.PublisherId);
        }
    }
}