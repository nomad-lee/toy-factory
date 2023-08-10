using BaseProject.Data.Base;
using BaseProject.Models;

namespace BaseProject.Data.Service
{
    public class InventoryServeice : EntityBaseRepository<Inventory_Model>, IInventoryService
    {
        //private readonly IFileService _fileService;


        public InventoryServeice(BaseDbContext context) : base(context)
        {

        }

    }
}
