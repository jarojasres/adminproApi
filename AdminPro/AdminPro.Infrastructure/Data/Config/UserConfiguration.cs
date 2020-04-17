using AdminPro.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdminPro.Infrastructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(a => a.Email)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(a => a.Role)
                .HasMaxLength(100);
        }
    }
}
