using Marketify.Api.SeedData;
using Marketify.DataAccess.Concrete.EntityFramework;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(options =>
options.UseSqlServer("Server=DESKTOP-NOPPPVL\\SQLEXPRESS;Database=MarketifyDb;Trusted_Connection=True; TrustServerCertificate=true;")

);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//SeedData.Initialize(app.Services);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
