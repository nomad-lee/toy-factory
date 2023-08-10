using BaseProject.Data.Base;
using BaseProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Register_Model 
    {

        // ID, PW, 이름, 사진, 가입날짜
        [Key]
        public string Id { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string ImgUrl { get; set; }

        public StatusCategory Status { get; set; }
        public DateTime CreateTime{ get; set; }
    }
}
