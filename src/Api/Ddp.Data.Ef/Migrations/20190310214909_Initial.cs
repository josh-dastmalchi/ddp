using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ddp.Data.Ef.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                });

            migrationBuilder.CreateTable(
                name: "EventTables",
                columns: table => new
                {
                    EventId = table.Column<Guid>(nullable: false),
                    EventType = table.Column<string>(maxLength: 450, nullable: false),
                    EventData = table.Column<string>(nullable: true),
                    EntityType = table.Column<string>(maxLength: 450, nullable: false),
                    EntityId = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTables", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Concepts",
                columns: table => new
                {
                    ConceptId = table.Column<Guid>(nullable: false),
                    DomainId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concepts", x => x.ConceptId);
                    table.ForeignKey(
                        name: "FK_Concepts_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "DomainId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConceptAttributes",
                columns: table => new
                {
                    ConceptAttributeId = table.Column<Guid>(nullable: false),
                    ConceptId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptAttributes", x => x.ConceptAttributeId);
                    table.ForeignKey(
                        name: "FK_ConceptAttributes_Concepts_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concepts",
                        principalColumn: "ConceptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptAttributes_ConceptId",
                table: "ConceptAttributes",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Concepts_DomainId",
                table: "Concepts",
                column: "DomainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConceptAttributes");

            migrationBuilder.DropTable(
                name: "EventTables");

            migrationBuilder.DropTable(
                name: "Concepts");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
