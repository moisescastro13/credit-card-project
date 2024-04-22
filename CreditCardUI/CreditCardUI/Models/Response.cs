namespace CreditCardUI.Models;

public class ReportResponse
{
    public CreditCardDetails CreditCardDetails { get; set; }
    public IEnumerable<Transaction> Transactions { get; set; }
}
public class CreditCardDetails
{
    public double balance { get; set; }
    public double Currentbalance { get; set; }
    public double Interest { get; set; }
}
public class Transaction
{
    public string Concept { get; set; }
    public int TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public double Amount { get; set; }
    public double OldBalance { get; set; }
    public double NewBalance { get; set; }
}