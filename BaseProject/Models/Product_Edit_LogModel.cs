using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Product_Edit_LogModel
    {

        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; } 
        public Product_Model Product { get; set; }
        public DateTime EditTime { get; set; }
    }
}
