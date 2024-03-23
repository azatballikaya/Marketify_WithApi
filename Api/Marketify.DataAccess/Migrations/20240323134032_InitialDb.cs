using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Job = table.Column<string>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId1 = table.Column<string>(type: "TEXT", nullable: false),
                    UserId2 = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId2",
                        column: x => x.UserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageContent = table.Column<string>(type: "TEXT", nullable: false),
                    ChatId = table.Column<int>(type: "INTEGER", nullable: false),
                    SenderId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PostId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ed025ec-f3dc-4505-bff0-918300a2fca2", null, "Customer", "CUSTOMER" },
                    { "a2ae933f-e3fd-43f4-acac-bbd8e030b71c", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "Job", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3f54996c-086f-4ca1-ac2b-71ae14021ac1", 0, "23e2fd16-b478-46a3-b536-4e0945b7225f", "admin@info.com", true, true, "Admin", false, null, "ADMIN@INFO.COM", "ADMIN", "AQAAAAIAAYagAAAAEAsFqdyUkfdq2J3RaFqRQ1A7AdOyTUNhByjnWc6o+N787iA6mxDkhVLhURuYu+PPBQ==", "5555555555", true, "dd85ebcb-33dd-420b-b349-7721a0910d21", false, "admin" },
                    { "e2806b22-5c42-4a0e-95db-c06f47c9c415", 0, "3d96557c-98a1-4060-82c4-feaf38414893", "customer@info.com", true, true, "Customer", false, null, "CUSTOMER@INFO.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEJRNBu4Mu9lHQ1Vd/6BKJ4PwVszGnXGedehQ1pOwhK8u6D6FU8WLldwUxVdSAWBypw==", "5555555555", true, "d0c966c6-99d1-421a-9e8a-cbe789d14542", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a2ae933f-e3fd-43f4-acac-bbd8e030b71c", "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { "4ed025ec-f3dc-4505-bff0-918300a2fca2", "e2806b22-5c42-4a0e-95db-c06f47c9c415" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "UserId1", "UserId2" },
                values: new object[] { 1, "3f54996c-086f-4ca1-ac2b-71ae14021ac1", "e2806b22-5c42-4a0e-95db-c06f47c9c415" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "ImageUrl", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Mobilya", new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2816), "Modern ofis mobilyaları, işyerlerinizdeki yaşamı kolaylaştıran ve çalışma verimliliğini artıran pratik ve şık çözümler sunar. Zarif tasarımlarıyla dikkat çeken bu mobilyalar, işlevselliği estetikle birleştirirken, ergonomik yapılarıyla da çalışanların konforunu sağlar. Esnek modüler sistemleri ve akıllı depolama çözümleri sayesinde, ofis alanınızı verimli bir şekilde düzenleyebilir ve değişen ihtiyaçlara kolayca uyum sağlayabilirsiniz.", "mobilya.jpg", 10000.0, "Modern Ofis Mobilyaları", "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 2, "Beyaz Eşya", new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2836), "Ev yaşamınızı kolaylaştıran beyaz eşyalarımızla hayatınızı daha konforlu hale getirin! Yüksek kaliteli ve güvenilir ürünlerimiz, modern tasarımıyla evinizin estetiğine katkı sağlarken, enerji verimliliğiyle de bütçenize dost. Pratik kullanımıyla zamanınızı verimli kullanmanıza yardımcı olurken, günlük yaşamınızı daha keyifli hale getirin.", "beyaz-esya.jpg", 15000.0, "Son Teknoloji Beyaz Eşyalar", "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 3, "Araba", new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2838), "Hayalinizdeki yolculuğa adım atın! Araç kiralama firmamız, seyahatlerinizi daha keyifli ve konforlu hale getirmek için burada. Geniş araç filomuzla her türlü ihtiyaca uygun seçenekler sunuyoruz. Güvenilir ve bakımlı araçlarımız, yolculuklarınızı güvenle tamamlamanızı sağlarken, uygun fiyatlarımızla da bütçenizi zorlamıyoruz. Hemen rezervasyon yapın ve unutulmaz bir sürüş deneyimi yaşayın!", "araba.jpg", 25000.0, "Kiralık Araçlar", "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 4, "Güvenlik Teknolojileri", new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2840), "Güvenlik Aletleri İle Huzurunuz Bizimle! Geniş ürün yelpazemiz arasında kamera sistemleri, alarm sistemleri, kapı ve pencere sensörleri, güvenlik kameraları ve daha fazlası bulunmaktadır. Güvenlik ihtiyaçlarınıza ve bütçenize uygun çözümler sunuyoruz.", "guvenlik.jpg", 10000.0, "Güvenlik Aletleri", "e2806b22-5c42-4a0e-95db-c06f47c9c415" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "Message", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2866), "Ürün tam aradığım gibi.", 1, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 2, new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2870), "DM yoluyla iletişime geçtim.", 1, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 3, new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2872), "En fazla kaç gün kiralayabiliyoruz?", 2, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 4, new DateTime(2024, 3, 23, 16, 40, 32, 290, DateTimeKind.Local).AddTicks(2874), "Kaskoları var mı?", 2, "e2806b22-5c42-4a0e-95db-c06f47c9c415" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 2, 1, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 3, 2, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 4, 2, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 5, 3, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 6, 3, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 7, 4, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 8, 4, "e2806b22-5c42-4a0e-95db-c06f47c9c415" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "MessageContent", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 1, 1, "Merhaba ürünlerinizi çok beğendim. Benim işletmeme uygun.", "3f54996c-086f-4ca1-ac2b-71ae14021ac1", "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 2, 1, "Teşekkür ederim nasıl yardımcı olabilirim?", "e2806b22-5c42-4a0e-95db-c06f47c9c415", "3f54996c-086f-4ca1-ac2b-71ae14021ac1" },
                    { 3, 1, "Ürünleriniz tam aradığım gibi fakat fiyatı bütçemi aşıyor. Yardımcı olabilir misiniz?", "3f54996c-086f-4ca1-ac2b-71ae14021ac1", "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 4, 1, "Peki. Profilimizdeki iletişim numarsından iletişime geçerseniz yardımcı olmak isteriz. Teşekkürler...", "e2806b22-5c42-4a0e-95db-c06f47c9c415", "3f54996c-086f-4ca1-ac2b-71ae14021ac1" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "PostId", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 8000.0, "e2806b22-5c42-4a0e-95db-c06f47c9c415" },
                    { 2, 2, 9500.0, "3f54996c-086f-4ca1-ac2b-71ae14021ac1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId1",
                table: "Chats",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId2",
                table: "Chats",
                column: "UserId2");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_PostId",
                table: "Offers",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_UserId",
                table: "Offers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
