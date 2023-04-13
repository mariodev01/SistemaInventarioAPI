using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaInventarioAPI;
using SistemaInventarioAPI.Repository;
using SistemaInventarioAPI.Repository.IRepository;
using SistemaInventarioAPI.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<SistemaDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddAutoMapper(typeof(MappingConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IArticulo, ArticuloRepository>();
builder.Services.AddScoped<ITransaccion, TransaccionRepository>();

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
