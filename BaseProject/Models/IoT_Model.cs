using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class IoT_Model : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
