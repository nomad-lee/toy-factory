using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class RegisterModel
    {

        // ID, PW, 이름, 사진, 가입날짜
        [Key]
        public int Id { get; set; }

        public string password { get; set; }

        public string name { get; set; }

        public string ImgUrl { get; set; }

        public string Status { get; set; }
        public DateTime CreateTime{ get; set; }
    }
}
