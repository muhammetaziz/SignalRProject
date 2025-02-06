namespace SignalR.WebUI.DTOs.ProductDtos
{
    public class GetProductDto
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public bool ProductStatus { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }

    }
}
