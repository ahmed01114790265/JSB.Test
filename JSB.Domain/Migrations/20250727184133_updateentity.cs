using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSB.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updateentity : Migration
    {
        /// <inheritdoc />

        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.Sql("ALTER TABLE Categories DROP CONSTRAINT CK_Categories_Name_NotEmpty");
            migrationBuilder.Sql("ALTER TABLE Categories DROP CONSTRAINT CK_Categories_Description_NotEmpty");

           
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            
            migrationBuilder.Sql("ALTER TABLE Categories ADD CONSTRAINT CK_Categories_Name_NotEmpty CHECK ([Name] <> '')");
            migrationBuilder.Sql("ALTER TABLE Categories ADD CONSTRAINT CK_Categories_Description_NotEmpty CHECK ([Description] <> '')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
            {
               
                migrationBuilder.Sql("ALTER TABLE Categories DROP CONSTRAINT CK_Categories_Name_NotEmpty");

                migrationBuilder.AlterColumn<string>(
                    name: "Name",
                    table: "Categories",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(50)",
                    oldMaxLength: 50);

                migrationBuilder.AlterColumn<string>(
                    name: "Description",
                    table: "Categories",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(400)",
                    oldMaxLength: 400);

                migrationBuilder.AlterColumn<string>(
                    name: "Name",
                    table: "Books",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(50)",
                    oldMaxLength: 50);

                migrationBuilder.AlterColumn<string>(
                    name: "Description",
                    table: "Books",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(300)",
                    oldMaxLength: 300);

                migrationBuilder.AlterColumn<string>(
                    name: "Author",
                    table: "Books",
                    type: "nvarchar(max)",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "nvarchar(50)",
                    oldMaxLength: 50);
            }
        }
    }

