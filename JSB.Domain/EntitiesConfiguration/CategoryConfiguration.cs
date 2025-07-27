using JSB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSB.Domain.EntitiesConfiguration
{
   public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {

        void IEntityTypeConfiguration<Category>.Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Categories");

            builder.HasMany(x => x.Books)
              .WithOne(x => x.category)
              .HasForeignKey(x => x.CategoryId);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(400);

          

            builder.HasCheckConstraint("CK_Categories_Name_NotEmpty", "[Name] <> ''");
            builder.HasCheckConstraint("CK_Categories_Description_NotEmpty", "[Description] <> ''");


        }
    }
}
