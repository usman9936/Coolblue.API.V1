using Coolblue.API.Models;
using Coolblue.API.Repository;
using System.Threading.Tasks;

namespace Coolblue.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRespository;
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductService(IProductRepository productRespository, IProductTypeRepository productTypeRepository)
        {
            _productRespository = productRespository;
            _productTypeRepository = productTypeRepository;
        }

        public Product GetProductById(int id)
        {
            var product = _productRespository.GetProduct(id);
            if (product != null)
            {
                product.ProductType =  _productTypeRepository.GetProductType(product.ProductTypeId); //Include ProductType info
                return product;
            }
            return null;
        }
        public double CalculcateInsurance(Product product)
        {
            double insuranceCost = 0;
            if (product.ProductType != null && product.ProductType.CanBeInsured)
            {
                if (product.SalesPrice < 500)
                {
                    insuranceCost = 0;
                }
                else if (product.SalesPrice >= 500 && product.SalesPrice < 2000)
                {
                    insuranceCost = 1000;
                }
                else if (product.SalesPrice >= 2000)
                {
                    insuranceCost = 2000;
                }

                if (product.ProductType.Id == 21 || product.ProductType.Id == 32)
                    insuranceCost += 500;
            }
            return insuranceCost;
        }
    }
}
