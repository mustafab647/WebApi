namespace WebApi.Models.CategoryModels
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public bool IsValid { get; set; }
        public int ParentCategoryId { get; set; }
    }
}
