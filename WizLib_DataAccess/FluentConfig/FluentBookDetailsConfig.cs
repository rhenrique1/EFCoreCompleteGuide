using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wizlib_Model.Models;

namespace WizLib_DataAccess.FluentConfig
{
    public class FluentBookDetailsConfig : IEntityTypeConfiguration<FluentBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
        {
            //BookDetails
            modelBuilder.HasKey(b => b.Id);
            modelBuilder.Property(b => b.NumberOfChapters).IsRequired();
        }
    }
}