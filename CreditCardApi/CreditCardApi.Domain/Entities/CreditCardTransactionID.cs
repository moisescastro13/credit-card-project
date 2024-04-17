
namespace CreditCardApi.Domain.Entities;

public record CreditCardTransactionID : BaseRecordID
{
    private readonly long _value;
    public CreditCardTransactionID(long value)
    {
        _value = value;
    }

    public long value => _value;
}
