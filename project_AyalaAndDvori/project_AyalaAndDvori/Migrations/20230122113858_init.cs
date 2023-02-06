using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    groupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    numStudents = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_group", x => x.groupId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentIDNumber = table.Column<int>(type: "int", nullable: true),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "nchar(11)", fixedLength: true, maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    TrackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameTrack = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.TrackId);
                });

            migrationBuilder.CreateTable(
                name: "Coureses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trackId = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    numHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_Coureses_Tracks1",
                        column: x => x.trackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId");
                });

            migrationBuilder.CreateTable(
                name: "GroupOfCourse",
                columns: table => new
                {
                    groupOfCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseId = table.Column<int>(type: "int", nullable: true),
                    groupId = table.Column<int>(type: "int", nullable: true),
                    numActualHours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupOfCourse", x => x.groupOfCourseId);
                    table.ForeignKey(
                        name: "FK_GroupOfCourse_Coureses",
                        column: x => x.courseId,
                        principalTable: "Coureses",
                        principalColumn: "courseId");
                    table.ForeignKey(
                        name: "FK_GroupOfCourse_Group",
                        column: x => x.groupId,
                        principalTable: "Group",
                        principalColumn: "groupId");
                });

            migrationBuilder.CreateTable(
                name: "StudentInGroupOfCourse",
                columns: table => new
                {
                    studentInGroupOfCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(type: "int", nullable: true),
                    groupOfCourseId = table.Column<int>(type: "int", nullable: true),
                    numAbsence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInGroupOfCourse", x => x.studentInGroupOfCourseId);
                    table.ForeignKey(
                        name: "FK_StudentInGroupOfCourse_GroupOfCourse",
                        column: x => x.groupOfCourseId,
                        principalTable: "GroupOfCourse",
                        principalColumn: "groupOfCourseId");
                    table.ForeignKey(
                        name: "FK_StudentInGroupOfCourse_Students",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coureses_trackId",
                table: "Coureses",
                column: "trackId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfCourse_courseId",
                table: "GroupOfCourse",
                column: "courseId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupOfCourse_groupId",
                table: "GroupOfCourse",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInGroupOfCourse_groupOfCourseId",
                table: "StudentInGroupOfCourse",
                column: "groupOfCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInGroupOfCourse_studentId",
                table: "StudentInGroupOfCourse",
                column: "studentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentInGroupOfCourse");

            migrationBuilder.DropTable(
                name: "GroupOfCourse");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Coureses");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Tracks");
        }
    }
}
