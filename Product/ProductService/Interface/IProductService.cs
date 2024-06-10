using Product.Common;
using Product.Models.ViewModels;

namespace Product.Service.Interface
{
    public interface IProductService
    {
        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns></returns>
        public Task<Result> GetList(ProductSearchInfo info);

        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>   
        public Task<Result> Get(int id);

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <returns></returns>
        public Task<Result> Insert(ProductInfo info);

        /// <summary>
        /// 更新產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <param name="parameter">產品參數</param>
        /// <returns></returns>
        public Task<Result> Update(int id ,ProductInfo info);

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>
        public Task<Result> Delete(int id);
    }
}
