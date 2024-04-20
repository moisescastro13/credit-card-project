using ReportService.Models;

namespace ReportService.Interfaces;

public interface IReportService
{
    Task<Response> Execute(Guid CreditCardId);
}
