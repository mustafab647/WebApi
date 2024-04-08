using Microsoft.AspNetCore.Mvc;
using ESCore.Model.Product;
using ESCore.ESContext;
using WebApi.Attributes;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using System.Data.Entity;
using System.Transactions;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ESDBContext _context;
        private readonly ProductContext _productContext;
        private readonly ProductVariantContext _variantContext;
        public ProductController(ESDBContext context, ProductContext productContext, ProductVariantContext variantContext)
        {
            _context = context;
            _productContext = productContext;
            _variantContext = variantContext;
        }

        [HttpPost]
        [ErrorHandlingFilter]
        [Authorize]
        public List<object> GetProduct(object req)
        {
            
            var expression =Helper.ReqProperties.GetExpression<Product>(req,true);
            List<object> result;
            
            result = _productContext.Products.AsNoTracking<Product>().Select(expression).ToList();
            return result;
        }

        [HttpGet]
        [ErrorHandlingFilter]
        [Authorize]
        public List<Product> GetProduct()
        {
            return _productContext.Products.AsNoTracking<Product>().ToList();
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
        [HttpPost]
        [ErrorHandlingFilter]
        public IActionResult CreateVariantType(string variantType)
        {
            if (_context.VariantTypes.Any(x => x.Name == variantType))
                throw new ResultException($"Allready has {variantType} variant");
            VariantType variant = new VariantType();
            variant.Name = variantType;
            _context.VariantTypes.Add(variant);
            _context.SaveChanges();
            return new JsonResult(variantType);
        }

        [HttpPost]
        [ErrorHandlingFilter]
        public IActionResult CreateVariantValue(int variantTypeId, string variantValue)
        {
            if (variantTypeId == 0)
                throw new ResultException("Cannot have variantTypeId 0 value");
            if (string.IsNullOrEmpty(variantValue))
                throw new ResultException("Cannot have variantValue null or empty value");
            if (_context.VariantTypeValues.Any(x => x.VariantTypeId == variantTypeId && x.VariantName == variantValue))
                throw new ResultException($"Allready has {variantValue} value on {variantTypeId}");
            VariantTypeValue variantTypeValue = new VariantTypeValue();
            variantTypeValue.VariantTypeId = variantTypeId;
            variantTypeValue.VariantName = variantValue;
            _context.VariantTypeValues.Add(variantTypeValue);
            _context.SaveChanges();
            return new JsonResult(variantTypeValue);
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
