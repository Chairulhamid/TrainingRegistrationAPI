using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingRegistrationAPI.Migrations
{
    public partial class add_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisteredCourseRegisterCourse",
                table: "Tb_M_User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tb_M_RegisteredCourse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Tb_M_RegisteredCourse",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Tb_M_Moduls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Tb_M_Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Tb_M_Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_User_RegisteredCourseRegisterCourse",
                table: "Tb_M_User",
                column: "RegisteredCourseRegisterCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_RegisteredCourse_CourseId",
                table: "Tb_M_RegisteredCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_RegisteredCourse_PaymentId",
                table: "Tb_M_RegisteredCourse",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Moduls_CourseId",
                table: "Tb_M_Moduls",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Course_EmployeeId",
                table: "Tb_M_Course",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_Course_TopicId",
                table: "Tb_M_Course",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Course_Tb_M_Employee_EmployeeId",
                table: "Tb_M_Course",
                column: "EmployeeId",
                principalTable: "Tb_M_Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Course_Tb_M_Topic_TopicId",
                table: "Tb_M_Course",
                column: "TopicId",
                principalTable: "Tb_M_Topic",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_Moduls_Tb_M_Course_CourseId",
                table: "Tb_M_Moduls",
                column: "CourseId",
                principalTable: "Tb_M_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_RegisteredCourse_Tb_M_Course_CourseId",
                table: "Tb_M_RegisteredCourse",
                column: "CourseId",
                principalTable: "Tb_M_Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Restrict);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Course_Tb_M_Employee_EmployeeId",
                table: "Tb_M_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Course_Tb_M_Topic_TopicId",
                table: "Tb_M_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_Moduls_Tb_M_Course_CourseId",
                table: "Tb_M_Moduls");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_RegisteredCourse_Tb_M_Course_CourseId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_RegisteredCourse_Tb_M_Payment_PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_User_Tb_M_RegisteredCourse_RegisteredCourseRegisterCourse",
                table: "Tb_M_User");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_User_RegisteredCourseRegisterCourse",
                table: "Tb_M_User");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_RegisteredCourse_CourseId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_RegisteredCourse_PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_Moduls_CourseId",
                table: "Tb_M_Moduls");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_Course_EmployeeId",
                table: "Tb_M_Course");

            migrationBuilder.DropIndex(
                name: "IX_Tb_M_Course_TopicId",
                table: "Tb_M_Course");

            migrationBuilder.DropColumn(
                name: "RegisteredCourseRegisterCourse",
                table: "Tb_M_User");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Tb_M_RegisteredCourse");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Tb_M_Moduls");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Tb_M_Course");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Tb_M_Course");
        }
    }
}
