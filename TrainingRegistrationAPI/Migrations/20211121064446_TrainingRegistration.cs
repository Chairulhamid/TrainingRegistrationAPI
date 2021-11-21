using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingRegistrationAPI.Migrations
{
    public partial class TrainingRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Account",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseFee = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Moduls",
                columns: table => new
                {
                    ModulId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModulTittle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModulDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModulContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Moduls", x => x.ModulId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Payment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPayment = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Payment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_RegisteredCourse",
                columns: table => new
                {
                    RegisterCourse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_RegisteredCourse", x => x.RegisterCourse);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Topic", x => x.TopicId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Tb_M_Employee_Tb_M_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Tb_M_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Tb_M_User_Tb_M_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Tb_M_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_AccountRole",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRole", x => new { x.AccountId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Tb_M_Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Tb_M_Role",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRole_RoleId",
                table: "Tb_M_AccountRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Employee_AccountId",
                table: "Tb_M_Employee",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_User_AccountId",
                table: "Tb_M_User",
                column: "AccountId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_AccountRole");

            migrationBuilder.DropTable(
                name: "Tb_M_Course");

            migrationBuilder.DropTable(
                name: "Tb_M_Employee");

            migrationBuilder.DropTable(
                name: "Tb_M_Moduls");

            migrationBuilder.DropTable(
                name: "Tb_M_Payment");

            migrationBuilder.DropTable(
                name: "Tb_M_RegisteredCourse");

            migrationBuilder.DropTable(
                name: "Tb_M_Topic");

            migrationBuilder.DropTable(
                name: "Tb_M_User");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");

            migrationBuilder.DropTable(
                name: "Tb_M_Account");
        }
    }
}
