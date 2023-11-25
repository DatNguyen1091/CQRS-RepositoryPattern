using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp_BAL.Services;
using WebApp_DAL.Data;
using WebApp_DAL.Models;
using WebApp_DAL.ProductCQRS.Commands;
using WebApp_DAL.ProductCQRS.Queries;
using WebApp_DAL.Repository;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Config Database
        builder.Services.AddDbContext<AppStoreContext>(opt =>
        {
            opt.UseLazyLoadingProxies(); // Enable lazy loading
            opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductStore"));
        });

        // AddCors
        builder.Services.AddCors(options => options.AddPolicy("AllowOrigin", policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }));

        //
        builder.Services.AddMediatR(typeof(GetAllProduct));
        builder.Services.AddMediatR(typeof(GetProductById));
        builder.Services.AddMediatR(typeof(CreateProduct));
        builder.Services.AddMediatR(typeof(UpdateProduct));
        builder.Services.AddMediatR(typeof(DeleteProduct));

        // AddScoped
        builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
        builder.Services.AddScoped<CategoryService>();

        builder.Services.AddScoped<IRepository<Product>, ProductRepository>();
        builder.Services.AddScoped<ProductService>();

        builder.Services.AddScoped<CategoeyWithProductRepository>();
        builder.Services.AddScoped<CategoryWithProductService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowOrigin");

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}