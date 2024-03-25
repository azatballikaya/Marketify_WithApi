Admin's account: 
Email:admin@info.com
Password:Qwe123.
------------------------
Customer's account (also you can create another one)
Email:customer@info.com
Password:Qwe123.
--------------------------

Please don't forget change SQL Server Adress.
Marketify_WithApi/Api/Marketify.Api/Program.cs

builder.Services.AddDbContext<IdentityContext>(options =>
options.UseSqlServer("Server=TYPE YOUR SQL SERVER ADDRESS; Database=Marketify; Trusted_Connection=true; TrustServerCertificate=true;")

);
