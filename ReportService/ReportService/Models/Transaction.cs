namespace ReportService.Models;

public class Transaction
{
    public string Concept { get; set; }
    public int TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public double Amount { get; set; }
    public double OldBalance { get; set; }
    public double NewBalance { get; set; }
}
