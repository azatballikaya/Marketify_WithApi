﻿// <auto-generated />
using System;
using Marketify.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Marketify.DataAccess.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20240323154442_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Marketify.Entity.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatId"));

                    b.Property<string>("UserId1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId2")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChatId");

                    b.HasIndex("UserId1");

                    b.HasIndex("UserId2");

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            ChatId = 1,
                            UserId1 = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2",
                            UserId2 = "0b071c63-f704-474f-b4e3-384499cdec11"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4390),
                            Message = "Ürün tam aradığım gibi.",
                            PostId = 1,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4397),
                            Message = "DM yoluyla iletişime geçtim.",
                            PostId = 1,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4399),
                            Message = "En fazla kaç gün kiralayabiliyoruz?",
                            PostId = 2,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4400),
                            Message = "Kaskoları var mı?",
                            PostId = 2,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fc09c7b2-ec28-44e6-8d91-632c4e802bea",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "6fa4a4bc-88f2-441a-8d91-2f56591d63fa",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6a49bf32-7291-44ba-81cf-8a577cc0c61a",
                            Email = "admin@info.com",
                            EmailConfirmed = true,
                            IsApproved = true,
                            Job = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@INFO.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEKt1hRA5gAVLFZDdDBKHJto1usj+MFiaLy5vD/fsgZel6I1+Rlv3VP/ictic0jbyBw==",
                            PhoneNumber = "5555555555",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "6f14f27e-4ccc-4eb6-9f96-963a1cb0b01f",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "0b071c63-f704-474f-b4e3-384499cdec11",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a249a8ab-2fde-4f27-a594-e7cb4484331a",
                            Email = "customer@info.com",
                            EmailConfirmed = true,
                            IsApproved = true,
                            Job = "Rent a Car and Security",
                            LockoutEnabled = false,
                            NormalizedEmail = "CUSTOMER@INFO.COM",
                            NormalizedUserName = "CUSTOMER",
                            PasswordHash = "AQAAAAIAAYagAAAAENimHnIt3M33m9ndBXdpvFc1vXKQ6Mq2IwJOmvowntI3wiyML+UjyInF103ctWlJsg==",
                            PhoneNumber = "5555555555",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "51c17e86-223a-45ca-9516-fc58eb052a29",
                            TwoFactorEnabled = false,
                            UserName = "customer"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PostId = 1,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 2,
                            PostId = 1,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 3,
                            PostId = 2,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 4,
                            PostId = 2,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 5,
                            PostId = 3,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 6,
                            PostId = 3,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 7,
                            PostId = 4,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 8,
                            PostId = 4,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<string>("MessageContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecipientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ChatId = 1,
                            MessageContent = "Merhaba ürünlerinizi çok beğendim. Benim işletmeme uygun.",
                            RecipientId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2",
                            SenderId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 2,
                            ChatId = 1,
                            MessageContent = "Teşekkür ederim nasıl yardımcı olabilirim?",
                            RecipientId = "0b071c63-f704-474f-b4e3-384499cdec11",
                            SenderId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 3,
                            ChatId = 1,
                            MessageContent = "Ürünleriniz tam aradığım gibi fakat fiyatı bütçemi aşıyor. Yardımcı olabilir misiniz?",
                            RecipientId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2",
                            SenderId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 4,
                            ChatId = 1,
                            MessageContent = "Peki. Profilimizdeki iletişim numarsından iletişime geçerseniz yardımcı olmak isteriz. Teşekkürler...",
                            RecipientId = "0b071c63-f704-474f-b4e3-384499cdec11",
                            SenderId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Offer", b =>
                {
                    b.Property<int>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OfferId"));

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OfferId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            OfferId = 1,
                            PostId = 1,
                            Price = 8000.0,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            OfferId = 2,
                            PostId = 1,
                            Price = 9000.0,
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            OfferId = 3,
                            PostId = 3,
                            Price = 9500.0,
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        });
                });

            modelBuilder.Entity("Marketify.Entity.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Mobilya",
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4304),
                            Description = "Modern ofis mobilyaları, işyerlerinizdeki yaşamı kolaylaştıran ve çalışma verimliliğini artıran pratik ve şık çözümler sunar. Zarif tasarımlarıyla dikkat çeken bu mobilyalar, işlevselliği estetikle birleştirirken, ergonomik yapılarıyla da çalışanların konforunu sağlar. Esnek modüler sistemleri ve akıllı depolama çözümleri sayesinde, ofis alanınızı verimli bir şekilde düzenleyebilir ve değişen ihtiyaçlara kolayca uyum sağlayabilirsiniz.",
                            ImageUrl = "mobilya.jpg",
                            Price = 10000.0,
                            Title = "Modern Ofis Mobilyaları",
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Beyaz Eşya",
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4339),
                            Description = "Ev yaşamınızı kolaylaştıran beyaz eşyalarımızla hayatınızı daha konforlu hale getirin! Yüksek kaliteli ve güvenilir ürünlerimiz, modern tasarımıyla evinizin estetiğine katkı sağlarken, enerji verimliliğiyle de bütçenize dost. Pratik kullanımıyla zamanınızı verimli kullanmanıza yardımcı olurken, günlük yaşamınızı daha keyifli hale getirin.",
                            ImageUrl = "beyaz-esya.jpg",
                            Price = 15000.0,
                            Title = "Son Teknoloji Beyaz Eşyalar",
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Araba",
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4341),
                            Description = "Hayalinizdeki yolculuğa adım atın! Araç kiralama firmamız, seyahatlerinizi daha keyifli ve konforlu hale getirmek için burada. Geniş araç filomuzla her türlü ihtiyaca uygun seçenekler sunuyoruz. Güvenilir ve bakımlı araçlarımız, yolculuklarınızı güvenle tamamlamanızı sağlarken, uygun fiyatlarımızla da bütçenizi zorlamıyoruz. Hemen rezervasyon yapın ve unutulmaz bir sürüş deneyimi yaşayın!",
                            ImageUrl = "araba.jpg",
                            Price = 25000.0,
                            Title = "Kiralık Araçlar",
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Güvenlik Teknolojileri",
                            CreatedDate = new DateTime(2024, 3, 23, 18, 44, 42, 689, DateTimeKind.Local).AddTicks(4343),
                            Description = "Güvenlik Aletleri İle Huzurunuz Bizimle! Geniş ürün yelpazemiz arasında kamera sistemleri, alarm sistemleri, kapı ve pencere sensörleri, güvenlik kameraları ve daha fazlası bulunmaktadır. Güvenlik ihtiyaçlarınıza ve bütçenize uygun çözümler sunuyoruz.",
                            ImageUrl = "guvenlik.jpg",
                            Price = 10000.0,
                            Title = "Güvenlik Aletleri",
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "a80af41d-c168-4f76-9d8a-0441b7e0bcd2",
                            RoleId = "fc09c7b2-ec28-44e6-8d91-632c4e802bea"
                        },
                        new
                        {
                            UserId = "0b071c63-f704-474f-b4e3-384499cdec11",
                            RoleId = "6fa4a4bc-88f2-441a-8d91-2f56591d63fa"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Marketify.Entity.Chat", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.User", "User1")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "User2")
                        .WithMany()
                        .HasForeignKey("UserId2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("Marketify.Entity.Comment", b =>
                {
                    b.HasOne("Marketify.Entity.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Marketify.Entity.Like", b =>
                {
                    b.HasOne("Marketify.Entity.Post", "Post")
                        .WithMany("Likes")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Marketify.Entity.Message", b =>
                {
                    b.HasOne("Marketify.Entity.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Recipient");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Marketify.Entity.Offer", b =>
                {
                    b.HasOne("Marketify.Entity.Post", "Post")
                        .WithMany("Offers")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Marketify.Entity.Post", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Marketify.Entity.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Marketify.Entity.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Marketify.Entity.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Marketify.Entity.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Likes");

                    b.Navigation("Offers");
                });
#pragma warning restore 612, 618
        }
    }
}