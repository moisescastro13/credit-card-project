namespace CreditCardApi.Domain.Entities;
public record CreditCardDetailsID : BaseRecordID
{
    private readonly Guid _value;
    public CreditCardDetailsID(Guid value)
    {
        _value = value;
    }

    public Guid value => _value;
}


