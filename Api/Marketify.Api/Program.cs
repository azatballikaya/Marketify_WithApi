using Marketify.Api.Mapping;
using Marketify.Api.SeedData;
using Marketify.Business.Abstract;
using Marketify.Business.Concrete;
using Marketify.DataAccess.Abstract;
using Marketify.DataAccess.Concrete.EntityFramework;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IdentityContext>(options =>
options.UseSqlite("Data Source=Marketify.db")

);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IPostDal, EfPostRepository>();
builder.Services.AddScoped<IPostService,PostManager>();

builder.Services.AddScoped<ICommentDal,EfCommentRepository>();
builder.Services.AddScoped<ICommentService,CommentManager>();

builder.Services.AddScoped<IOfferDal,EfOfferRepository>();
builder.Services.AddScoped<IOfferService,OfferManager>();

builder.Services.AddScoped<ILikeDal,EfLikeRepository>();

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
