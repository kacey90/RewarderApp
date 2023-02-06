using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rewarder.Domain.Vouchers;

namespace Rewarder.Infrastructure.Database;
internal class VoucherEntityTypeConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> builder)
    {
        builder.ToTable("Vouchers");
        builder.HasKey(x => x.Id);
    }
}
