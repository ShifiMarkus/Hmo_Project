using HmoServer.Models;
using HmoServer.Models.Interfaces;
using HmoServer.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var MyAppOrigin = "MyAppOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAppOrigin,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                          .AllowAnyHeader().AllowAnyMethod(); ;
                      });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HmoContext>(apt => apt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerValidation, CustomerValidation>();
builder.Services.AddScoped<ICoronaDetailsValidation, CoronaDetailsValidation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAppOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
