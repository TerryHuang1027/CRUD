using AutoMapper;
using Product.Models.Entity;
using Product.Models.ViewModels;
using Product.Service.Dtos.Dto;

namespace Product.Service.Mappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<ProductInfo, ProductEntity>();
            CreateMap<ProductEntity, ProductInfo>();
            CreateMap<ProductSearchInfo, ProductSearchCondition>();
        }
    }
}
