using ESCore.ESContext;
using Microsoft.AspNetCore.Mvc;
using ESCore.Model.Product;
using WebApi.Models;
using WebApi.Attribute;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(Roles ="Category")]
    public class CategoriesController : ControllerBase
    {
        private readonly ESDBContext _context;
        public CategoriesController(ESDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Authorize(Roles = "Category.View")]
        public List<Category> GetCategory()
        {
            List<Category> categories = _context.Categories.ToList();
            categories = categories.Where(x => x.CategoryId == 0).ToList();
            return categories;
        }

        [HttpPost]
        [ErrorHandlingFilter]
        [Authorize(Roles = "Category.Create")]
        public void Create(Models.CategoryModels.CategoryModel category)
        {
            if (_context.Categories.Any(x => x.Name == category.Name))
                throw new ResultException("Belirtilen Kategori Mevcut.");
            var categoryResp = PrepareData.CategoryPrepare.Category(category);
            _context.Categories.Add(categoryResp);
            _context.SaveChanges();
        }
    }
}