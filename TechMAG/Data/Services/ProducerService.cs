using TechMAG.Data.Base;
using TechMAG.Models;

namespace TechMAG.Data.Services
{
    public class ProducerService: EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context): base(context)
        {

        }
    }
}
