using AutoMapper;
using Product.Models.Entity;
using Product.Models.ViewModels;

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
