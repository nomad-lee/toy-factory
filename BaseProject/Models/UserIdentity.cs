using BaseProject.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class UserIdentity : IdentityUser
    {
        public string ImgUrl { get; set; }
        public Defult_StatusCategory Status { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
