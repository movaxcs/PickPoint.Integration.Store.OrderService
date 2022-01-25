using Microsoft.EntityFrameworkCore;
using PickPoint.Integration.Store.OrderService.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderServiceContext>(opt => opt.UseInMemoryDatabase("OrderServiceContext"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DataGenerator.Initialize(scope.ServiceProvider); // data generation
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();