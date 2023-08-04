namespace BaseProject.Models
{
    public class InventoryModel
    {
        //상품명, 가격, 사진, 생산된 수량, 상태, 생산날짜
        public int Id { get; set; }
        public List<InventoryProductModel> InventoryProductModels { get; set; }
        public string Status { get; set; }
        public DateTime CreateTime { get; set; }
        public List<InventoryLogModel> InventoryLogModels { get; set; } 
    }
}
