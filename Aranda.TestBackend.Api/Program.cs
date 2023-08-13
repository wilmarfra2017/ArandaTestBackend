using Aranda.TestBackend.Application.Commands;
using Aranda.TestBackend.Domain.Aggregates.Entities;
using Aranda.TestBackend.Domain.Aggregates.Interfaces;
using Aranda.TestBackend.Domain.Services;
using Aranda.TestBackend.Infraestructure;
using Aranda.TestBackend.Infraestructure.Finders;
using Aranda.TestBackend.Infraestructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PersistenceContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"), ServiceLifetime.Singleton);

builder.Services.AddSingleton<IProductService<Product>, ProductService>();
builder.Services.AddSingleton<IProductFinder<Product>, ProductFinder>();
builder.Services.AddSingleton<IProductRepository<Product>, ProductRepository>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly(), AppDomain.CurrentDomain.Load("Aranda.TestBackend.Domain"));
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
