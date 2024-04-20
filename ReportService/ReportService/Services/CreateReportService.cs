using Dapper;
using ReportService.Interfaces;
using ReportService.Models;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace ReportService.Services;

public class CreateReportService : IReportService
{
    private readonly IDbContext _context;

    public CreateReportService(IDbContext context)
    {
        _context = context;
    }

    public async Task<Response> Execute(Guid CreditCardId)
    {
        Response response = new Response();

        var parameters = new DynamicParameters();
        parameters.Add("@CreditCardId", CreditCardId);

        using IDbConnection conn = _context.CreateConnection();
        using var multi = await conn.QueryMultipleAsync("CreateTransactionReport", parameters, commandType: CommandType.StoredProcedure);

        response.Transactions = await multi.ReadAsync<Transaction>();
        response.CreditCardDetails = await multi.ReadFirstOrDefaultAsync<CreditCardDetails>();

        return response;
    }

    public async Task<MemoryStream> ExecutePDF(Guid CreditCardId)
    {
        var response = await Execute(CreditCardId);

        PdfDocument document = new PdfDocument();

        PdfPage page = document.AddPage();

        XGraphics gfx = XGraphics.FromPdfPage(page);

        XFont font = new XFont("Verdana", 20);

        gfx.DrawString("¡Hola, mundo!", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

        var stream = new MemoryStream();

        document.Save(stream, false);
        stream.Seek(0, SeekOrigin.Begin);

        //return File(, "application/pdf", "archivo.pdf");
        return stream;
    }
}
