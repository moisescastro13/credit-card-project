
namespace CreditCardApi.Domain.Entities;

public record CreditCardTransactionID : BaseRecordID
{
    private readonly Guid _value;
    public CreditCardTransactionID(Guid value)
    {
        _value = value;
    }

    public Guid value => _value;
}
