using ESCore.Model.Product;
using ESCore.ESContext;
using ESCore.Model;
using WebApi.Models;

namespace WebApi.PrepareData
{
    public class ProductPrepare
    {
        private readonly ESDBContext _context;
        public ProductPrepare(ESDBContext context)
        {
            _context = context;
        }

        public Product PrepareProduct(WebApi.Models.ProductModels.ProductModel product)
        {
            ESCore.Model.Product.Product result = new Product();

            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(product);
            result = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(jsonStr);
            result.Variants = getProductVariant(product.Variants);
            result.CurrencyId = getCurrency(product.CurrencyCode)?.Id ?? 0;
            result.Specifications = getSpecification(product.Specifications);
            //string jsonStr2 = Newtonsoft.Json.JsonConvert.SerializeObject(result);
            return result;
        }

        private List<ProductVariant> getProductVariant(List<Models.ProductModels.VariantModel> variantModels)
        {
            if (variantModels?.Count == 0)
                return null;
            string jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(variantModels);
            List<ProductVariant> result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductVariant>>(jsonStr);
            foreach (Models.ProductModels.VariantModel variantModel in variantModels)
            {
                ProductVariant productVariant = result.FirstOrDefault(x => x.Barcode == variantModel.Barcode);
                if (productVariant != null)
                {
                    productVariant.Id = _context.ProductVariants.FirstOrDefault(x => x.Barcode == variantModel.Barcode)?.Id ?? 0;
                    List<ProductVariantMap> variantValues = getProductVariantMap(variantModel.VariantValues, variantModel.Barcode);
                    productVariant.VariantMap = variantValues;
                }
            }

            return result;
        }

        private List<ProductSpecificationMap> getSpecification(List<Models.ProductModels.SpecificationModel> specificationModels)
        {
            List<ProductSpecificationMap> result = new List<ProductSpecificationMap>();

            foreach(var specificationModel in specificationModels)
            {
                ProductSpecificationMap specificationMap = new ProductSpecificationMap();
                var _spec = _context.Specifications.Where(x => x.Name == specificationModel.Type);
                var spec = _spec.FirstOrDefault(x=>x.Value == specificationModel.Value);
                if (_spec == null)
                    throw new ResultException($"Not found Specification Type {specificationModel.Type}");
                if (spec == null)
                    throw new ResultException($"Not found Specification {specificationModel.Type}:{specificationModel.Value}");
                specificationMap.SpecificationId = spec.Id;
                result.Add(specificationMap);
            }
            return result;
        }

        private List<ProductVariantMap> getProductVariantMap(List<Models.ProductModels.VariantValue> variantValues, string barcode)
        {
            List<ProductVariantMap> result = new List<ProductVariantMap>();
            foreach (Models.ProductModels.VariantValue variantValue in variantValues)
            {
                ProductVariantMap productVariantMap = new ProductVariantMap();
                productVariantMap.ProductVariantId = _context.ProductVariants.FirstOrDefault(x => x.Barcode == barcode)?.Id ?? 0;
                VariantType? variantType = _context.VariantTypes.FirstOrDefault(x => x.Name == variantValue.VariantType);

                productVariantMap.VariantType = variantType;
                productVariantMap.VariantTypeId = variantValue?.Id ?? 0;
                if (variantType != null)
                {
                    VariantTypeValue? variantTypeValue = _context.VariantTypeValues.FirstOrDefault(x => x.VariantTypeId == variantType.Id && x.VariantName == variantValue.VariantValueName);
                    if (variantTypeValue == null)
                        throw new ResultException($"Not found variant value: {variantValue.VariantValueName}");
                    productVariantMap.VariantTypeValueId = variantTypeValue?.Id ?? 0;
                    productVariantMap.VariantTypeValue = variantTypeValue;
                }
                result.Add(productVariantMap);
            }
            return result;
        }
        private Currency getCurrency(string currencyIsoCode)
        {
            Currency currency = _context.Currencies.FirstOrDefault(x => x.CurrencyISOCode == currencyIsoCode);
            if (currency == null)
                throw new Exception("Not found Currency Code");
            return currency;
        }
    }
}
