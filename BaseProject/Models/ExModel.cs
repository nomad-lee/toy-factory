using BaseProject.Data.Base;


namespace BaseProject.Models
{
    public class ExModel : IEntityBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product_Model Product { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
