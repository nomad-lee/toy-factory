namespace BaseProject.Models
{
    public class Product_Use_Metrail_Model
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product_Model Product { get; set; }
        public int MetrailId { get; set; }
        public Material_Model Metrail { get; set; }
        public int Quantity { get; set; }
        public DateTime EditTime { get; set; }
    }
}
