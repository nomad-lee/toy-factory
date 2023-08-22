using BaseProject.Data.Base;
using BaseProject.Models;

namespace BaseProject.Data.Service
{
    public class MateralService : EntityBaseRepository<Material_Model>, IMateralService
    {
        public MateralService(BaseDbContext context) : base(context)
        {
        }
    }
}
