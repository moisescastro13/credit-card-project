using System.Data;

namespace ReportService.Interfaces;

public interface IDbContext
{
    IDbConnection CreateConnection();
    IDbTransaction DBTransaction { get; }
}
