namespace BaseProject.Models
{
    public class InventoryProductModel
    {
        //상품명, 가격, 사진, 생산된 수량, 상태, 생산날짜
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
