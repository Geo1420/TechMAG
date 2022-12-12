using TechMAG.Models;
using System.Threading.Tasks;
using TechMAG.Data.Base;
using TechMAG.Data.ViewModel;

namespace TechMAG.Data.Services
{
    public interface IProductService : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductDropDownVM> GetNewProductDropDownVal();
        Task AddNewProductAsync(ProductVM data);
    }
}
