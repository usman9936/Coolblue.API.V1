using Coolblue.API.Helper;
using Coolblue.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Coolblue.API.Repository
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        public ProductType GetProductType(int Id)
        {
            string filePath = "Resources\\ProductTypes.json";
            var jsonData = JsonFileReadingHelper.ReadJsonFile(filePath);
            if (jsonData != null)
            {
                ProductType productType = JsonConvert.DeserializeObject<List<ProductType>>(jsonData).FirstOrDefault(y => y.Id == Id); //deserialize object as a ProductTypes of users in accordance with ProductTypes.json file
                return productType;
            }
            return null;
        }
    }
}
