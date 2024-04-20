using Aspose.Pdf;
using Aspose.Pdf.Text;
using Dapper;
using ReportService.Interfaces;
using ReportService.Models;
using System.Data;

namespace ReportService.Services;

public class CreateReportService : IReportService
{
    private readonly IDbContext _context;

    public CreateReportService(IDbContext context)
    {
        _context = context;
    }

    public async Task<Response> Execute(ReportQuery reportQuery)
    {
        Response response = new Response();

        var parameters = new DynamicParameters();
        parameters.Add("@CreditCardId", reportQuery.CreditCardId);
        parameters.Add("@FromDate", reportQuery.FromDate);

        using IDbConnection conn = _context.CreateConnection();
        using var multi = await conn.QueryMultipleAsync("CreateTransactionReport", parameters, commandType: CommandType.StoredProcedure);

        response.Transactions = await multi.ReadAsync<Transaction>();
        response.CreditCardDetails = await multi.ReadFirstOrDefaultAsync<CreditCardDetails>();

        return response;
    }

    public async Task<IEnumerable<Byte>> ExecutePDF(ReportQuery reportQuery)
    {
        var response = await Execute(reportQuery);

        using Document pdfDocument = new Document();

        Page page = pdfDocument.Pages.Add();

        AddText($"Saldo: {response.CreditCardDetails.balance}\n", page);
        AddText($"Total a pagar: {response.CreditCardDetails.Currentbalance}\n", page);
        AddText($"Interes : {response.CreditCardDetails.Interest}\n", page);
        AddText($"Transacciones:\n\n", page);

        Table table = new Table
        {
            ColumnWidths = "110 60 130 70 90"
        };

        Row headerRow = table.Rows.Add();
        headerRow.Cells.Add("Concepto");
        headerRow.Cells.Add("Monto");
        headerRow.Cells.Add("Fecha de Transaccion");
        headerRow.Cells.Add("Saldo Anterior");
        headerRow.Cells.Add("Saldo");

        foreach (var transaction in response.Transactions)
        {
            Row dataRow = table.Rows.Add();
            dataRow.Cells.Add(transaction.Concept);
            dataRow.Cells.Add($"${transaction.Amount.ToString("N2")}");
            dataRow.Cells.Add(transaction.TransactionDate.ToString("yyyy/MM/dd hh:mm:ss tt"));
            dataRow.Cells.Add(transaction.OldBalance.ToString());
            dataRow.Cells.Add(transaction.NewBalance.ToString());
           foreach(TextFragment textFragment in dataRow.Cells[1].Paragraphs)
            {
                textFragment.TextState.ForegroundColor = transaction.TransactionType == 1 ? Color.Red : Color.Green;
                textFragment.TextState.FontStyle = FontStyles.Bold;
            }
        }

        page.Paragraphs.Add(table);

        using MemoryStream memoryStream = new MemoryStream();

        pdfDocument.Save(memoryStream);

        return memoryStream.ToArray();
    }
    private void AddText(string text, Page page) => page.Paragraphs.Add(new TextFragment(text));

}
