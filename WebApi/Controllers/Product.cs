using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Product: ControllerBase
    {
        [HttpGet]
        public List<Models.Product.Product> GetProduct()
        {
            return new List<Models.Product.Product>();
        }

        [HttpPost]
        public void Create(List<Models.Product.Product> products)
        {

        }

        [HttpPut]
        public void Update(List<Models.Product.Product> products)
        {

        }

        [HttpDelete]
        public void Delete(int id) { }

        [HttpPut]
        public void UpdateInventory()
        {

        }
        [HttpGet]
        public void GetProductInventory()
        {

        }
    }
}
