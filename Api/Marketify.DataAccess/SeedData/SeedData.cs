using Marketify.Entity;
using Marketify.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketify.DataAccess.SeedData
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var customerRoleId = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();
            var customerId = Guid.NewGuid().ToString();
            #region Role
            List<Role> roles = new List<Role>()
            {
                new Role { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = customerRoleId, Name = "Customer", NormalizedName = "CUSTOMER" },

            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion

            #region User
            List<User> users = new List<User>()
            {
                new User { Id = adminId, UserName = "admin", Job = "Admin",NormalizedUserName="ADMIN",NormalizedEmail="ADMIN@INFO.COM", IsApproved = true, Email = "admin@info.com", EmailConfirmed = true, PhoneNumber = "5555555555", PhoneNumberConfirmed = true },
                new User { Id = customerId, UserName = "customer", Job = "Rent a Car and Security",NormalizedUserName="CUSTOMER",NormalizedEmail="CUSTOMER@INFO.COM", IsApproved = true, Email = "customer@info.com", EmailConfirmed = true, PhoneNumber = "5555555555", PhoneNumberConfirmed = true },

            };
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region UserRole
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string> { UserId = adminId, RoleId = adminRoleId },
               new IdentityUserRole<string> { UserId = customerId, RoleId = customerRoleId }
               );
            #endregion

            #region Chat
            modelBuilder.Entity<Chat>().HasData(new Chat { ChatId = 1, UserId1 = adminId, UserId2 = customerId });

            #endregion

            #region Message
            modelBuilder.Entity<Message>().HasData(new List<Message>
            {
                new Message{Id=1,MessageContent="Merhaba ürünlerinizi çok beğendim. Benim işletmeme uygun.",ChatId=1,SenderId=customerId,RecipientId=adminId},
                new Message{Id=2,MessageContent="Teşekkür ederim nasıl yardımcı olabilirim?",ChatId=1,SenderId=adminId,RecipientId=customerId},
                new Message{Id=3,MessageContent="Ürünleriniz tam aradığım gibi fakat fiyatı bütçemi aşıyor. Yardımcı olabilir misiniz?",ChatId=1,SenderId=customerId,RecipientId=adminId},
                new Message{Id=4,MessageContent="Peki. Profilimizdeki iletişim numarsından iletişime geçerseniz yardımcı olmak isteriz. Teşekkürler...",ChatId=1,SenderId=adminId,RecipientId=customerId}
            });
            #endregion

            #region Post
            modelBuilder.Entity<Post>().HasData(new List<Post>
            {
                new Post{
                    Id=1,Title="Modern Ofis Mobilyaları",Category="Mobilya",CreatedDate=DateTime.Now,Description="Modern ofis mobilyaları, işyerlerinizdeki yaşamı kolaylaştıran ve çalışma verimliliğini artıran pratik ve şık çözümler sunar. Zarif tasarımlarıyla dikkat çeken bu mobilyalar, işlevselliği estetikle birleştirirken, ergonomik yapılarıyla da çalışanların konforunu sağlar. Esnek modüler sistemleri ve akıllı depolama çözümleri sayesinde, ofis alanınızı verimli bir şekilde düzenleyebilir ve değişen ihtiyaçlara kolayca uyum sağlayabilirsiniz.",ImageUrl="mobilya.jpg",Price=10000,UserId=adminId
                },

            new Post()
            {
                Id=2,Title="Son Teknoloji Beyaz Eşyalar",Description= "Ev yaşamınızı kolaylaştıran beyaz eşyalarımızla hayatınızı daha konforlu hale getirin! Yüksek kaliteli ve güvenilir ürünlerimiz, modern tasarımıyla evinizin estetiğine katkı sağlarken, enerji verimliliğiyle de bütçenize dost. Pratik kullanımıyla zamanınızı verimli kullanmanıza yardımcı olurken, günlük yaşamınızı daha keyifli hale getirin.",
                CreatedDate=DateTime.Now,ImageUrl="beyaz-esya.jpg",Category="Beyaz Eşya",Price=15000,
                UserId=adminId
            },
            new Post()
            {
                Id=3,Title="Kiralık Araçlar",Description= "Hayalinizdeki yolculuğa adım atın! Araç kiralama firmamız, seyahatlerinizi daha keyifli ve konforlu hale getirmek için burada. Geniş araç filomuzla her türlü ihtiyaca uygun seçenekler sunuyoruz. Güvenilir ve bakımlı araçlarımız, yolculuklarınızı güvenle tamamlamanızı sağlarken, uygun fiyatlarımızla da bütçenizi zorlamıyoruz. Hemen rezervasyon yapın ve unutulmaz bir sürüş deneyimi yaşayın!",CreatedDate=DateTime.Now,Category="Araba",ImageUrl="araba.jpg",
                Price=25000,UserId=customerId
            },
            new Post()
            {
                Id=4,Title="Güvenlik Aletleri",Description= "Güvenlik Aletleri İle Huzurunuz Bizimle! Geniş ürün yelpazemiz arasında kamera sistemleri, alarm sistemleri, kapı ve pencere sensörleri, güvenlik kameraları ve daha fazlası bulunmaktadır. Güvenlik ihtiyaçlarınıza ve bütçenize uygun çözümler sunuyoruz.",Category="Güvenlik Teknolojileri",CreatedDate=DateTime.Now,ImageUrl="guvenlik.jpg",Price=10000,UserId = customerId
            }
            }
            );
            #endregion

            #region Comment
            modelBuilder.Entity<Comment>().HasData(new List<Comment>
            {
                new Comment{Id=1,CreatedDate=DateTime.Now,Message="Ürün tam aradığım gibi.",PostId=1,UserId=customerId },
                new Comment{Id=2,CreatedDate=DateTime.Now,Message="DM yoluyla iletişime geçtim.",PostId=1,UserId=customerId },
                 new Comment{Id=3,CreatedDate=DateTime.Now,Message="En fazla kaç gün kiralayabiliyoruz?",PostId=2,UserId=adminId },
                  new Comment{Id=4,CreatedDate=DateTime.Now,Message="Kaskoları var mı?",PostId=2,UserId=customerId },
            });
            #endregion

            #region Like
            modelBuilder.Entity<Like>().HasData(new List<Like>
            {
                new Like{Id=1,PostId=1,UserId=customerId},
                new Like{Id=2,PostId=1,UserId=adminId},
                new Like{Id=3,PostId=2,UserId=customerId},
                new Like{Id=4,PostId=2,UserId=adminId},
                new Like{Id=5,PostId=3,UserId=adminId},
                new Like{Id=6,PostId=3,UserId=customerId},
                new Like{Id=7,PostId=4,UserId=adminId},
                new Like{Id=8,PostId=4,UserId=customerId},
            }
                );
            #endregion

            #region Offer
            modelBuilder.Entity<Offer>().HasData(new List<Offer>
            {
                new Offer{OfferId=1,Price=8000,PostId=1,UserId=customerId},
                new Offer{OfferId=2,Price=9000,PostId=1,UserId=customerId},
                new Offer{OfferId=3,Price=9500,PostId=3,UserId=adminId}
               
            });
            #endregion

        }
    }
}

