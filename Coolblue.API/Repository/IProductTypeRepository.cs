using Coolblue.API.Models;

namespace Coolblue.API.Repository
{
    public interface IProductTypeRepository
    {
        ProductType GetProductType(int Id);
    }
}
