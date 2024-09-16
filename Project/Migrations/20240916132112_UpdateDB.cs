using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student");

            //migrationBuilder.DropPrimaryKey(        сначала дропает дурной зачемто
            //    name: "PK_groups",
            //    table: "groups");

            migrationBuilder.RenameTable(
                name: "groups",
                newName: "cd_group");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "cd_student",
                newName: "c_student_middlename");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "cd_student",
                newName: "f_group_id");

            migrationBuilder.RenameIndex(
                name: "IX_cd_student_GroupId",
                table: "cd_student",
                newName: "idx_cd_student_fk_f_group_id");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "cd_group",
                newName: "c_group_name");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "cd_group",
                newName: "group_id");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_lastname",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Фамилия студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Фамилия Студента");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_firstname",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Имя студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Имя Студента");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_middlename",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: true,
                comment: "Отчество студента",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "f_group_id",
                table: "cd_student",
                type: "int4",
                nullable: false,
                comment: "Идентификатор группы",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "c_group_name",
                table: "cd_group",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Название группы",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "group_id",
                table: "cd_group",
                type: "integer",
                nullable: false,
                comment: "Идентификатор записи группы",
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            //migrationBuilder.AddPrimaryKey(   //потом добаляет, зачем он это делает?
            //    name: "pk_cd_group_group_id",
            //    table: "cd_group",
            //    column: "group_id");

            migrationBuilder.CreateTable(
                name: "cd_discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discipline_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "DisciplineGroup",
                columns: table => new
                {
                    DisciplinesDisciplineId = table.Column<int>(type: "integer", nullable: false),
                    GroupsGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineGroup", x => new { x.DisciplinesDisciplineId, x.GroupsGroupId });
                    table.ForeignKey(
                        name: "FK_DisciplineGroup_cd_discipline_DisciplinesDisciplineId",
                        column: x => x.DisciplinesDisciplineId,
                        principalTable: "cd_discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineGroup_cd_group_GroupsGroupId",
                        column: x => x.GroupsGroupId,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineGroup_GroupsGroupId",
                table: "DisciplineGroup",
                column: "GroupsGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplineGroup");

            migrationBuilder.DropTable(
                name: "cd_discipline");

            migrationBuilder.DropPrimaryKey(
                name: "pk_cd_group_group_id",
                table: "cd_group");

            migrationBuilder.RenameTable(
                name: "cd_group",
                newName: "groups");

            migrationBuilder.RenameColumn(
                name: "f_group_id",
                table: "cd_student",
                newName: "GroupId");

            migrationBuilder.RenameColumn(
                name: "c_student_middlename",
                table: "cd_student",
                newName: "MiddleName");

            migrationBuilder.RenameIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                newName: "IX_cd_student_GroupId");

            migrationBuilder.RenameColumn(
                name: "c_group_name",
                table: "groups",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "group_id",
                table: "groups",
                newName: "GroupId");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_lastname",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Фамилия Студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Фамилия студента");

            migrationBuilder.AlterColumn<string>(
                name: "c_student_firstname",
                table: "cd_student",
                type: "varchar",
                maxLength: 100,
                nullable: false,
                comment: "Имя Студента",
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Имя студента");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "cd_student",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Идентификатор группы");

            migrationBuilder.AlterColumn<string>(
                name: "MiddleName",
                table: "cd_student",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldNullable: true,
                oldComment: "Отчество студента");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "groups",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 100,
                oldComment: "Название группы");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "groups",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Идентификатор записи группы")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_groups",
                table: "groups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "student_id");
        }
    }
}
