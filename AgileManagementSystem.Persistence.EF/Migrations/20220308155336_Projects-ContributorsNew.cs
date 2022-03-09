using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileManagementSystem.Persistence.EF.Migrations
{
    public partial class ProjectsContributorsNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributorProject_Contributors_ContributersId",
                table: "ContributorProject");

            migrationBuilder.RenameColumn(
                name: "ContributersId",
                table: "ContributorProject",
                newName: "ContributorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorProject_Contributors_ContributorsId",
                table: "ContributorProject",
                column: "ContributorsId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContributorProject_Contributors_ContributorsId",
                table: "ContributorProject");

            migrationBuilder.RenameColumn(
                name: "ContributorsId",
                table: "ContributorProject",
                newName: "ContributersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContributorProject_Contributors_ContributersId",
                table: "ContributorProject",
                column: "ContributersId",
                principalTable: "Contributors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
