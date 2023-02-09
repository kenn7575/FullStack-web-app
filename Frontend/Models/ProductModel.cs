namespace UI.Models
{
    public class ProductModel
    {
        public int ProductId { get;  set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? CurrentPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
