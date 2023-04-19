using Application.Interfaces;
using Application;
using Microsoft.AspNetCore.Builder;
using DataAccess.Repositories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PrivateWebAPI;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddDbContext<DepotContext>(options => options.UseSqlServer(connstr));
builder.Services.AddScoped<DbContext, DepotContext>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IGenericRepository<WarehouseBatchContent>, GenericRepository<WarehouseBatchContent>>()
    .AddTransient<IGenericRepository<WarehouseBatch>, GenericRepository<WarehouseBatch>>()
    .AddTransient<IBatchProducts, ProductBatcher>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();