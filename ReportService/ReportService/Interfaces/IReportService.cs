using ReportService.Models;

namespace ReportService.Interfaces;

public interface IReportService
{
    Task<Response> Execute(ReportQuery reportQuery);
    Task<IEnumerable<Byte>> ExecutePDF(ReportQuery reportQuery);
}
