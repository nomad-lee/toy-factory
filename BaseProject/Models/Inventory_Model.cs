using BaseProject.Data.Base;

namespace BaseProject.Models
{
    public class Inventory_Model : IEntityBase
    {
        //상품명, 가격, 사진, 생산된 수량, 상태, 생산날짜
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product_Model Product { get; set; }
        public int Count { get; set; }
        public DateTime CreateTime { get; set; }
        public List<Inventory_Edit_Log_Model> InventoryEditLogModels { get; set; } 
    }
}
