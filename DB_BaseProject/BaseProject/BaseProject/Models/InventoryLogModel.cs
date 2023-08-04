namespace BaseProject.Models
{
    public class InventoryLogModel
    {
        //상품명, 가격, 사진, 생산된 수량, 상태, 생산날짜
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public InventoryModel Inventory { get; set; }
        public DateTime EditTime { get; set; }
    }
}
