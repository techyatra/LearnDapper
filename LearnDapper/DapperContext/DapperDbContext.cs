using Microsoft.Data.SqlClient;
using System.Data;

namespace LearnDapper.DapperContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connctionString;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            connctionString = _configuration.GetConnectionString("Database");
        }

        public IDbConnection CreateConnection() => new SqlConnection(connctionString);
    }
}
