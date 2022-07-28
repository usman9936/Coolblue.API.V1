using Coolblue.API.Models;
using System.Threading.Tasks;

namespace Coolblue.API.Services
{
   public interface IProductTypeService
    {
        ProductType GetProductTypeById(int id);
    }
}
