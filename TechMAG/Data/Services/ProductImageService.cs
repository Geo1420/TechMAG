using Microsoft.EntityFrameworkCore;
using TechMAG.Data.Base;
using TechMAG.Models;

namespace TechMAG.Data.Services
{
    public class ProductImageService : EntityBaseRepository<ProductImage>, IProductImageService
    {

        public ProductImageService(AppDbContext context) : base(context) { }
        
        public ProductImage GetByCategory(string category)
        {
           throw new NotImplementedException();
        }

        
    }
}
