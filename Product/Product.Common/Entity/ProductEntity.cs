using Dapper.Contrib.Extensions;

namespace Product.Models.Entity
{
    public class ProductEntity
    {
        [Computed]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Cost { get; set; }
    }
}
