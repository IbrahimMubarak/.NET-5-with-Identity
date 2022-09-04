using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity_User.Data.Migrations
{
    public partial class assignadmintoroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUserRoles](UserId,RoleId) SELECT '7bb1d708-e5be-431a-a96b-bc3a983152f7',Id FROM [dbo].[AspNetRoles] ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUserRoles] WHERE UserId='7bb1d708-e5be-431a-a96b-bc3a983152f7'");
        }
    }
}
