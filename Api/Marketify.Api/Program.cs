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
options.UseSqlServer("Server=DESKTOP-NOPPPVL\\SQLEXPRESS; Database=Marketify; Trusted_Connection=true; TrustServerCertificate=true;")

);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();
builder.Services.AddScoped<IPostDal, EfPostRepository>();
builder.Services.AddScoped<IPostService,PostManager>();

builder.Services.AddScoped<ICommentDal,EfCommentRepository>();
builder.Services.AddScoped<ICommentService,CommentManager>();

builder.Services.AddScoped<IOfferDal,EfOfferRepository>();
builder.Services.AddScoped<IOfferService,OfferManager>();

builder.Services.AddScoped<IMessageDal, EfMessageRepository>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddScoped<IChatDal, EfChatRepository>();
builder.Services.AddScoped<IChatService, ChatManager>();

builder.Services.AddScoped<ILikeDal,EfLikeRepository>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<IdentityContext>();
    context.Database.Migrate();
}


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
