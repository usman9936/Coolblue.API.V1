using Coolblue.API.Models;
using Coolblue.API.Repository;
using Coolblue.API.Services;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using System;

namespace Coolblue.Api.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRespositoryMock = new Mock<IProductRepository>();
        private readonly Mock<IProductTypeRepository> _productTypeRespositoryMock = new Mock<IProductTypeRepository>();

        private readonly IProductService _productService;
        public ProductServiceTests()
        {
            _productService = new ProductService(_productRespositoryMock.Object, _productTypeRespositoryMock.Object);
        }

        [Theory]
        [InlineData(735246)]
        public void GetById_Returns_CorrectProduct(int id)
        {
            //Arrange
            int expected = 735246;
            _productRespositoryMock.Setup(x => x.GetProduct(735246)).Returns(new Product
            {
                Id = 735246,
                Name = "AEG L8FB86ES",
                SalesPrice = 699,
                ProductTypeId = 124
            });
            //Arrange
            _productTypeRespositoryMock.Setup(x => x.GetProductType(124)).Returns(new ProductType
            {
                Id = 124,
                Name = "Washing machines",
                CanBeInsured = true
            });
            // Act
            var actual = _productService.GetProductById(id).Id;

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetById_When_UnknownIdPassed_ReturnsNotFoundResult()
        {
            //Arrange
            _productRespositoryMock.Setup(x => x.GetProduct(735246)).Returns(new Product
            {
                Id = 735246,
                Name = "AEG L8FB86ES",
                SalesPrice = 699,
                ProductTypeId = 124
            });
            // Act
            var notFoundResult = _productService.GetProductById(1);
            // Assert
            Assert.Null(notFoundResult);
        }

        [Theory]
        [ClassData(typeof(InsuranceFunctionInLineData))]
        public void Get_WhenCalled_Returns_Zero_WhenCanbeInsured_False(List<Product> products)
        {
            //Arrange
            var expected = 0;
            var product = products.FirstOrDefault(x => x.Id == 11);
            // Act

            var actual = Convert.ToDouble(_productService.CalculcateInsurance(product));

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(InsuranceFunctionInLineData))]
        public void Get_WhenCalled_Returns_Zero_WhenProductSalesPrice_LessThan500(List<Product> products)
        {
            //Arrange
            var expected = 0;
            var product = products.FirstOrDefault(x => x.Id == 12);
            // Act

            var actual = Convert.ToDouble(_productService.CalculcateInsurance(product));

            // Assert

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_WhenCalled_Returns_1000_WhenProductSalesPrice_Between_500And2000()
        {
            //Arrange
            var expected = 1000;
            var product = new Product
            {
                Id = 15,
                Name = "AEG L8FB86ES",
                SalesPrice = 1500,
                ProductTypeId = 25,
                ProductType = new ProductType
                {
                    Id = 25,
                    Name = "Washing machines",
                    CanBeInsured = true

                }
            };
            // Act

            var actual = Convert.ToDouble(_productService.CalculcateInsurance(product));

            // Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(InsuranceFunctionInLineData))]
        public void Get_WhenCalled_Returns_2000_WhenProductSalesPrice_GreaterThan_2000(List<Product> products)
        {
            //Arrange
            var expected = 2000;
            var product = products.FirstOrDefault(x => x.Id == 13);

            // Act

            var actual = Convert.ToDouble(_productService.CalculcateInsurance(product));

            // Assert

            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(InsuranceFunctionInLineData))]
        public void Get_WhenCalled_Returns_InsuranceCost_WithAdditionalCost_When_ProductType_Laptop_Smartphone(List<Product> products)
        {
            //Arrange
            var expected = 2500;
            var product = products.FirstOrDefault(x => x.Id == 14);
            // Act

            var actual = Convert.ToDouble(_productService.CalculcateInsurance(product));

            // Assert

            Assert.Equal(expected, actual);
        }
    }

}
