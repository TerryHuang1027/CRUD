

namespace Product.Service.Dtos.Dto
{
    public class ProductSearchCondition
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Cost { get; set; }
        public int? MinCost { get; set; }
        public int? MaxCost { get; set; }
    }
}
