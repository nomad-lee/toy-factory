namespace BaseProject.Models
{
    public class ProductUseMetrailModel
    {
        public int Id { get; set; }
        public List<ProductModel> ProductModels { get; set; }
        public DateTime EditTime { get; set; }
    }
}
