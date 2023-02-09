namespace UI.Models
{
    public class ProductModel
    {
        public int ProductId { get;  set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double? CurrentPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
