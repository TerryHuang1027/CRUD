using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.Common;
using Product.Models.ViewModels;
using Product.Service.Dtos.Dto;
using Product.Service.Interface;

namespace Product.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        [Produces("application/json")]
        public async Task<Result> Search([FromQuery] ProductSearchInfo searchInfo)
        {
            var result = await _productService.GetList(searchInfo);

            return result;
        }

        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<Result> Get(int id)
        {
            var result = await _productService.Get(id);

            return result;
        }

        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        public async Task<Result> Insert(ProductInfo info)
        {
            var result = await _productService.Insert(info);

            return result;
        }

        /// <summary>
        /// 更新產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces("application/json")]
        public async Task<Result> Update(int id , ProductInfo info)
        {
            var result = await _productService.Update(id ,info);

            return result;
        }

        /// <summary>
        /// 刪除產品
        /// </summary>
        /// <param name="id">產品編號</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces("application/json")]
        public async Task<Result> Delete(int id)
        {
            var result = await _productService.Delete(id);

            return result;
        }
    }
}
