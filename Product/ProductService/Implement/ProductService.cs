using AutoMapper;
using Product.Common;
using Product.Models.Entity;
using Product.Models.ViewModels;
using Product.Repository.Interface;
using Product.Service.Dtos.Dto;
using Product.Service.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Product.Service.Implement
{
    public class ProductService(IProductRepository productRepository, IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;
        private readonly Result _result = new();

        public async Task<Result> Delete(int id)
        {
            bool isSuccess = await _productRepository.Delete(id);

            _result.Success = isSuccess;

            _result.HttpCode = GetHttpStatusCode(ActionCode.Delete, isSuccess);

            return _result;
        }

        public async Task<Result> Get(int id)
        {
            var data = await _productRepository.Get(id);

            _result.Data = data;

            _result.HttpCode = GetHttpStatusCode(ActionCode.Read, isSuccess: data != null);

            return _result;
        }

        public async Task<Result> GetList(ProductSearchInfo info)
        {
            var condition = _mapper.Map<ProductSearchInfo, ProductSearchCondition>(info);

            var data = await _productRepository.GetList(condition);

            _result.Data = _mapper.Map<IEnumerable<ProductEntity>,IEnumerable<ProductInfo>>(data);

            _result.HttpCode = GetHttpStatusCode(ActionCode.Read, isSuccess: data.Any());

            return _result;
        }

        public async Task<Result> Insert(ProductInfo info)
        {
            var insetData = _mapper.Map<ProductInfo, ProductEntity>(info);

            bool isSuccess = await _productRepository.Insert(insetData);

            _result.Success = isSuccess;

            _result.HttpCode = GetHttpStatusCode(ActionCode.Insert, isSuccess);

            return _result;
        }

        public async Task<Result> Update(int id, ProductInfo info)
        {
            var updateData = _mapper.Map<ProductInfo, ProductEntity>(info);

            updateData.Id = id;

            bool isSuccess = await _productRepository.Update(updateData);

            _result.Success = isSuccess; 

            _result.HttpCode = GetHttpStatusCode(ActionCode.Update, isSuccess);

            return _result;
        }

        /// <summary>
        /// 取得相對回應狀態碼(粗略設計後續可依據實際應用撰寫)
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public HttpCode GetHttpStatusCode(ActionCode actionCode, bool isSuccess)
        {
            switch (actionCode)
            {
                case ActionCode.Insert:
                    return isSuccess ? HttpCode.Created : HttpCode.InternalServerError;
                case ActionCode.Read:
                    return isSuccess ? HttpCode.Ok : HttpCode.NotFound;
                case ActionCode.Update:
                    return isSuccess ? HttpCode.Ok : HttpCode.InternalServerError;
                case ActionCode.Delete:
                    return isSuccess ? HttpCode.Ok : HttpCode.InternalServerError;
                default:
                    return HttpCode.InternalServerError;
            }
        }
    }
}
