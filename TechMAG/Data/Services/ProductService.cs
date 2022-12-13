using Microsoft.EntityFrameworkCore;
using TechMAG.Data.Base;
using TechMAG.Data.ViewModel;
using TechMAG.Models;

namespace TechMAG.Data.Services
{
    public class ProductService: EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) : base(context) { _context = context; }

        public async Task AddNewProductAsync(ProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Amount = data.Amount,
                ScreenSize = data.ScreenSize,
                OperatingSystem = data.OperatingSystem,
                Created = data.Created,
                Discount = data.Discount,
                ProductCategory = data.ProductCategory,
                ProducerId = data.ProducerId
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<ProductDropDownVM> GetNewProductDropDownVal()
        {
            var response = new ProductDropDownVM();
            response.Producers = await _context.Producers.OrderBy(n => n.Name).ToListAsync();
            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products.Include(c => c.Producer).FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task UpdateMovieAsync(ProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == data.Id);
            if(dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ProductCategory = data.ProductCategory;
                dbProduct.ProducerId = data.ProducerId;
                dbProduct.Amount = data.Amount;
                dbProduct.Created = data.Created;
                dbProduct.Discount = data.Discount;
                dbProduct.ScreenSize = data.ScreenSize;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.OperatingSystem = data.OperatingSystem;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
