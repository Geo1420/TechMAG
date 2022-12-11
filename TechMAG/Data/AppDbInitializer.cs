using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TechMAG.Models;

namespace TechMAG.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                context.Database.EnsureCreated();

                //Product
                if(!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Laptop HP Pavilion",
                            Price = 20.0f,
                            Description = "4GB RAM, Procesor Intel i7 11300K 4.4GHz",
                            ImageURL = "https://s13emagst.akamaized.net/products/43585/43584527/images/res_b6d4dbde356a0301532a61e4a1b98e78.jpg",
                            ScreenSize = "15,6",
                            OperatingSystem = "Windows",
                            Amount = 1,
                            Created = DateTime.Now,
                            Discount = 5,
                            ProductCategory = ProductCategory.Laptops
                        },
                        new Product()
                        {
                            Name = "Laptop HP Pavilion",
                            Price = 20.0f,
                            Description = "8GB RAM, Procesor Intel i5 11300K 4.4GHz",
                            ImageURL = "https://s13emagst.akamaized.net/products/43585/43584527/images/res_b6d4dbde356a0301532a61e4a1b98e78.jpg",
                            ScreenSize = "17,6",
                            OperatingSystem = "Mac",
                            Amount = 2,
                            Created = DateTime.Now,
                            Discount = 10,
                            ProductCategory = ProductCategory.Laptops
                        },
                        new Product()
                        {
                            Name = "Samsung S22 Ultra",
                            Price = 30.0f,
                            Description = "8GB RAM",
                            ImageURL = "https://images.samsung.com/is/image/samsung/p6pim/ro/2202/gallery/ro-galaxy-s22-s901-sm-s901biddeue-530807082",
                            ScreenSize = "6.5",
                            OperatingSystem = "Android",
                            Amount = 2,
                            Created = DateTime.Now,
                            Discount = 10,
                            ProductCategory = ProductCategory.Phones
                        }

                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Asus",
                            ImageURL = "https://dlcdnimgs.asus.com/websites/global/Sno/79183.jpg",
                            HomeURL =  "https://www.asus.com/ro/",
                            Desciption = "Descriere"
                        },
                        new Producer()
                        {
                            Name = "Asus",
                            ImageURL = "https://www.shutterstock.com/image-photo/kiev-ukraine-march-31-2015-260nw-265456295.jpg",
                            HomeURL = "https://www.hp.com/ro-ro/home.html",
                            Desciption = "Descriere"
                        }
                        new Producer()
                        {
                            Name = "Samsung",
                            ImageURL = "https://www.shutterstock.com/image-photo/kiev-ukraine-march-31-2015-260nw-265456295.jpg",
                            HomeURL = "https://www.hp.com/ro-ro/home.html",
                            Desciption = "Descriere"
                        }

                    });
                    context.SaveChanges();

                }
                //ProductImg
                if (!context.ProductImages.Any())
                {
                    context.ProductImages.AddRange(new List<ProductImage>()
                    {
                        new ProductImage()
                        {
                            ProductImageURL = "https://lcdn.altex.ro/resize/media/catalog/product/G/5/16fa6a9aef7ffd6209d5fd9338ffa0b1/G533-2022_1.jpg",
                            CreatedDate = DateTime.Now
                        },
                        new ProductImage()
                        {
                            ProductImageURL = "https://lcdn.altex.ro/resize/media/catalog/product/G/5/16fa6a9aef7ffd6209d5fd9338ffa0b1/G533-2022_1.jpg",
                            CreatedDate = DateTime.Now
                        }

                    });
                    context.SaveChanges();
                }
            }    
        }
    }
}
