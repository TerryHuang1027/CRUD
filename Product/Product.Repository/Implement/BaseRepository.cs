using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Product.Repository.Interface;

namespace Product.Common
{
    public class BaseRepository(IConfiguration configuration) : IDepUnitOfWork
    {
        private readonly IConfiguration _configuration = configuration;

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
        {
            IEnumerable<T> result;
            using (var conn = GenConnection())
            {
                conn.Open();
                result = await conn.QueryAsync<T>(sql, param: param);
            }
            return result;
        }

        public async Task<bool> ExecuteAsync(string sql, object? param = null)
        {
            int result;
            using (var conn = GenConnection())
            {
                conn.Open();
                result = await conn.ExecuteAsync(sql, param: param);
            }
            return result > 0;
        }

        public IDbConnection GenConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
