namespace BusinessLogicLayer.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string? Image { get; set; }
    }
}
