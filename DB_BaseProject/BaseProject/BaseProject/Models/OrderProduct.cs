namespace BaseProject.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

    }
}
