using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Summit.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "seguros",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "chegadas",
                newName: "Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "seguros",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SeguroId",
                table: "alugueis",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "seguros",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "chegadas",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "seguros",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "SeguroId",
                table: "alugueis",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");
        }
    }
}
