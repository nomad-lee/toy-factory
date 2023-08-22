using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class RollAccept_Model
    {
        public string[] UserId { get; set; }
        public string[] Role { get; set; }
        public string[] BeforeRole { get; set; }
    }
}
