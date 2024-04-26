using Application.Services;
using Domain.Infra.Repository.Interfaces;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ProdutoContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
builder.Services.AddScoped<IProdutoDomainService, ProdutoDomainService>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepositoryService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
