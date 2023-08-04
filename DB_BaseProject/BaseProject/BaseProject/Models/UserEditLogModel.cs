using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class UserEditLogModel
    {
        [Key]
        public int Id { get; set; }

        public string UserIdentityId { get; set; }
        public UserIdentity UserIdentity { get; set;}

        public DateTime EditTime { get; set; }
    }
}
