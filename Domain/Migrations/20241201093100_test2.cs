using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answer_users_test_binds_user_survey_bind_id",
                table: "answer");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "started_at",
                table: "user_survey_bind",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddForeignKey(
                name: "fk_answer_user_survey_binds_user_survey_bind_id",
                table: "answer",
                column: "user_survey_bind_id",
                principalTable: "user_survey_bind",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_answer_user_survey_binds_user_survey_bind_id",
                table: "answer");

            migrationBuilder.DropColumn(
                name: "started_at",
                table: "user_survey_bind");

            migrationBuilder.AddForeignKey(
                name: "fk_answer_users_test_binds_user_survey_bind_id",
                table: "answer",
                column: "user_survey_bind_id",
                principalTable: "user_survey_bind",
                principalColumn: "id");
        }
    }
}
