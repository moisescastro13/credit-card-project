using Microsoft.Data.SqlClient;
using ReportService.Interfaces;
using System.Data;

namespace ReportService.Database
{
    public class DbContext: IDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly IDbConnection _connection;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection")!;
            _connection = new SqlConnection(_connectionString)!;
        }
        public IDbConnection CreateConnection() => _connection;
        public IDbTransaction DBTransaction => _connection.BeginTransaction();
        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
