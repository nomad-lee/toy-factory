using BaseProject.Data.Base;
using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Product_Model : IEntityBase
    {
        //상품명, 가격, , 사진, 상태, 수정날짜
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }        
        public string ImgUrl { get; set; }
        public StatusCategory Status { get; set; }        
        public DateTime CreateTime { get; set; }

        public int[] MetrailId { get; set; }
        public int[] count { get; set; }

        public List<Product_Use_Metrail_Model> ProductUseMetrailModels { get; set; }
        public List<Product_Edit_LogModel> ProductEditLogModels { get; set; }
    }
}
