namespace ReportService.Models;

public class Response
{
    public CreditCardDetails CreditCardDetails { get; set; }
    public IEnumerable<Transaction> Transactions { get; set; }
}
