using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Persistence.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts", "blog");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.AuthorId).HasColumnName("author_id");

            builder.Property(e => e.Content).HasColumnName("content");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.Property(e => e.MetaTitle)
                .HasMaxLength(100)
                .HasColumnName("meta_title");

            builder.Property(e => e.ParentId).HasColumnName("parent_id");

            builder.Property(e => e.Published).HasColumnName("published");

            builder.Property(e => e.PublishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.Slug)
                .HasMaxLength(100)
                .HasColumnName("slug");

            builder.Property(e => e.Summary).HasColumnName("summary");

            builder.Property(e => e.Title)
                .HasMaxLength(75)
                .HasColumnName("title");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("now()");
        }
    }
}