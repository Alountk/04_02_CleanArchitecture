using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            // builder.ToTable("post_categories", "blog");

            // builder.Property(e => e.Id)
            //     .HasColumnName("id")
            //     .HasDefaultValueSql("uuid_generate_v4()");

            // builder.Property(e => e.CategoryId).HasColumnName("category_id");

            // builder.HasOne(d => d.Category)
            //     .WithMany(p => p.PostCategories)
            //     .HasForeignKey(d => d.CategoryId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("fk_blogpostcategory_category");
        }
    }
}