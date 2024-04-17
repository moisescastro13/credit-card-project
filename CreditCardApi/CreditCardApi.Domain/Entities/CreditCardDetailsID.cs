namespace CreditCardApi.Domain.Entities;
public record CreditCardDetailsID : BaseRecordID
{
    private readonly long _value;
    public CreditCardDetailsID(long value)
    {
        _value = value;
    }

    public long value => _value;
}


