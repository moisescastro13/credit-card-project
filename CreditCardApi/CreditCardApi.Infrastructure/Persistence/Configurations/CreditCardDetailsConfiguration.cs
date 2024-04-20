using CreditCardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreditCardApi.Infrastructure.Persistence.Configurations;

internal class CreditCardDetailsConfiguration : IEntityTypeConfiguration<CreditCardDetails>
{
    public void Configure(EntityTypeBuilder<CreditCardDetails> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).HasConversion(x => x.value, x => new CreditCardDetailsID(x));

        builder.Property(x => x.CreditCardType).HasConversion(x => (int) x, x => (CreditCardType) x);

        builder.Property(x => x.balance).HasColumnType("Money");
        builder.Property(x => x.Currentbalance).HasColumnType("Money");
        builder.Property(x => x.CurrentInterest).HasColumnType("Money");
        builder.Property(x => x.MinimumFee).HasColumnType("Money");

    builder.Ignore(x => x.CreditableInterest);
        builder.Ignore(x => x.MinimumFeeToPay);
    }
}
