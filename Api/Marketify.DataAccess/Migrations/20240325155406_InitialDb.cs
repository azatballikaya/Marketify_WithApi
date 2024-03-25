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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId2 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Chats_AspNetUsers_UserId2",
                        column: x => x.UserId2,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChatId = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                    table.ForeignKey(
                        name: "FK_Offers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                    { "443ed718-befe-48e9-8e34-7bec2d3c2c5d", null, "Admin", "ADMIN" },
                    { "5170e303-5a50-4474-bcec-4a33fc52221d", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "Job", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6504b1ca-d952-4efb-acea-b6abfd00fb49", 0, "0606ec46-6d21-44d1-bd67-b4ddfbe5118c", "customer@info.com", true, true, "Rent a Car and Security", false, null, "CUSTOMER@INFO.COM", "CUSTOMER", "AQAAAAIAAYagAAAAELe/cdHXiAXDPsbePF8rq4LfioOFLa5v51WXDlkO6gMTVcvvTmLpxAhGIMf29Ml4Pw==", "5555555555", true, "0d6d7d23-60ac-4c91-b647-866743dd877a", false, "customer" },
                    { "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741", 0, "826079c1-293a-4c19-b245-a0a559bf7e18", "admin@info.com", true, true, "Admin", false, null, "ADMIN@INFO.COM", "ADMIN", "AQAAAAIAAYagAAAAEHFJ7eO79zrQ/kNIFSuuykKoQFARrLBLfq1QBmhQu1LC9PPGgZdFSCTNGt+dgaW28A==", "5555555555", true, "bca5c4b7-90c3-4896-8c26-fef8e15a6775", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5170e303-5a50-4474-bcec-4a33fc52221d", "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { "443ed718-befe-48e9-8e34-7bec2d3c2c5d", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "UserId1", "UserId2" },
                values: new object[] { 1, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741", "6504b1ca-d952-4efb-acea-b6abfd00fb49" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "ClickCount", "CreatedDate", "Description", "ImageUrl", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Mobilya", 0, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1142), "Modern ofis mobilyaları, işyerlerinizdeki yaşamı kolaylaştıran ve çalışma verimliliğini artıran pratik ve şık çözümler sunar. Zarif tasarımlarıyla dikkat çeken bu mobilyalar, işlevselliği estetikle birleştirirken, ergonomik yapılarıyla da çalışanların konforunu sağlar. Esnek modüler sistemleri ve akıllı depolama çözümleri sayesinde, ofis alanınızı verimli bir şekilde düzenleyebilir ve değişen ihtiyaçlara kolayca uyum sağlayabilirsiniz.", "mobilya.jpg", 10000.0, "Modern Ofis Mobilyaları", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 2, "Beyaz Eşya", 0, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1160), "Ev yaşamınızı kolaylaştıran beyaz eşyalarımızla hayatınızı daha konforlu hale getirin! Yüksek kaliteli ve güvenilir ürünlerimiz, modern tasarımıyla evinizin estetiğine katkı sağlarken, enerji verimliliğiyle de bütçenize dost. Pratik kullanımıyla zamanınızı verimli kullanmanıza yardımcı olurken, günlük yaşamınızı daha keyifli hale getirin.", "beyaz-esya.jpg", 15000.0, "Son Teknoloji Beyaz Eşyalar", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 3, "Araba", 0, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1162), "Hayalinizdeki yolculuğa adım atın! Araç kiralama firmamız, seyahatlerinizi daha keyifli ve konforlu hale getirmek için burada. Geniş araç filomuzla her türlü ihtiyaca uygun seçenekler sunuyoruz. Güvenilir ve bakımlı araçlarımız, yolculuklarınızı güvenle tamamlamanızı sağlarken, uygun fiyatlarımızla da bütçenizi zorlamıyoruz. Hemen rezervasyon yapın ve unutulmaz bir sürüş deneyimi yaşayın!", "araba.jpg", 25000.0, "Kiralık Araçlar", "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 4, "Güvenlik Teknolojileri", 0, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1164), "Güvenlik Aletleri İle Huzurunuz Bizimle! Geniş ürün yelpazemiz arasında kamera sistemleri, alarm sistemleri, kapı ve pencere sensörleri, güvenlik kameraları ve daha fazlası bulunmaktadır. Güvenlik ihtiyaçlarınıza ve bütçenize uygun çözümler sunuyoruz.", "guvenlik.jpg", 10000.0, "Güvenlik Aletleri", "6504b1ca-d952-4efb-acea-b6abfd00fb49" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "Message", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1187), "Ürün tam aradığım gibi.", 1, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 2, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1194), "DM yoluyla iletişime geçtim.", 1, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 3, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1195), "En fazla kaç gün kiralayabiliyoruz?", 2, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 4, new DateTime(2024, 3, 25, 18, 54, 6, 75, DateTimeKind.Local).AddTicks(1196), "Kaskoları var mı?", 2, "6504b1ca-d952-4efb-acea-b6abfd00fb49" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 2, 1, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 3, 2, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 4, 2, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 5, 3, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 6, 3, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 7, 4, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 8, 4, "6504b1ca-d952-4efb-acea-b6abfd00fb49" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "MessageContent", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 1, 1, "Merhaba ürünlerinizi çok beğendim. Benim işletmeme uygun.", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741", "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 2, 1, "Teşekkür ederim nasıl yardımcı olabilirim?", "6504b1ca-d952-4efb-acea-b6abfd00fb49", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" },
                    { 3, 1, "Ürünleriniz tam aradığım gibi fakat fiyatı bütçemi aşıyor. Yardımcı olabilir misiniz?", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741", "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 4, 1, "Peki. Profilimizdeki iletişim numarsından iletişime geçerseniz yardımcı olmak isteriz. Teşekkürler...", "6504b1ca-d952-4efb-acea-b6abfd00fb49", "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "PostId", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 8000.0, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 2, 1, 9000.0, "6504b1ca-d952-4efb-acea-b6abfd00fb49" },
                    { 3, 3, 9500.0, "9b6c3a15-2c5e-43fd-ace6-a060ac6c2741" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
