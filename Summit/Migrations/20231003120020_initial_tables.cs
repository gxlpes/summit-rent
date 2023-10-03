using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Summit.Migrations
{
    public partial class initial_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "carros",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    placa = table.Column<string>(type: "TEXT", nullable: false),
                    alugado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "chegadas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    chegada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chegadas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "concessionarias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    cidade = table.Column<string>(type: "TEXT", nullable: false),
                    estado = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concessionarias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "saidas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    saida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: true),
                    descricao = table.Column<string>(type: "TEXT", nullable: true),
                    cidade = table.Column<string>(type: "TEXT", nullable: true),
                    estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saidas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "seguros",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    preco = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seguros", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tentativas",
                columns: table => new
                {
                    cliente_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    id_carro = table.Column<Guid>(type: "TEXT", nullable: false),
                    date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tentativas", x => x.cliente_id);
                });

            migrationBuilder.CreateTable(
                name: "pagamentos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    metodo = table.Column<string>(type: "TEXT", nullable: true),
                    valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    data_pagamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_pagamentos_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "alugueis",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CarroId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ClienteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PagamentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SeguroId = table.Column<int>(type: "INTEGER", nullable: false),
                    SaidaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ChegadaId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alugueis", x => x.id);
                    table.ForeignKey(
                        name: "FK_alugueis_carros_CarroId",
                        column: x => x.CarroId,
                        principalTable: "carros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alugueis_chegadas_ChegadaId",
                        column: x => x.ChegadaId,
                        principalTable: "chegadas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alugueis_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alugueis_pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "pagamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alugueis_saidas_SaidaId",
                        column: x => x.SaidaId,
                        principalTable: "saidas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_alugueis_seguros_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "seguros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "avaliacoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    comentario = table.Column<string>(type: "TEXT", nullable: true),
                    estrelas = table.Column<int>(type: "INTEGER", nullable: false),
                    AluguelId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avaliacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_avaliacoes_alugueis_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "alugueis",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_CarroId",
                table: "alugueis",
                column: "CarroId");

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_ChegadaId",
                table: "alugueis",
                column: "ChegadaId");

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_ClienteId",
                table: "alugueis",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_PagamentoId",
                table: "alugueis",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_SaidaId",
                table: "alugueis",
                column: "SaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_alugueis_SeguroId",
                table: "alugueis",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_avaliacoes_AluguelId",
                table: "avaliacoes",
                column: "AluguelId");

            migrationBuilder.CreateIndex(
                name: "IX_pagamentos_ClienteId",
                table: "pagamentos",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avaliacoes");

            migrationBuilder.DropTable(
                name: "concessionarias");

            migrationBuilder.DropTable(
                name: "tentativas");

            migrationBuilder.DropTable(
                name: "alugueis");

            migrationBuilder.DropTable(
                name: "carros");

            migrationBuilder.DropTable(
                name: "chegadas");

            migrationBuilder.DropTable(
                name: "pagamentos");

            migrationBuilder.DropTable(
                name: "saidas");

            migrationBuilder.DropTable(
                name: "seguros");

            migrationBuilder.DropTable(
                name: "clientes");
        }
    }
}
