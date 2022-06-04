using Blog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "blog");

            builder.HasIndex(e => e.Email, "uq_blogusers_email")
                .IsUnique();

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("uuid_generate_v4()");

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name")
                .HasDefaultValueSql("NULL::character varying");

            builder.Property(e => e.IsActive).HasColumnName("is_active");

            builder.Property(e => e.IsAdmin).HasColumnName("is_admin");

            builder.Property(e => e.LastLogin)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_login");

            builder.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name")
                .HasDefaultValueSql("NULL::character varying");

            // builder.Property(e => e.Password)
            //     .HasMaxLength(255)
            //     .HasColumnName("password");

            builder.Property(e => e.PasswordSalt)
                .HasColumnName("password_salt");

            builder.Property(e => e.PasswordHash)
                .HasColumnName("password_hash");

            builder.Property(e => e.RegisteredAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("registered_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at")
                .HasDefaultValueSql("now()");

            builder.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        }
    }
}