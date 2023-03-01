using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDay = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberGuest = table.Column<int>(type: "int", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AptSuite = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RoomFloor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RoomNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TotalBill = table.Column<double>(type: "float", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardExp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CardCvc = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ArrivalTime = table.Column<DateTime>(type: "date", nullable: false),
                    LeavingTime = table.Column<DateTime>(type: "date", nullable: false),
                    CheckIn = table.Column<bool>(type: "bit", nullable: false),
                    BreakFast = table.Column<int>(type: "int", nullable: false),
                    Lunch = table.Column<int>(type: "int", nullable: false),
                    Dinner = table.Column<int>(type: "int", nullable: false),
                    Cleaning = table.Column<bool>(type: "bit", nullable: false),
                    Towel = table.Column<bool>(type: "bit", nullable: false),
                    SSurprise = table.Column<bool>(type: "bit", nullable: false),
                    SupplyStatus = table.Column<bool>(type: "bit", nullable: false),
                    FoodBill = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
