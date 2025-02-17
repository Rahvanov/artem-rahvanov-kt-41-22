using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Rahvanov.Migrations
{
    public partial class FixUniqueHeadTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegrees",
                columns: table => new
                {
                    AcademicDegreeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false, comment: "Наименование учёной степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academic_degrees", x => x.AcademicDegreeId);
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false, comment: "Наименование дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_disciplines", x => x.DisciplineId);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false, comment: "Наименование должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_positions", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar", maxLength: 200, nullable: false, comment: "Наименование кафедры"),
                    FoundationYear = table.Column<DateTime>(type: "date", nullable: false, comment: "Год основания кафедры"),
                    HeadTeacherId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "varchar", maxLength: 200, nullable: false, comment: "ФИО преподавателя"),
                    AcademicDegreeId = table.Column<int>(type: "integer", nullable: false),
                    PositionId = table.Column<int>(type: "integer", nullable: false),
                    DepartmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teachers", x => x.TeacherId);
                    table.ForeignKey(
                        name: "fk_teacher_academic_degree",
                        column: x => x.AcademicDegreeId,
                        principalTable: "AcademicDegrees",
                        principalColumn: "AcademicDegreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_department",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_position",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workloads",
                columns: table => new
                {
                    WorkloadId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workloads", x => x.WorkloadId);
                    table.ForeignKey(
                        name: "fk_workload_discipline",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workload_teacher",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "TeacherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_academic_degrees_name",
                table: "AcademicDegrees",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_departments_name",
                table: "Departments",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "unique_head_teacher_id",
                table: "Departments",
                column: "HeadTeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_disciplines_name",
                table: "Disciplines",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_positions_name",
                table: "Positions",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "idx_teachers_fk_f_academicdegree",
                table: "Teachers",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_teachers_fk_f_department",
                table: "Teachers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "idx_teachers_fk_f_position",
                table: "Teachers",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "idx_workloads_fk_f_discipline",
                table: "Workloads",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "idx_workloads_fk_f_teacher",
                table: "Workloads",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "fk_department_head_teacher",
                table: "Departments",
                column: "HeadTeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_department_head_teacher",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Workloads");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AcademicDegrees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
