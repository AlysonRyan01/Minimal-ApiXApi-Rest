using Microsoft.EntityFrameworkCore;
using Test.Core.Handlers;
using Test.MinimalApi.Data;
using Test.MinimalApi.Handlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<IProductHandler, ProductHandler>();

var app = builder.Build();

app.Run();
