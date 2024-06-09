using Dapper;
using System.Data;

namespace Product.Common
{
    public class BaseRepository
    {
        readonly IDepUnitOfWork _unitOfWork;
        public IDepUnitOfWork UnitOfWork => _unitOfWork;
        public BaseRepository(IDepUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        /// <summary>
        /// 非同步查詢
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, CommandType cmdType, object? param = null, IDbTransaction? transaction = null)
        {
            IEnumerable<T> result;
            using (var conn = _unitOfWork.GenConnection())
            {
                conn.Open();
                result = await conn.QueryAsync<T>(sql, param: param, commandType: cmdType, transaction: transaction);
            }
            return result;
        }

        /// <summary>
        /// 非同步異動數據
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="dbTran"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public async Task<bool> ExecuteAsync(string sql, CommandType cmdType, IDbTransaction? dbTran = null, object? param = null)
        {
            int result;
            using (var conn = _unitOfWork.GenConnection())
            {
                conn.Open();
                result = await conn.ExecuteAsync(sql, param: param, commandType: cmdType, transaction: dbTran);
            }
            return result > 0;
        }
    }
}
