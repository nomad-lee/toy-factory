using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class IoT_Data_Model
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product_Model Product { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
