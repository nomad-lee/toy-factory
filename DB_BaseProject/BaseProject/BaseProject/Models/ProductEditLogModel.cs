using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class ProductEditLogModel
    {

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; } 
        public ProductModel Product { get; set; }
        public DateTime EditTime { get; set; }
    }
}
