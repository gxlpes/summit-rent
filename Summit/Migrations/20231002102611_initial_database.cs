using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Summit.Migrations
{
    public partial class initial_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    plate = table.Column<string>(type: "TEXT", nullable: true),
                    rented = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    client_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    password_hash = table.Column<string>(type: "TEXT", nullable: true),
                    PasswordSalt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "dealerships",
                columns: table => new
                {
                    dealership_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    city = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerships", x => x.dealership_id);
                });

            migrationBuilder.CreateTable(
                name: "departures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.car_id);
                });

            migrationBuilder.CreateTable(
                name: "intents",
                columns: table => new
                {
                    intent_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    client_id = table.Column<string>(type: "TEXT", nullable: true),
                    car_id = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intents", x => x.intent_id);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaymentMethod = table.Column<string>(type: "TEXT", nullable: true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    customerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_payments_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "client_id");
                });

            migrationBuilder.CreateTable(
                name: "rents",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CarId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: true),
                    insuranceId = table.Column<int>(type: "INTEGER", nullable: true),
                    departureId = table.Column<int>(type: "INTEGER", nullable: true),
                    destinationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rents", x => x.id);
                    table.ForeignKey(
                        name: "FK_rents_cars_CarId",
                        column: x => x.CarId,
                        principalTable: "cars",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "FK_rents_customers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "customers",
                        principalColumn: "client_id");
                    table.ForeignKey(
                        name: "FK_rents_departures_departureId",
                        column: x => x.departureId,
                        principalTable: "departures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rents_destinations_destinationId",
                        column: x => x.destinationId,
                        principalTable: "destinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_rents_insurances_insuranceId",
                        column: x => x.insuranceId,
                        principalTable: "insurances",
                        principalColumn: "car_id");
                    table.ForeignKey(
                        name: "FK_rents_payments_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "payments",
                        principalColumn: "car_id");
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentId = table.Column<int>(type: "INTEGER", nullable: true),
                    comment = table.Column<string>(type: "TEXT", nullable: true),
                    grade = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_ratings_rents_RentId",
                        column: x => x.RentId,
                        principalTable: "rents",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_customerId",
                table: "payments",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_RentId",
                table: "ratings",
                column: "RentId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_CarId",
                table: "rents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_ClientId",
                table: "rents",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_departureId",
                table: "rents",
                column: "departureId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_destinationId",
                table: "rents",
                column: "destinationId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_insuranceId",
                table: "rents",
                column: "insuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_rents_PaymentId",
                table: "rents",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dealerships");

            migrationBuilder.DropTable(
                name: "intents");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "rents");

            migrationBuilder.DropTable(
                name: "cars");

            migrationBuilder.DropTable(
                name: "departures");

            migrationBuilder.DropTable(
                name: "destinations");

            migrationBuilder.DropTable(
                name: "insurances");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
