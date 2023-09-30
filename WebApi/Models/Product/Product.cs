namespace WebApi.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> ImageList { get; set; }
        public decimal Price { get; set; }
        public decimal ListPrice { get; set; }
        public List<Specification> Specification { get; set; }
    }
}
