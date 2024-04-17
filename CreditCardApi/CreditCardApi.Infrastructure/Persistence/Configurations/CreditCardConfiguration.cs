using CreditCardApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CreditCardApi.Infrastructure.Persistence.Configurations;
internal class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
{
    public void Configure(EntityTypeBuilder<CreditCard> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.value, x => new CreditCardID(x));

        builder.Property(x => x.CVV).HasMaxLength(3);

        builder.HasOne(x => x.CreditCardDetails)
            .WithOne(x => x.CreditCard)
            .HasForeignKey<CreditCardDetails>(x => x.CreditCarID);

        builder.HasMany(x => x.CreditCardTransactions)
            .WithOne()
            .HasForeignKey(x => x.CreditCardID);

        builder.Ignore(x => x.CreditCardTransactions);

    }
}

