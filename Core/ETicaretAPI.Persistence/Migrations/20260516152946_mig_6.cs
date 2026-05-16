using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class mig_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // PostgreSQL'deki ortak "Files" tablosuna Storage kolonunu zorla ekliyoruz
            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Files",
                type: "text",
                nullable: true); // Halihazırda yüklü resimler varsa patlamasın diye nullable (boş geçilebilir) yapıyoruz
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
        name: "Storage",
        table: "Files");

        }
    }
}
