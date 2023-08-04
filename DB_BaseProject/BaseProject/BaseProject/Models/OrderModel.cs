using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public List<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();
        public string Customer{ get; set; }
        // 현황
        public string Status { get; set; }
        // 등록날짜
        public string RegisterDate { get; set; }

        // 마감날짜
        public string EndDate { get; set; }

        public List<OrderEditLogModel> OrderEditLogModels { get; } = new List<OrderEditLogModel>();
    }
}
