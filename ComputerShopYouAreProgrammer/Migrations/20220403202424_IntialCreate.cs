using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerShopYouAreProgrammer.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СonsignmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOrder = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesmanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "СonsignmentOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СonsignmentId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_СonsignmentOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_СonsignmentOrders_Consignments_СonsignmentId",
                        column: x => x.СonsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_СonsignmentOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    СonsignmentId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRequests_Consignments_СonsignmentId",
                        column: x => x.СonsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRequests_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonalBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesonalBuildName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePersonalBuild = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalBuilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalBuilds_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalBuilds_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentPersonalBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    PersonalBuildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentPersonalBuilds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComponentPersonalBuilds_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentPersonalBuilds_PersonalBuilds_PersonalBuildId",
                        column: x => x.PersonalBuildId,
                        principalTable: "PersonalBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    СonsignmentId = table.Column<int>(type: "int", nullable: false),
                    PersonalBuildId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Consignments_СonsignmentId",
                        column: x => x.СonsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalProducts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalProducts_PersonalBuilds_PersonalBuildId",
                        column: x => x.PersonalBuildId,
                        principalTable: "PersonalBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinalProductComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinalProductId = table.Column<int>(type: "int", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalProductComponents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalProductComponents_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinalProductComponents_FinalProducts_FinalProductId",
                        column: x => x.FinalProductId,
                        principalTable: "FinalProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_СonsignmentOrders_СonsignmentId",
                table: "СonsignmentOrders",
                column: "СonsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_СonsignmentOrders_OrderId",
                table: "СonsignmentOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPersonalBuilds_ComponentId",
                table: "ComponentPersonalBuilds",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentPersonalBuilds_PersonalBuildId",
                table: "ComponentPersonalBuilds",
                column: "PersonalBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProductComponents_ComponentId",
                table: "FinalProductComponents",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProductComponents_FinalProductId",
                table: "FinalProductComponents",
                column: "FinalProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_СonsignmentId",
                table: "FinalProducts",
                column: "СonsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_ComponentId",
                table: "FinalProducts",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_EmployeeId",
                table: "FinalProducts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalProducts_PersonalBuildId",
                table: "FinalProducts",
                column: "PersonalBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_СonsignmentId",
                table: "OrderRequests",
                column: "СonsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_OrderId",
                table: "OrderRequests",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRequests_RequestId",
                table: "OrderRequests",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBuilds_EmployeeId",
                table: "PersonalBuilds",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalBuilds_RequestId",
                table: "PersonalBuilds",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_SalesmanId",
                table: "Requests",
                column: "SalesmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "СonsignmentOrders");

            migrationBuilder.DropTable(
                name: "ComponentPersonalBuilds");

            migrationBuilder.DropTable(
                name: "FinalProductComponents");

            migrationBuilder.DropTable(
                name: "OrderRequests");

            migrationBuilder.DropTable(
                name: "FinalProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Consignments");

            migrationBuilder.DropTable(
                name: "PersonalBuilds");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Salesmen");
        }
    }
}
