
namespace CreditCardApi.Domain.Entities
{
 
    public record CreditCardID : BaseRecordID
    {
        private readonly long _value;
        public CreditCardID(long value)
        {
            _value = value;
        }

        public long value => _value;

    }
}
