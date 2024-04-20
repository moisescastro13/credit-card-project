namespace ReportService.Models;

public class Response
{
    public IEnumerable<Transaction> Transactions { get; set; }
    public CreditCardDetails CreditCardDetails { get; set; }
}
