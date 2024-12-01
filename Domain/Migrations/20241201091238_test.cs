using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_survey_bind_survey_test_id",
                table: "user_survey_bind");

            migrationBuilder.RenameColumn(
                name: "test_id",
                table: "user_survey_bind",
                newName: "survey_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_survey_bind_test_id",
                table: "user_survey_bind",
                newName: "ix_user_survey_bind_survey_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_survey_bind_survey_survey_id",
                table: "user_survey_bind",
                column: "survey_id",
                principalTable: "survey",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_survey_bind_survey_survey_id",
                table: "user_survey_bind");

            migrationBuilder.RenameColumn(
                name: "survey_id",
                table: "user_survey_bind",
                newName: "test_id");

            migrationBuilder.RenameIndex(
                name: "ix_user_survey_bind_survey_id",
                table: "user_survey_bind",
                newName: "ix_user_survey_bind_test_id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_survey_bind_survey_test_id",
                table: "user_survey_bind",
                column: "test_id",
                principalTable: "survey",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
