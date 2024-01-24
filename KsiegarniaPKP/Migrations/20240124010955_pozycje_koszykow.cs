using Microsoft.EntityFrameworkCore.Migrations;

namespace KsiegarniaPKP.Migrations
{
    public partial class pozycje_koszykow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.InsertData(
                table: "PozycjaKoszyka",
                columns: new[] { "KlientId", "OfertaId" },
                values: new object[,]
                {
                    { "SzymonWieczorek_uzytkownik@gmail.com", 1 },
                    { "SzymonWieczorek_uzytkownik@gmail.com", 2 },
                    { "SzymonWieczorek_uzytkownik@gmail.com", 4 },
                    { "SzymonWieczorek_uzytkownik@gmail.com", 7 },
                    { "SzymonWieczorek_uzytkownik@gmail.com", 11 }
                });

        }



        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PozycjaKoszyka",
                keyColumns: new[] { "KlientId", "OfertaId" },
                keyValues: new object[] { "SzymonWieczorek_uzytkownik@gmail.com", 1 });

            migrationBuilder.DeleteData(
                table: "PozycjaKoszyka",
                keyColumns: new[] { "KlientId", "OfertaId" },
                keyValues: new object[] { "SzymonWieczorek_uzytkownik@gmail.com", 2 });

            migrationBuilder.DeleteData(
                table: "PozycjaKoszyka",
                keyColumns: new[] { "KlientId", "OfertaId" },
                keyValues: new object[] { "SzymonWieczorek_uzytkownik@gmail.com", 4 });

            migrationBuilder.DeleteData(
                table: "PozycjaKoszyka",
                keyColumns: new[] { "KlientId", "OfertaId" },
                keyValues: new object[] { "SzymonWieczorek_uzytkownik@gmail.com", 7 });

            migrationBuilder.DeleteData(
                table: "PozycjaKoszyka",
                keyColumns: new[] { "KlientId", "OfertaId" },
                keyValues: new object[] { "SzymonWieczorek_uzytkownik@gmail.com", 11 });

        }
    }
}
