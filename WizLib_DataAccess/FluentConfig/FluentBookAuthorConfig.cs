using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentBookAuthor> modelBuilder)
        {
            //many to many relation
            modelBuilder.HasKey(ba => new { ba.AuthorId, ba.BookId });

            modelBuilder.HasOne(b => b.Book).WithMany(b => b.BookAuthors).HasForeignKey(b => b.BookId);
            modelBuilder.HasOne(b => b.Author).WithMany(b => b.BookAuthors).HasForeignKey(b => b.AuthorId);
        }
    }
}