using Microsoft.AspNetCore.Mvc;
using ESCore.Model.Product;
using ESCore.ESContext;
using WebApi.Attribute;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ESDBContext _context;
        public ProductController(ESDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ErrorHandlingFilter]
        [Authorize]
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
                Models.Result resultPair = new Models.Result();
                resultPair.Success = true;
                resultPair.Headers = new Dictionary<string, string>();
                resultPair.Headers.Add("ProductCode", product.Code);
                try
                {
                    var r = productPrepare.PrepareProduct(product);
                    _context.Products.Add(r);
                    resultPair.Success = true;
                }
                catch (Exception ex)
                {
                    resultPair.Success = false;
                    resultPair.Error = ex.Message;
                }
                finally
                {
                    result.Add(resultPair);
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
