using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Interfaces;
using ReportService.Models;

namespace ReportService.Controllers
{
    [Route("Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Execute([FromQuery] ReportQuery reportQuery) => 
            Ok( await _reportService.Execute(reportQuery));
    }
}
