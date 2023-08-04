using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class MaterialModel
    {
        //자재명, 가격, 수량, 사진
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
        public string ImgUrl { get; set; }
    }
}
