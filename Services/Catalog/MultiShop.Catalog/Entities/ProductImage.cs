namespace MultiShop.Catalog.Entities
{
    public class ProductImage
    {
        public string ProductImageId { get; set; }
        public string ProductImage1 { get; set; }
        public string ProductImage2 { get; set; }
        public string ProductImage3 { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
