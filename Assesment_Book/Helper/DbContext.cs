using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Assesment_Book.Helper
{
    public class DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Connstr");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
