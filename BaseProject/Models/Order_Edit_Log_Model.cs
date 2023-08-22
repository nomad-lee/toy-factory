using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Order_Edit_Log_Model
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order_Model Order { get; set; }

        public DateTime EditTime { get; set; }
    }
}
