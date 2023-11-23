using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recipe.Persistence.Migrations
{
    public partial class CreateRecipeLikesRenameAuthTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "Auth_UserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "Auth_UserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "Auth_UserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "Auth_UserClaims");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Auth_Roles");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "Auth_RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "Auth_UserRoles",
                newName: "IX_Auth_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "Auth_UserLogins",
                newName: "IX_Auth_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "Auth_UserClaims",
                newName: "IX_Auth_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "Auth_RoleClaims",
                newName: "IX_Auth_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_UserTokens",
                table: "Auth_UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_UserRoles",
                table: "Auth_UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_UserLogins",
                table: "Auth_UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_UserClaims",
                table: "Auth_UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_Roles",
                table: "Auth_Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auth_RoleClaims",
                table: "Auth_RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Auth_AppUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecipeEntityId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth_AppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auth_AppUsers_Recipes_RecipeEntityId",
                        column: x => x.RecipeEntityId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeLikes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLikes", x => new { x.RecipeId, x.UserId });
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Auth_AppUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Auth_AppUsers_RecipeEntityId",
                table: "Auth_AppUsers",
                column: "RecipeEntityId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Auth_AppUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_RoleClaims_Auth_Roles_RoleId",
                table: "Auth_RoleClaims",
                column: "RoleId",
                principalTable: "Auth_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_UserClaims_Auth_AppUsers_UserId",
                table: "Auth_UserClaims",
                column: "UserId",
                principalTable: "Auth_AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_UserLogins_Auth_AppUsers_UserId",
                table: "Auth_UserLogins",
                column: "UserId",
                principalTable: "Auth_AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_UserRoles_Auth_AppUsers_UserId",
                table: "Auth_UserRoles",
                column: "UserId",
                principalTable: "Auth_AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_UserRoles_Auth_Roles_RoleId",
                table: "Auth_UserRoles",
                column: "RoleId",
                principalTable: "Auth_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Auth_UserTokens_Auth_AppUsers_UserId",
                table: "Auth_UserTokens",
                column: "UserId",
                principalTable: "Auth_AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Auth_RoleClaims_Auth_Roles_RoleId",
                table: "Auth_RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Auth_UserClaims_Auth_AppUsers_UserId",
                table: "Auth_UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Auth_UserLogins_Auth_AppUsers_UserId",
                table: "Auth_UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_Auth_UserRoles_Auth_AppUsers_UserId",
                table: "Auth_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Auth_UserRoles_Auth_Roles_RoleId",
                table: "Auth_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Auth_UserTokens_Auth_AppUsers_UserId",
                table: "Auth_UserTokens");

            migrationBuilder.DropTable(
                name: "Auth_AppUsers");

            migrationBuilder.DropTable(
                name: "RecipeLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_UserTokens",
                table: "Auth_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_UserRoles",
                table: "Auth_UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_UserLogins",
                table: "Auth_UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_UserClaims",
                table: "Auth_UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_Roles",
                table: "Auth_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Auth_RoleClaims",
                table: "Auth_RoleClaims");

            migrationBuilder.RenameTable(
                name: "Auth_UserTokens",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "Auth_UserRoles",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "Auth_UserLogins",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "Auth_UserClaims",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "Auth_Roles",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Auth_RoleClaims",
                newName: "RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_Auth_UserRoles_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Auth_UserLogins_UserId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Auth_UserClaims_UserId",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Auth_RoleClaims_RoleId",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Users_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Users_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Users_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Users_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
