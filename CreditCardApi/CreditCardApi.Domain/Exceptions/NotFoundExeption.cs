namespace CreditCardApi.Domain.Exceptions
{
    public class NotFoundExeption : BaseExeption
    {
        public NotFoundExeption(string message, int httpStatusCode) : base(httpStatusCode, message)
        {
        }
    }
}
