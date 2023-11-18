namespace WebApi.PrepareData
{
    public class CategoryPrepare
    {
        public CategoryPrepare() { }

        public static ESCore.Model.Product.Category Category(Models.CategoryModels.CategoryModel category)
        {
            ESCore.Model.Product.Category result = new ESCore.Model.Product.Category();
            result.CategoryId = category.ParentCategoryId;
            result.IsValid = category.IsValid;
            result.Name = category.Name;
            return result;
        }
    }
}
