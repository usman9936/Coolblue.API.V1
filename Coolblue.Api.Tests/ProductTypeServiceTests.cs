using Coolblue.API.Models;
using Coolblue.API.Repository;
using Coolblue.API.Services;
using Moq;
using Xunit;

namespace Coolblue.Api.Tests
{
    public class ProductTypeServiceTests
    {
        private readonly Mock<IProductTypeRepository> _productTypeRespositoryMock = new Mock<IProductTypeRepository>();

        private readonly IProductTypeService _productTypeService;
        public ProductTypeServiceTests()
        {
            _productTypeService = new ProductTypeService(_productTypeRespositoryMock.Object);
        }

        [Theory]
        [InlineData(124)]
        public void Get_WhenCalled_Get_WhenCalled_ReturnsCorrect_ProductType(int id)
        {
            //Arrange
            int expected = 124;
            _productTypeRespositoryMock.Setup(x => x.GetProductType(124)).Returns(new ProductType()
            {
                    Id = 124,
                    Name = "Washing machines",
                    CanBeInsured = true
            });

            // Act
            var actual = _productTypeService.GetProductTypeById(id).Id;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            _productTypeRespositoryMock.Setup(x => x.GetProductType(124)).Returns(new ProductType()
            {
                    Id = 124,
                    Name = "Washing machines",
                    CanBeInsured = true
            });

            // Act
            var notFoundResult = _productTypeService.GetProductTypeById(0);

            // Assert
            Assert.Null(notFoundResult);
        }
    }
}
