using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TextBooky.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    PostCode = table.Column<string>(nullable: false),
                    OrderTotal = table.Column<decimal>(nullable: false),
                    OrderPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "TextBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    InStock = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextBooks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    TextBookId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_TextBooks_TextBookId",
                        column: x => x.TextBookId,
                        principalTable: "TextBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingCartId = table.Column<string>(nullable: true),
                    TextbookId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_TextBooks_TextbookId",
                        column: x => x.TextbookId,
                        principalTable: "TextBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Life Sciences" },
                    { 2, "Computer Science" },
                    { 3, "Physical Sciences" },
                    { 4, "Mathematics" },
                    { 5, "Engineering" }
                });

            migrationBuilder.InsertData(
                table: "TextBooks",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "ISBN", "ImageUrl", "InStock", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "David L. Nelson, Michael M. Cox", 1, "Lehninger Principles of Biochemistry is the #1 bestseller for the introductory biochemistry course because it brings clarity and coherence to an often unwieldy discipline, offering a thoroughly updated survey of biochemistry’s enduring principles, definitive discoveries, and groundbreaking new advances with each edition. This new Seventh Edition maintains the qualities that have distinguished the text since Albert Lehninger’s original edition—clear writing, careful explanations of difficult concepts, helpful problem-solving support, and insightful communication of contemporary biochemistry’s core ideas, new techniques, and pivotal discoveries. Again, David Nelson and Michael Cox introduce students to an extraordinary amount of exciting new findings without an overwhelming amount of extra discussion or detail.", "978-0716743392", "/img/Lehninger.jpg", true, 60.45m, "Lehninger Principles of Biochemistry" },
                    { 2, "Joseph Albahari, Ben Albahari", 2, "When you have questions about C# 7.0 or the .NET CLR and its core Framework assemblies, this bestselling guide has the answers you need. Since its debut in 2000, C# has become a language of unusual flexibility and breadth, but its continual growth means there's always more to learn. Organized around concepts and use cases, this updated edition provides intermediate and advanced programmers with a concise map of C# and .NET knowledge.Get up to speed on the C# language, from the basics of syntax and variables to advanced topics such as pointers, operator overloading, and dynamic binding Dig deep into LINQ via three chapters dedicated to the topic Explore concurrency and asynchrony, advanced threading, and parallel programming. Work with .NET features, including XML, regular expressions, networking, serialization, reflection, application domains, and security Delve into Roslyn, the modular C# 7.0 compiler-as-a-service.", "978-1491987650", "/img/C7-in-a-nutshell.jpg", true, 40.55m, "C# 7.0 in a Nutshell" },
                    { 6, "John Skeet", 2, "C# in Depth, Fourth Edition is your key to unlocking the powerful new features added to the language in C# 5, 6, and 7. Following the expert guidance of C# legend Jon Skeet, you'll master asynchronous functions, expression-bodied members, interpolated strings, tuples, and much more.", "978-1617294532", "/img/c-in-depth.png", true, 19.00m, "C# in Depth" },
                    { 3, "Travis Norsen", 3, "Authored by an acclaimed teacher of quantum physics and philosophy, this textbook pays special attention to the aspects that many courses sweep under the carpet. Traditional courses in quantum mechanics teach students how to use the quantum formalism to make calculations. But even the best students - indeed, especially the best students - emerge rather confused about what, exactly, the theory says is going on, physically, in microscopic systems. This supplementary textbook is designed to help such students understand that they are not alone in their confusions (luminaries such as Albert Einstein, Erwin Schroedinger, and John Stewart Bell having shared them), to sharpen their understanding of the most important difficulties associated with interpreting quantum theory in a realistic manner, and to introduce them to the most promising attempts to formulate the theory in a way that is physically clear and coherent.", "978-3319658667", "/img/qm-norsen.jpg", true, 30.00m, "Foundations of Quantum Mechanics" },
                    { 5, "Martin Aigner, Gunter M. Ziegler", 4, "Sixth edition. The book is divided into three parts, namely: Introduction, The Aircraft, and Air Transportation, Airports, and Air Navigation. The first part is divided in two chapters in which the student must achieve to understand the basic elements of atmospheric flight (ISA and planetary references) and the technology that apply to the aerospace sector, in particular with a specific comprehension of the elements of an aircraft. The second part focuses on the aircraft and it is divided in five chapters that introduce the student to aircraft aerodynamics (fluid mechanics, airfoils, wings, high-lift devices), aircraft materials and structures, aircraft propulsion, aircraft instruments and systems, and atmospheric flight mechanics (performances and stability and control). The third part is devoted to understand the global air transport system (covering both regulatory and economical frameworks), the airports, and the global air navigation system (its history, current status, and future development). The theoretical contents are illustrated with figures and complemented with some problems/exercises. The problems deal, fundamentally, with aerodynamics and flight mechanics, and were proposed in different exams. The course is complemented by a practical approach.", "978-3662572641", "/img/proofs.jpg", true, 40.55m, "Proofs from THE BOOK" },
                    { 4, "Manuel Soler Burillo", 5, "The book is divided into three parts, namely: Introduction, The Aircraft, and Air Transportation, Airports, and Air Navigation. The first part is divided in two chapters in which the student must achieve to understand the basic elements of atmospheric flight (ISA and planetary references) and the technology that apply to the aerospace sector, in particular with a specific comprehension of the elements of an aircraft. The second part focuses on the aircraft and it is divided in five chapters that introduce the student to aircraft aerodynamics (fluid mechanics, airfoils, wings, high-lift devices), aircraft materials and structures, aircraft propulsion, aircraft instruments and systems, and atmospheric flight mechanics (performances and stability and control). The third part is devoted to understand the global air transport system (covering both regulatory and economical frameworks), the airports, and the global air navigation system (its history, current status, and future development). The theoretical contents are illustrated with figures and complemented with some problems/exercises. The problems deal, fundamentally, with aerodynamics and flight mechanics, and were proposed in different exams. The course is complemented by a practical approach.", "978-1493727759", "/img/a-engineering.jpg", true, 16.99m, "Fundamentals of Aerospace Engineering" }
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
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_TextBookId",
                table: "OrderDetails",
                column: "TextBookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_TextbookId",
                table: "ShoppingCartItems",
                column: "TextbookId");

            migrationBuilder.CreateIndex(
                name: "IX_TextBooks_CategoryId",
                table: "TextBooks",
                column: "CategoryId");
        }

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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "TextBooks");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
