using Coolblue.API.Models;
using Coolblue.API.Repository;

namespace Coolblue.API.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }
        public  ProductType GetProductTypeById(int id)
        {
            return _productTypeRepository.GetProductType(id);
        }
    }
}
