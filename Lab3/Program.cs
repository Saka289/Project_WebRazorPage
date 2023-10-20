using Lab3.Repository.CategoryRepository;
using Lab3.Repository.ProductRepository;
using Lab3.Models;
using Microsoft.EntityFrameworkCore;
using Lab3.Repository.ShiperRepository;
using Lab3.Repository.CheckOutRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer
(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<ICheckOutRepository, CheckOutRepository>();

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/", context =>
{
    context.Response.Redirect("/ProductPages/Index");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
