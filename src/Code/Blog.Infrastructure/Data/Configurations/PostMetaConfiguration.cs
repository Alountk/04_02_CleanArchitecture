using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations
{
    public class PostMetaConfiguration : IEntityTypeConfiguration<PostMeta>
    {
        public void Configure(EntityTypeBuilder<PostMeta> builder)
        {
            // builder.ToTable("post_metas", "blog");

            // builder.Property(e => e.Id)
            //     .HasColumnName("id")
            //     .HasDefaultValueSql("uuid_generate_v4()");

            // builder.Property(e => e.MetaKey)
            //     .HasMaxLength(100)
            //     .HasColumnName("meta_key");

            // builder.Property(e => e.MetaValue).HasColumnName("meta_value");

            // builder.Property(e => e.PostId).HasColumnName("post_id");

            // builder.HasOne(d => d.Post)
            //     .WithMany(p => p.PostMeta)
            //     .HasForeignKey(d => d.PostId)
            //     .OnDelete(DeleteBehavior.ClientSetNull)
            //     .HasConstraintName("fk_blogpostmeta_post");
        }
    }
}