namespace CreditCardApi.Domain.Exceptions
{
    public class NotEnoughMoneyException : BaseExeption
    {
        public NotEnoughMoneyException(string message, int httpStatusCode) : base(httpStatusCode, message)
        {
        }
    }
}
