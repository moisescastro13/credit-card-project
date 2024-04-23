

namespace CreditCardApi.Domain.Exceptions;

public class BaseExeption: Exception
{
    public BaseExeption(int httpStatusCode, string message): base(message)
    {
        HttpStatusCode = httpStatusCode;
    }

    public int HttpStatusCode { get; set; }
}
