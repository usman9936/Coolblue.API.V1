using Coolblue.API.Models;

namespace Coolblue.API.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
    }
}
