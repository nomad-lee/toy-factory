using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class OrderEditLogModel
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public DateTime EditTime { get; set; }
    }
}
