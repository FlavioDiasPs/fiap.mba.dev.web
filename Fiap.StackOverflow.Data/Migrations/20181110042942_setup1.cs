using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.StackOverflow.Infra.Data.Migrations
{
    public partial class setup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Author",
                unicode: false,
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityId",
                table: "Author",
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
