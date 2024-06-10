using Product.Models.Entity;
using Product.Models.ViewModels;

namespace Product.Repository.Interface
{
    public interface IProductRepository
    {
        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ProductEntity>> GetList(ProductSearchCondition condition);

        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>   
        public Task<ProductEntity?> Get(int id);

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="parameter">產品參數</param>
        /// <returns></returns>
        public Task<bool> Insert(ProductEntity info);

        /// <summary>
        /// 更新產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <param name="parameter">產品參數</param>
        /// <returns></returns>
        public Task<bool> Update(ProductEntity info);

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>
        public Task<bool> Delete(int id);
    }
}
