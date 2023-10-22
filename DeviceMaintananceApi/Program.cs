using DeviceMaintanace.DAL;
using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanace.IOC;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices();
// Add services to the container.
builder.Services.AddDbContext<DeviceMaintanaceContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("con"));
}, ServiceLifetime.Transient);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
