using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class IoT_Data_Model
    {
        [Key]
        public int Id { get; set; }

        public int IoTModelId { get; set; }
        public IoT_Model IoTModel { get; set; }
        
        public int Data { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
