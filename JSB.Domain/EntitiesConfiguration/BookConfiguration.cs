using JSB.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.EntitiesConfiguration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        void IEntityTypeConfiguration<Book>.Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Books");

            builder.HasOne(x => x.category)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x=> x.Author)
                .IsRequired()
                .HasMaxLength (50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.Stock)
                .IsRequired();

            

            builder.HasCheckConstraint("CK_Books_Price", "Price >= 0");
               builder.HasCheckConstraint("CK_Books_Stock", "Stock >= 0");
        }
    }
         
}
