namespace ESCore.Model.Product
{
    public class ProductImage : ESBase
    {
        public int ProductId { get; set; }
        public string Url { get; set; }
        public bool IsMainImage { get; set; }
        public short Order { get; set; }
    }
}