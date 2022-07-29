using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLS.Domain;

namespace QLS.Infrastructure.Data.Config;


public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(s => new { s.Id, s.Email, s.Password })
            .IsUnique()
            .HasFilter(null);
    }
}
