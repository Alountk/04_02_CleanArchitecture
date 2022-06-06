using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("post_comments", "blog");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.CategoryId)
                .HasColumnName("category_id");

            builder.Property(e => e.AuthorId)
                .HasColumnName("author_id");

            builder.Property(e => e.Content).HasColumnName("content");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.CategoryId).HasColumnName("category_id");

            builder.Property(e => e.PostId).HasColumnName("post_id");

            builder.Property(e => e.Published).HasColumnName("published");

            builder.Property(e => e.PublishedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("published_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("update_at");

            builder.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        }
    }
}