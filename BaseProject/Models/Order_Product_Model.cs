namespace BaseProject.Models
{
    public class Order_Product_Model
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order_Model Order { get; set; }
        public int ProductId { get; set; }
        public Product_Model Product { get; set; }
        public int Quantity { get; set; }


    }
}
