using BaseProject.Data.Base;
using BaseProject.Models;

namespace BaseProject.Data.Service
{
    public class ExService : EntityBaseRepository<ExModel>, IExService
    {
        public ExService(BaseDbContext context) : base(context)
        {
        }
    }
}
