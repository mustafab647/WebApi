using ESCore.ESContext;
using ESCore.Model.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Attribute;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class SpecificationController : ControllerBase
    {
        private readonly ESDBContext _context;

        public SpecificationController(ESDBContext context) 
        {
            _context = context;
        }

        [ErrorHandlingFilter]
        [HttpGet]
        public List<Specification> GetSpecification(int specificationTypeId)
        {
            return _context.Specifications.Where(x=>x.SpecificationTypeId == specificationTypeId).ToList();
        }

        [ErrorHandlingFilter]
        [HttpGet]
        [Route("GetSpecificationType")]
        public List<SpecificationType> GetSpecificationType()
        {
            return _context.SpecificationTypes.ToList();
        }

        [ErrorHandlingFilter]
        [HttpPost]
        [Route("CreateSpecificationType")]
        public SpecificationType CreateSpecificationType(string name)
        {
            if (_context.SpecificationTypes.Any(x => x.Name.Equals(name)))
                throw new ResultException("Already Specification Types");
            SpecificationType specificationType = new SpecificationType();
            specificationType.Name = name;
            _context.SpecificationTypes.Add(specificationType);
            _context.SaveChanges();
            return specificationType;
        }

        [HttpPost]
        [ErrorHandlingFilter]
        public Specification CreateSpecification(string name, string value, int specificationTypeId)
        {
            if (_context.Specifications.Any(x => x.Value == value && x.SpecificationTypeId == specificationTypeId))
                throw new ResultException("Already Specification");

            Specification specification = new Specification();
            specification.Name = name;
            specification.Value = value;
            specification.SpecificationTypeId = specificationTypeId;
            _context.SaveChanges();
            return specification;
        }
        
    }
}
