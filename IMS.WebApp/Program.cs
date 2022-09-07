using IMS.Plugins.EFCoreSqlServer;
using IMS.Plugins.InMemory;
using IMS.UseCase.Category;
using IMS.UseCase.Category.Interfaces;
using IMS.UseCase.PluginInterfaces;
using IMS.UseCase.Product;
using IMS.UseCase.Product.Interfaces;
using IMS.WebApp.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContextFactory<IMSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("databasestr"))
);

// Repositoy IMS.plugins.InMemory
//builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
//builder.Services.AddSingleton<IProductRepository, ProductRepository>();
// Repositoy IMS.plugins.EFCoreSqlServer
builder.Services.AddSingleton<ICategoryRepository, CategoryEFRepository>();
builder.Services.AddSingleton<IProductRepository, ProductEFRepository>();


builder.Services.AddTransient<IViewCategoriesByNameUseCase, ViewCategoriesByNameUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IViewCategoryByIdUseCase, ViewCategoryByIdUseCase>();


builder.Services.AddTransient<IViewProductsByNameUseCase, ViewProductsByNameUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductByIdUseCase, ViewProductByIdUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
