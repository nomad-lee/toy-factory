namespace BaseProject.Models
{
    public class Materal_Stored_Log_Model
    {
        public int Id { get; set; }
        public int MetrailId { get; set; }
        public Material_Model Metrail { get; set; }
        public int Quantity { get; set; }
        public DateTime StoredTime { get; set; }
    }
}
