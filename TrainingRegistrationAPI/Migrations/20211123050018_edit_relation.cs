using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingRegistrationAPI.Migrations
{
    public partial class edit_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_RegisteredCourse_Tb_M_Payment_PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_User_Tb_M_RegisteredCourse_RegisteredCourseRegisterCourse",
                table: "Tb_M_User");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_RegisteredCourse_PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.RenameColumn(
                name: "RegisteredCourseRegisterCourse",
                table: "Tb_M_User",
                newName: "RegisteredCourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_User_RegisteredCourseRegisterCourse",
                table: "Tb_M_User",
                newName: "IX_Tb_M_User_RegisteredCourseId");

            migrationBuilder.RenameColumn(
                name: "RegisterCourse",
                table: "Tb_M_RegisteredCourse",
                newName: "RegisteredCourseId");

            migrationBuilder.AddColumn<int>(
                name: "RegisteredCourseId",
                table: "Tb_M_Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Payment_RegisteredCourseId",
                table: "Tb_M_Payment",
                column: "RegisteredCourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Payment_Tb_M_RegisteredCourse_RegisteredCourseId",
                table: "Tb_M_Payment",
                column: "RegisteredCourseId",
                principalTable: "Tb_M_RegisteredCourse",
                principalColumn: "RegisteredCourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_User_Tb_M_RegisteredCourse_RegisteredCourseId",
                table: "Tb_M_User",
                column: "RegisteredCourseId",
                principalTable: "Tb_M_RegisteredCourse",
                principalColumn: "RegisteredCourseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Payment_Tb_M_RegisteredCourse_RegisteredCourseId",
                table: "Tb_M_Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_User_Tb_M_RegisteredCourse_RegisteredCourseId",
                table: "Tb_M_User");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_Payment_RegisteredCourseId",
                table: "Tb_M_Payment");

            migrationBuilder.DropColumn(
                name: "RegisteredCourseId",
                table: "Tb_M_Payment");

            migrationBuilder.RenameColumn(
                name: "RegisteredCourseId",
                table: "Tb_M_User",
                newName: "RegisteredCourseRegisterCourse");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_User_RegisteredCourseId",
                table: "Tb_M_User",
                newName: "IX_Tb_M_User_RegisteredCourseRegisterCourse");

            migrationBuilder.RenameColumn(
                name: "RegisteredCourseId",
                table: "Tb_M_RegisteredCourse",
                newName: "RegisterCourse");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Tb_M_RegisteredCourse",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_RegisteredCourse_PaymentId",
                table: "Tb_M_RegisteredCourse",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_RegisteredCourse_Tb_M_Payment_PaymentId",
                table: "Tb_M_RegisteredCourse",
                column: "PaymentId",
                principalTable: "Tb_M_Payment",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_User_Tb_M_RegisteredCourse_RegisteredCourseRegisterCourse",
                table: "Tb_M_User",
                column: "RegisteredCourseRegisterCourse",
                principalTable: "Tb_M_RegisteredCourse",
                principalColumn: "RegisterCourse",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
