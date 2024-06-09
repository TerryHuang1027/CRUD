using Dapper;
using Product.Common;
using Product.Service.Dtos.Dto;
using Product.Repository.Interface;
using System.Data;
using Microsoft.Extensions.Configuration;
using Product.Models.Entity;

namespace Product.Repository.Implement
{
    public class ProductRepository(IConfiguration configuration) : BaseRepository(configuration), IProductRepository
    {
        public async Task<ProductEntity?> Get(int id)
        {
            string sqlCmd = @$"SELECT p.* FROM Product p
                            WHERE p.Id = @Id";

            IEnumerable<ProductEntity> result = await QueryAsync<ProductEntity>(sqlCmd, new { Id = id });

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ProductEntity>> GetList(ProductSearchCondition condition)
        {
            string sqlCmd = @$"SELECT * FROM Product";

            var sqlQuery = new List<string>();
            var parameter = new DynamicParameters();

            if (condition.MinCost.HasValue)
            {
                sqlQuery.Add($"Cost >= @MinCost ");
            }

            if (condition.MaxCost.HasValue)
            {
                sqlQuery.Add($"Cost <= @MaxCost ");
            }

            if (string.IsNullOrWhiteSpace(condition.Name) is false)
            {
                sqlQuery.Add($"Name = @Name ");
            }

            if (sqlQuery.Count != 0)
            {
                sqlCmd += $" WHERE {string.Join(" AND ", sqlQuery)} ";
            }

            IEnumerable<ProductEntity> result = await QueryAsync<ProductEntity>(sqlCmd, condition);

            return result.ToList();
        }

        public async Task<bool> Insert(ProductEntity insetData)
        {
            string sqlCmd = @$"INSERT INTO Product                                                                                           
                            (Name ,Description,Cost) VALUES ( @Name ,@Description,@Cost)";

            return await ExecuteAsync(sqlCmd, insetData);
        }

        public async Task<bool> Update(ProductEntity updateData)
        {
            string sqlCmd = @$"UPDATE Product
                            SET Name = @Name,
                            Description = @Description,
                            Cost = @Cost
                            WHERE Id = @Id";

            return await ExecuteAsync(sqlCmd, updateData);
        }

        public async Task<bool> Delete(int id)
        {
            string sqlCmd = @$"DELETE FROM Product WHERE Id = @Id";

            return await ExecuteAsync(sqlCmd,new { id });
        }
    }
}
