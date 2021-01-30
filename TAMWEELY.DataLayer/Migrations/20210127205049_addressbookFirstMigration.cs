using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TAMWEELY.DataLayer.Migrations
{
    public partial class addressbookFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbJobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false),
                    JobId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbEmployees_TbDepartments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "TbDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbEmployees_TbJobs_JobId",
                        column: x => x.JobId,
                        principalTable: "TbJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbEmployees_DepartmentId",
                table: "TbEmployees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TbEmployees_JobId",
                table: "TbEmployees",
                column: "JobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbEmployees");

            migrationBuilder.DropTable(
                name: "TbDepartments");

            migrationBuilder.DropTable(
                name: "TbJobs");
        }
    }
}
