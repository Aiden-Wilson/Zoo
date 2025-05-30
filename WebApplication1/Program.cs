using Microsoft.EntityFrameworkCore;
using ZooApi.Data;
using ZooApi.Repositories;
using ZooApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();

builder.Services.AddDbContext<ZooContext>(options => 
    options.UseInMemoryDatabase("InMemory"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
