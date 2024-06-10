using Product.Models.Entity;
using Microsoft.Extensions.Configuration;
using Product.Repository.Implement;

namespace CRUDTest
{
    public class Tests
    {
        public class ProductRepositoryTests
        {
            private IConfiguration _configuration;
            private ProductRepository _repository;
            [SetUp]
            public void Setup()
            {
                _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
                _repository = new ProductRepository(_configuration);
            }

            [Test]
            public async Task Get_Returns_Product()
            {
                // Arrange
                var id = 2;

                // Act
                var product = await _repository.Get(id);

                // Assert
                Assert.IsNotNull(product);                                         
            }

            [Test]
            public async Task Update_Product_Returns_Success()
            {
                // Arrange
                var condition = new ProductEntity { Id = 10,Name = "´ú¸Õ­×§ï"};

                // Act
                var productList = await _repository.Update(condition);

                // Assert
                Assert.IsTrue(productList);
            }
        }
    }
}