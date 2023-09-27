using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Summit.Migrations
{
    public partial class initial_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cars",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    plate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    rented = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cars", x => x.car_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    client_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cpf = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password_hash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordSalt = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.client_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dealerships",
                columns: table => new
                {
                    dealership_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dealerships", x => x.dealership_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departures", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_destinations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insurances",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurances", x => x.car_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "intents",
                columns: table => new
                {
                    intent_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    client_id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    car_id = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_intents", x => x.intent_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    customerId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_payments_customers_customerId",
                        column: x => x.customerId,
                        principalTable: "customers",
                        principalColumn: "client_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    insuranceId = table.Column<int>(type: "int", nullable: true),
                    departureId = table.Column<int>(type: "int", nullable: true),
                    destinationId = table.Column<int>(type: "int", nullable: true)
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
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    car_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RentId = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    grade = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.car_id);
                    table.ForeignKey(
                        name: "FK_ratings_rents_RentId",
                        column: x => x.RentId,
                        principalTable: "rents",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
