using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // builder.ToTable("categories", "blog");

            // builder.Property(e => e.Id)
            //     .HasColumnName("id")
            //     .HasDefaultValueSql("uuid_generate_v4()");

            // builder.Property(e => e.Content).HasColumnName("content");

            // builder.Property(e => e.MetaTitle)
            //     .HasMaxLength(100)
            //     .HasColumnName("meta_title");

            // builder.Property(e => e.ParentId).HasColumnName("parent_id");

            // builder.Property(e => e.Slug)
            //     .HasMaxLength(100)
            //     .HasColumnName("slug");

            // builder.Property(e => e.Title)
            //     .HasMaxLength(100)
            //     .HasColumnName("title");
        }
    }
}