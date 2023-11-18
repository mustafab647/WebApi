using Microsoft.AspNetCore.Mvc;
using ESCore.Model.Product;
using ESCore.ESContext;
using WebApi.Attribute;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ESDBContext _context;
        public ProductController(ESDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ErrorHandlingFilter]
        public List<Product> GetProduct()
        {
            List<Product> result = _context.Products.ToList();
            return result;
        }

        [HttpPost]
        [ErrorHandlingFilter]
        public List<Models.Result> Create(List<Models.ProductModels.ProductModel> products)
        {
            List<Models.Result> result = new List<Models.Result>();
            PrepareData.ProductPrepare productPrepare = new PrepareData.ProductPrepare(_context);
            foreach (Models.ProductModels.ProductModel product in products)
            {
                try
                {
                    var r = productPrepare.PrepareProduct(product);
                    _context.Products.Add(r);

                }
                catch (Exception ex)
                {

                }

            }

            _context.SaveChanges(true);
            return result;
        }

        [HttpPut]
        [ErrorHandlingFilter]
        public void Update(List<Product> products)
        {

        }

        [HttpDelete]
        [ErrorHandlingFilter]
        public void Delete(int id) { }

        [HttpPut]
        [ErrorHandlingFilter]
        public void UpdateInventory()
        {

        }
        [HttpGet]
        [ErrorHandlingFilter]
        public void GetProductInventory()
        {

        }
    }
}
