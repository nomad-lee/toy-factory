using BaseProject.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace BaseProject.Models
{
    public class IoTDataModel
    {
        [Key]
        public int Id { get; set; }

        public int IoTModelId { get; set; }
        public IoTModel IoTModel { get; set; }
        
        public int Data { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
