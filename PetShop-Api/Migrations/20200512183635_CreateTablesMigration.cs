using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop_Api.Migrations
{
    public partial class CreateTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalValue",
                table: "Orders",
                newName: "TotalValue");

            migrationBuilder.RenameColumn(
                name: "idPerson",
                table: "Orders",
                newName: "IdPerson");

            migrationBuilder.AlterColumn<double>(
                name: "TotalValue",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserIdPerson",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppointmentsRecords",
                columns: table => new
                {
                    IdAppointmentRecord = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Appointment = table.Column<long>(nullable: false),
                    AppointmentDate = table.Column<DateTime>(nullable: false),
                    IdVet = table.Column<long>(nullable: false),
                    IdPet = table.Column<long>(nullable: false),
                    abstractAppointment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentsRecords", x => x.IdAppointmentRecord);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategory = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "OrdersRecords",
                columns: table => new
                {
                    IdOrderRecord = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrder = table.Column<long>(nullable: false),
                    TotalValue = table.Column<double>(nullable: false),
                    IdUser = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersRecords", x => x.IdOrderRecord);
                });

            migrationBuilder.CreateTable(
                name: "Specialties",
                columns: table => new
                {
                    IdSpecialty = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Specialty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties", x => x.IdSpecialty);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    IdSpecie = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Specie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.IdSpecie);
                });

            migrationBuilder.CreateTable(
                name: "StatesProducts",
                columns: table => new
                {
                    IdStateProduct = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatesProducts", x => x.IdStateProduct);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdPerson = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DocumentId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    IdProduct = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CategoryIdCategory = table.Column<long>(nullable: true),
                    QuantityAvailable = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    StateProductIdStateProduct = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryIdCategory",
                        column: x => x.CategoryIdCategory,
                        principalTable: "Categories",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_StatesProducts_StateProductIdStateProduct",
                        column: x => x.StateProductIdStateProduct,
                        principalTable: "StatesProducts",
                        principalColumn: "IdStateProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdPet = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SpecieIdSpecie = table.Column<long>(nullable: true),
                    GeneralInfo = table.Column<string>(nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    UserIdPerson = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pets_Species_SpecieIdSpecie",
                        column: x => x.SpecieIdSpecie,
                        principalTable: "Species",
                        principalColumn: "IdSpecie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserIdPerson",
                        column: x => x.UserIdPerson,
                        principalTable: "Users",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veterinarians",
                columns: table => new
                {
                    IdVeterinarian = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserIdPerson = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarians", x => x.IdVeterinarian);
                    table.ForeignKey(
                        name: "FK_Veterinarians_Users_UserIdPerson",
                        column: x => x.UserIdPerson,
                        principalTable: "Users",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    IdWishList = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserIdPerson = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.IdWishList);
                    table.ForeignKey(
                        name: "FK_WishLists_Users_UserIdPerson",
                        column: x => x.UserIdPerson,
                        principalTable: "Users",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders_Products",
                columns: table => new
                {
                    IdOrder_Products = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrder = table.Column<long>(nullable: false),
                    ProductIdProduct = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_Products", x => x.IdOrder_Products);
                    table.ForeignKey(
                        name: "FK_Orders_Products_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    IdAppointment = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    VeterinarianIdVeterinarian = table.Column<long>(nullable: true),
                    PetIdPet = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.IdAppointment);
                    table.ForeignKey(
                        name: "FK_Appointments_Pets_PetIdPet",
                        column: x => x.PetIdPet,
                        principalTable: "Pets",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Veterinarians_VeterinarianIdVeterinarian",
                        column: x => x.VeterinarianIdVeterinarian,
                        principalTable: "Veterinarians",
                        principalColumn: "IdVeterinarian",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Specialties_Vets",
                columns: table => new
                {
                    IdSpecialties_Vets = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeterinarianIdVeterinarian = table.Column<long>(nullable: true),
                    SpecialtyIdSpecialty = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialties_Vets", x => x.IdSpecialties_Vets);
                    table.ForeignKey(
                        name: "FK_Specialties_Vets_Specialties_SpecialtyIdSpecialty",
                        column: x => x.SpecialtyIdSpecialty,
                        principalTable: "Specialties",
                        principalColumn: "IdSpecialty",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Specialties_Vets_Veterinarians_VeterinarianIdVeterinarian",
                        column: x => x.VeterinarianIdVeterinarian,
                        principalTable: "Veterinarians",
                        principalColumn: "IdVeterinarian",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WishLists_Products",
                columns: table => new
                {
                    IdWishList_Products = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WishListIdWishList = table.Column<long>(nullable: true),
                    ProductIdProduct = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists_Products", x => x.IdWishList_Products);
                    table.ForeignKey(
                        name: "FK_WishLists_Products_Products_ProductIdProduct",
                        column: x => x.ProductIdProduct,
                        principalTable: "Products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WishLists_Products_WishLists_WishListIdWishList",
                        column: x => x.WishListIdWishList,
                        principalTable: "WishLists",
                        principalColumn: "IdWishList",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdPerson",
                table: "Orders",
                column: "UserIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PetIdPet",
                table: "Appointments",
                column: "PetIdPet");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VeterinarianIdVeterinarian",
                table: "Appointments",
                column: "VeterinarianIdVeterinarian");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Products_ProductIdProduct",
                table: "Orders_Products",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_SpecieIdSpecie",
                table: "Pets",
                column: "SpecieIdSpecie");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserIdPerson",
                table: "Pets",
                column: "UserIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryIdCategory",
                table: "Products",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StateProductIdStateProduct",
                table: "Products",
                column: "StateProductIdStateProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_Vets_SpecialtyIdSpecialty",
                table: "Specialties_Vets",
                column: "SpecialtyIdSpecialty");

            migrationBuilder.CreateIndex(
                name: "IX_Specialties_Vets_VeterinarianIdVeterinarian",
                table: "Specialties_Vets",
                column: "VeterinarianIdVeterinarian");

            migrationBuilder.CreateIndex(
                name: "IX_Veterinarians_UserIdPerson",
                table: "Veterinarians",
                column: "UserIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserIdPerson",
                table: "WishLists",
                column: "UserIdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_Products_ProductIdProduct",
                table: "WishLists_Products",
                column: "ProductIdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_Products_WishListIdWishList",
                table: "WishLists_Products",
                column: "WishListIdWishList");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserIdPerson",
                table: "Orders",
                column: "UserIdPerson",
                principalTable: "Users",
                principalColumn: "IdPerson",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserIdPerson",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AppointmentsRecords");

            migrationBuilder.DropTable(
                name: "Orders_Products");

            migrationBuilder.DropTable(
                name: "OrdersRecords");

            migrationBuilder.DropTable(
                name: "Specialties_Vets");

            migrationBuilder.DropTable(
                name: "WishLists_Products");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Specialties");

            migrationBuilder.DropTable(
                name: "Veterinarians");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "StatesProducts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserIdPerson",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserIdPerson",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalValue",
                table: "Orders",
                newName: "totalValue");

            migrationBuilder.RenameColumn(
                name: "IdPerson",
                table: "Orders",
                newName: "idPerson");

            migrationBuilder.AlterColumn<string>(
                name: "totalValue",
                table: "Orders",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(double));
        }
    }
}
