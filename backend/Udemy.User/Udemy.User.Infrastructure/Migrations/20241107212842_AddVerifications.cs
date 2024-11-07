using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Udemy.User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddVerifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailVerificationVerificationId",
                table: "DomainEvent",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordChangeVerificationVerificationId",
                table: "DomainEvent",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmailVerifications",
                columns: table => new
                {
                    VerificationId = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EmailOneTimeCode = table.Column<string>(type: "text", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "text", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifications", x => x.VerificationId);
                });

            migrationBuilder.CreateTable(
                name: "PasswordChangeVerifications",
                columns: table => new
                {
                    VerificationId = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordChangeCode = table.Column<string>(type: "text", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordChangeVerifications", x => x.VerificationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_EmailVerificationVerificationId",
                table: "DomainEvent",
                column: "EmailVerificationVerificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_PasswordChangeVerificationVerificationId",
                table: "DomainEvent",
                column: "PasswordChangeVerificationVerificationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifications_Email",
                table: "EmailVerifications",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordChangeVerifications_Email",
                table: "PasswordChangeVerifications",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_EmailVerifications_EmailVerificationVerificatio~",
                table: "DomainEvent",
                column: "EmailVerificationVerificationId",
                principalTable: "EmailVerifications",
                principalColumn: "VerificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_DomainEvent_PasswordChangeVerifications_PasswordChangeVerif~",
                table: "DomainEvent",
                column: "PasswordChangeVerificationVerificationId",
                principalTable: "PasswordChangeVerifications",
                principalColumn: "VerificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_EmailVerifications_EmailVerificationVerificatio~",
                table: "DomainEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_DomainEvent_PasswordChangeVerifications_PasswordChangeVerif~",
                table: "DomainEvent");

            migrationBuilder.DropTable(
                name: "EmailVerifications");

            migrationBuilder.DropTable(
                name: "PasswordChangeVerifications");

            migrationBuilder.DropIndex(
                name: "IX_DomainEvent_EmailVerificationVerificationId",
                table: "DomainEvent");

            migrationBuilder.DropIndex(
                name: "IX_DomainEvent_PasswordChangeVerificationVerificationId",
                table: "DomainEvent");

            migrationBuilder.DropColumn(
                name: "EmailVerificationVerificationId",
                table: "DomainEvent");

            migrationBuilder.DropColumn(
                name: "PasswordChangeVerificationVerificationId",
                table: "DomainEvent");
        }
    }
}
