using BaseProject.Data.Base;


namespace BaseProject.Models
{
    public class ExModel : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
