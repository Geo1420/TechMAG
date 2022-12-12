using Microsoft.EntityFrameworkCore;
using TechMAG.Data;
using TechMAG.Data.Services;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TechMAG")));
// Add services to the container.
builder.Services.AddControllersWithViews();
//Config the services
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//Seed database
AppDbInitializer.Seed(app);

app.Run();
