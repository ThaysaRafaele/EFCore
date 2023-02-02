using AutoMapper;
using EFCore.Application.AutoMapper;
using EFCore.Domain.Contracts.Repositories;
using EFCore.Data.Repositories;
using EFCore.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using EFCore.Application.Contracts.Services;
using EFCore.Application.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

// Add services to the container.

builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString)
); ; ;


builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc()
			.AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler =
			ReferenceHandler.IgnoreCycles);

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DafaultMapper());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
