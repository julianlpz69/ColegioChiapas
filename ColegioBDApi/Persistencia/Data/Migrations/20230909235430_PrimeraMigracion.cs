using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "colegio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreColegio = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DirreccionColegio = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colegio", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreGrupo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreMateria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HorasSemanales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materia", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipoDirectivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreCargo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HorasTrabajo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoDirectivo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdColegioFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirreccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_profesor_colegio_IdColegioFK",
                        column: x => x.IdColegioFK,
                        principalTable: "colegio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estudiante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false),
                    IdColegioFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirreccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estudiante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estudiante_colegio_IdColegioFK",
                        column: x => x.IdColegioFK,
                        principalTable: "colegio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_estudiante_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupoMateria",
                columns: table => new
                {
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false),
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupoMateria", x => new { x.IdGrupoFK, x.IdMateriaFK });
                    table.ForeignKey(
                        name: "FK_grupoMateria_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupoMateria_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "directivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdColegioFK = table.Column<int>(type: "int", nullable: false),
                    IdTipoDirectivoFK = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirreccion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Documento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directivo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_directivo_colegio_IdColegioFK",
                        column: x => x.IdColegioFK,
                        principalTable: "colegio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_directivo_tipoDirectivo_IdTipoDirectivoFK",
                        column: x => x.IdTipoDirectivoFK,
                        principalTable: "tipoDirectivo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "grupoProfesor",
                columns: table => new
                {
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false),
                    IdGrupoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupoProfesor", x => new { x.IdGrupoFK, x.IdProfesorFK });
                    table.ForeignKey(
                        name: "FK_grupoProfesor_grupo_IdGrupoFK",
                        column: x => x.IdGrupoFK,
                        principalTable: "grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_grupoProfesor_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profesorMateria",
                columns: table => new
                {
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false),
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profesorMateria", x => new { x.IdMateriaFK, x.IdProfesorFK });
                    table.ForeignKey(
                        name: "FK_profesorMateria_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_profesorMateria_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "boletin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Corte = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCorte = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_boletin_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FechaMatricula = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodigoMatricula = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matricula_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotaExamenes = table.Column<double>(type: "double", nullable: false),
                    NotaTalleres = table.Column<double>(type: "double", nullable: false),
                    NotaAutoevaluacion = table.Column<double>(type: "double", nullable: false),
                    NotaActitudinal = table.Column<double>(type: "double", nullable: false),
                    NotaTareas = table.Column<double>(type: "double", nullable: false),
                    IdProfesorFK = table.Column<int>(type: "int", nullable: false),
                    IdEstudianteFK = table.Column<int>(type: "int", nullable: false),
                    IdMateriaFK = table.Column<int>(type: "int", nullable: false),
                    IdBoletinFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_nota_boletin_IdBoletinFK",
                        column: x => x.IdBoletinFK,
                        principalTable: "boletin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_estudiante_IdEstudianteFK",
                        column: x => x.IdEstudianteFK,
                        principalTable: "estudiante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_materia_IdMateriaFK",
                        column: x => x.IdMateriaFK,
                        principalTable: "materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nota_profesor_IdProfesorFK",
                        column: x => x.IdProfesorFK,
                        principalTable: "profesor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_boletin_IdEstudianteFK",
                table: "boletin",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_directivo_IdColegioFK",
                table: "directivo",
                column: "IdColegioFK");

            migrationBuilder.CreateIndex(
                name: "IX_directivo_IdTipoDirectivoFK",
                table: "directivo",
                column: "IdTipoDirectivoFK");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_IdColegioFK",
                table: "estudiante",
                column: "IdColegioFK");

            migrationBuilder.CreateIndex(
                name: "IX_estudiante_IdGrupoFK",
                table: "estudiante",
                column: "IdGrupoFK");

            migrationBuilder.CreateIndex(
                name: "IX_grupoMateria_IdMateriaFK",
                table: "grupoMateria",
                column: "IdMateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_grupoProfesor_IdProfesorFK",
                table: "grupoProfesor",
                column: "IdProfesorFK");

            migrationBuilder.CreateIndex(
                name: "IX_matricula_IdEstudianteFK",
                table: "matricula",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_nota_IdBoletinFK",
                table: "nota",
                column: "IdBoletinFK");

            migrationBuilder.CreateIndex(
                name: "IX_nota_IdEstudianteFK",
                table: "nota",
                column: "IdEstudianteFK");

            migrationBuilder.CreateIndex(
                name: "IX_nota_IdMateriaFK",
                table: "nota",
                column: "IdMateriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_nota_IdProfesorFK",
                table: "nota",
                column: "IdProfesorFK");

            migrationBuilder.CreateIndex(
                name: "IX_profesor_IdColegioFK",
                table: "profesor",
                column: "IdColegioFK");

            migrationBuilder.CreateIndex(
                name: "IX_profesorMateria_IdProfesorFK",
                table: "profesorMateria",
                column: "IdProfesorFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "directivo");

            migrationBuilder.DropTable(
                name: "grupoMateria");

            migrationBuilder.DropTable(
                name: "grupoProfesor");

            migrationBuilder.DropTable(
                name: "matricula");

            migrationBuilder.DropTable(
                name: "nota");

            migrationBuilder.DropTable(
                name: "profesorMateria");

            migrationBuilder.DropTable(
                name: "tipoDirectivo");

            migrationBuilder.DropTable(
                name: "boletin");

            migrationBuilder.DropTable(
                name: "materia");

            migrationBuilder.DropTable(
                name: "profesor");

            migrationBuilder.DropTable(
                name: "estudiante");

            migrationBuilder.DropTable(
                name: "colegio");

            migrationBuilder.DropTable(
                name: "grupo");
        }
    }
}
