using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Interfaces;
using ReportService.Models;

namespace ReportService.Controllers
{
    [Route("Report")]
    [ApiController]
    public class ReportPDFController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportPDFController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("/pdf/")]
        public async Task<IActionResult> Run([FromQuery] ReportQuery reportQuery)
        {
            var bytes = await _reportService.ExecutePDF(reportQuery);

            return File(bytes.ToArray(), "application/pdf", "EstadoDeCuenta.pdf");
        }
    }
}
