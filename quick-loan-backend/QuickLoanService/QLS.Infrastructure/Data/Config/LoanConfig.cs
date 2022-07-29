using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QLS.Domain.Entity;

namespace QLS.Infrastructure.Data.Config;

public class LoanConfig : IEntityTypeConfiguration<Loans>
{
    public void Configure(EntityTypeBuilder<Loans> builder)
    {
        builder.HasIndex(s => new { s.Id })
            .IsUnique()
            .HasFilter(null);
    }
}
