
namespace CreditCardApi.Domain.Entities;


public record CreditCardID : BaseRecordID
{
    private readonly Guid _value;
    public CreditCardID(Guid value)
    {
        _value = value;
    }

    public Guid value => _value;

}
