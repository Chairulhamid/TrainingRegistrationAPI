using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingRegistrationAPI.Migrations
{
    public partial class init : Migration
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
                name: "Tb_M_AccountRole",
                columns: table => new
                {
                    AccountRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRole", x => x.AccountRoleId);
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
                name: "Tb_M_Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Employee", x => x.EmployeeId);
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
                    Account_Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Id = table.Column<int>(type: "int", nullable: false),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.Account_Role_Id);
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
                    RegistDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_User", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_Account");

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
                name: "Tb_M_Role");

            migrationBuilder.DropTable(
                name: "Tb_M_Topic");

            migrationBuilder.DropTable(
                name: "Tb_M_User");
        }
    }
}
