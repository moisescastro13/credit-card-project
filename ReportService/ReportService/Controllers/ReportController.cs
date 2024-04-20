using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Interfaces;

namespace ReportService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("/{CreditCardId}")]
        public async Task<IActionResult> Execute(Guid CreditCardId) => Ok( await _reportService.Execute(CreditCardId) );
    }
}
