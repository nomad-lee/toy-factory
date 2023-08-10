using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class Login_Log_Model
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        public UserIdentity UserIdentity { get; set; }

        public DateTime LoginTime { get; set; }
    }
}
