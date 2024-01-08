using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraveyardManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AddressLine1 = table.Column<string>(type: "TEXT", nullable: false),
                    AddressLine2 = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Region = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GraveyardOwner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraveyardOwner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GraveyardOwner_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Graveyards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graveyards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graveyards_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Graveyards_GraveyardOwner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "GraveyardOwner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRemoved = table.Column<bool>(type: "INTEGER", nullable: false),
                    GraveyardId = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<decimal>(type: "TEXT", nullable: false),
                    Y = table.Column<decimal>(type: "TEXT", nullable: false),
                    Angle = table.Column<decimal>(type: "TEXT", nullable: false),
                    GraveyardPart = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plots_Graveyards_GraveyardId",
                        column: x => x.GraveyardId,
                        principalTable: "Graveyards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Graves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PaidUntil = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PlotAcquisition = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    PlotId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graves_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RemovedGraves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlotId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlotAcquisition = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    GraveRemoval = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemovedGraves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RemovedGraves_Plots_PlotId",
                        column: x => x.PlotId,
                        principalTable: "Plots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Birth = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Death = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Ordained = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Funeral = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GraveId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlotId = table.Column<int>(type: "INTEGER", nullable: false),
                    RemovedGraveId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Graves_GraveId",
                        column: x => x.GraveId,
                        principalTable: "Graves",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_People_RemovedGraves_RemovedGraveId",
                        column: x => x.RemovedGraveId,
                        principalTable: "RemovedGraves",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Graves_PlotId",
                table: "Graves",
                column: "PlotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GraveyardOwner_AddressId",
                table: "GraveyardOwner",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Graveyards_AddressId",
                table: "Graveyards",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Graveyards_OwnerId",
                table: "Graveyards",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_People_GraveId",
                table: "People",
                column: "GraveId");

            migrationBuilder.CreateIndex(
                name: "IX_People_RemovedGraveId",
                table: "People",
                column: "RemovedGraveId");

            migrationBuilder.CreateIndex(
                name: "IX_Plots_GraveyardId",
                table: "Plots",
                column: "GraveyardId");

            migrationBuilder.CreateIndex(
                name: "IX_RemovedGraves_PlotId",
                table: "RemovedGraves",
                column: "PlotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Graves");

            migrationBuilder.DropTable(
                name: "RemovedGraves");

            migrationBuilder.DropTable(
                name: "Plots");

            migrationBuilder.DropTable(
                name: "Graveyards");

            migrationBuilder.DropTable(
                name: "GraveyardOwner");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
