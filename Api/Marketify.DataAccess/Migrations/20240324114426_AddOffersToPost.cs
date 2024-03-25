using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOffersToPost : Migration
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    { "2713630c-519f-4f4d-ab3e-3db6a4d8e2e8", null, "Customer", "CUSTOMER" },
                    { "c1c43196-d73f-4dc3-a88e-e386c8355f5d", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "Job", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "42ad8624-bd91-4bd6-b5a1-15938670cbad", 0, "01addb6d-2c24-45ac-8b33-db66af16de01", "admin@info.com", true, true, "Admin", false, null, "ADMIN@INFO.COM", "ADMIN", "AQAAAAIAAYagAAAAEHKeLCEo7yS3GGlw508dhwcHbv6qVEDEt1OuEgAHkIbfV3c7irN4tIZ5ZqPkBbl7Sg==", "5555555555", true, "3cdb7787-137f-4bb1-8f6c-7407f387b72b", false, "admin" },
                    { "d1704288-43da-4ac2-a29a-65719437adfd", 0, "d30b57fb-10fb-4ec8-a6ba-6375256d47e6", "customer@info.com", true, true, "Rent a Car and Security", false, null, "CUSTOMER@INFO.COM", "CUSTOMER", "AQAAAAIAAYagAAAAEJhdSoqQ19j0kMci+NHTRn5fe2AbXthdgsk7O6Wc+ZtzY7+x9jH4aF0k60e2Wo4x7Q==", "5555555555", true, "63fc3bd6-61c0-4b29-8394-05d386d3db12", false, "customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c1c43196-d73f-4dc3-a88e-e386c8355f5d", "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { "2713630c-519f-4f4d-ab3e-3db6a4d8e2e8", "d1704288-43da-4ac2-a29a-65719437adfd" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "UserId1", "UserId2" },
                values: new object[] { 1, "42ad8624-bd91-4bd6-b5a1-15938670cbad", "d1704288-43da-4ac2-a29a-65719437adfd" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Category", "CreatedDate", "Description", "ImageUrl", "Price", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "Mobilya", new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8759), "Modern ofis mobilyaları, işyerlerinizdeki yaşamı kolaylaştıran ve çalışma verimliliğini artıran pratik ve şık çözümler sunar. Zarif tasarımlarıyla dikkat çeken bu mobilyalar, işlevselliği estetikle birleştirirken, ergonomik yapılarıyla da çalışanların konforunu sağlar. Esnek modüler sistemleri ve akıllı depolama çözümleri sayesinde, ofis alanınızı verimli bir şekilde düzenleyebilir ve değişen ihtiyaçlara kolayca uyum sağlayabilirsiniz.", "mobilya.jpg", 10000.0, "Modern Ofis Mobilyaları", "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 2, "Beyaz Eşya", new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8774), "Ev yaşamınızı kolaylaştıran beyaz eşyalarımızla hayatınızı daha konforlu hale getirin! Yüksek kaliteli ve güvenilir ürünlerimiz, modern tasarımıyla evinizin estetiğine katkı sağlarken, enerji verimliliğiyle de bütçenize dost. Pratik kullanımıyla zamanınızı verimli kullanmanıza yardımcı olurken, günlük yaşamınızı daha keyifli hale getirin.", "beyaz-esya.jpg", 15000.0, "Son Teknoloji Beyaz Eşyalar", "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 3, "Araba", new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8776), "Hayalinizdeki yolculuğa adım atın! Araç kiralama firmamız, seyahatlerinizi daha keyifli ve konforlu hale getirmek için burada. Geniş araç filomuzla her türlü ihtiyaca uygun seçenekler sunuyoruz. Güvenilir ve bakımlı araçlarımız, yolculuklarınızı güvenle tamamlamanızı sağlarken, uygun fiyatlarımızla da bütçenizi zorlamıyoruz. Hemen rezervasyon yapın ve unutulmaz bir sürüş deneyimi yaşayın!", "araba.jpg", 25000.0, "Kiralık Araçlar", "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 4, "Güvenlik Teknolojileri", new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8778), "Güvenlik Aletleri İle Huzurunuz Bizimle! Geniş ürün yelpazemiz arasında kamera sistemleri, alarm sistemleri, kapı ve pencere sensörleri, güvenlik kameraları ve daha fazlası bulunmaktadır. Güvenlik ihtiyaçlarınıza ve bütçenize uygun çözümler sunuyoruz.", "guvenlik.jpg", 10000.0, "Güvenlik Aletleri", "d1704288-43da-4ac2-a29a-65719437adfd" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedDate", "Message", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8802), "Ürün tam aradığım gibi.", 1, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 2, new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8806), "DM yoluyla iletişime geçtim.", 1, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 3, new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8808), "En fazla kaç gün kiralayabiliyoruz?", 2, "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 4, new DateTime(2024, 3, 24, 14, 44, 26, 79, DateTimeKind.Local).AddTicks(8809), "Kaskoları var mı?", 2, "d1704288-43da-4ac2-a29a-65719437adfd" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 2, 1, "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 3, 2, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 4, 2, "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 5, 3, "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 6, 3, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 7, 4, "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 8, 4, "d1704288-43da-4ac2-a29a-65719437adfd" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatId", "MessageContent", "RecipientId", "SenderId" },
                values: new object[,]
                {
                    { 1, 1, "Merhaba ürünlerinizi çok beğendim. Benim işletmeme uygun.", "42ad8624-bd91-4bd6-b5a1-15938670cbad", "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 2, 1, "Teşekkür ederim nasıl yardımcı olabilirim?", "d1704288-43da-4ac2-a29a-65719437adfd", "42ad8624-bd91-4bd6-b5a1-15938670cbad" },
                    { 3, 1, "Ürünleriniz tam aradığım gibi fakat fiyatı bütçemi aşıyor. Yardımcı olabilir misiniz?", "42ad8624-bd91-4bd6-b5a1-15938670cbad", "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 4, 1, "Peki. Profilimizdeki iletişim numarsından iletişime geçerseniz yardımcı olmak isteriz. Teşekkürler...", "d1704288-43da-4ac2-a29a-65719437adfd", "42ad8624-bd91-4bd6-b5a1-15938670cbad" }
                });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "OfferId", "PostId", "Price", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 8000.0, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 2, 1, 9000.0, "d1704288-43da-4ac2-a29a-65719437adfd" },
                    { 3, 3, 9500.0, "42ad8624-bd91-4bd6-b5a1-15938670cbad" }
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
