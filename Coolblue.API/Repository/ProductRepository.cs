
using Coolblue.API.Helper;
using Coolblue.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Coolblue.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(int Id)
        {
            string filePath = "Resources\\Products.json";
            var jsonData = JsonFileReadingHelper.ReadJsonFile(filePath);
            if (jsonData != null)
            {
                Product product = (Product)JsonConvert.DeserializeObject<List<Product>>(jsonData).FirstOrDefault(x => x.Id == Id); //deserialize object as a list of Products in accordance with Products.json file
                return product;
            }
            return null;
        }
    }
}
