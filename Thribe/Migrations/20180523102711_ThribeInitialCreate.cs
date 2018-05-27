using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Thribe.Migrations
{
    public partial class ThribeInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Option_A = table.Column<string>(nullable: true),
                    Option_B = table.Column<string>(nullable: true),
                    Option_C = table.Column<string>(nullable: true),
                    Option_D = table.Column<string>(nullable: true),
                    Option_E = table.Column<string>(nullable: true),
                    QuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                });

            migrationBuilder.CreateTable(
                name: "AppMessages",
                columns: table => new
                {
                    MessageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMessages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "MyJobs",
                columns: table => new
                {
                    JobId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Details = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyJobs", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    JobId = table.Column<long>(nullable: false),
                    MultipleItems = table.Column<bool>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    OrderTime = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<long>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: true),
                    ServiceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Processings",
                columns: table => new
                {
                    ProcessingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Detail = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: false),
                    Process = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processings", x => x.ProcessingId);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Code = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<string>(nullable: true),
                    Percent = table.Column<decimal>(nullable: false),
                    PromoNumber = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    AssociatedPrice = table.Column<string>(nullable: true),
                    Options = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    QuestionIconUrl = table.Column<string>(nullable: true),
                    QuestionNaireId = table.Column<long>(nullable: false),
                    QuestionOptionCode = table.Column<string>(nullable: true),
                    QuestionOptionIconUrl = table.Column<string>(nullable: true),
                    QuestionOptionId = table.Column<long>(nullable: false),
                    QuestionOptionName = table.Column<string>(nullable: true),
                    QuestionOptionSortOrder = table.Column<long>(nullable: false),
                    QuestionOptionTypeId = table.Column<long>(nullable: false),
                    QuestionOptionTypeName = table.Column<string>(nullable: true),
                    QuestionOptionUrl = table.Column<string>(nullable: true),
                    QuestionTypeId = table.Column<long>(nullable: false),
                    QuestionTypeName = table.Column<string>(nullable: true),
                    ServiceItemId = table.Column<long>(nullable: false),
                    ServiceQuestionId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "SelectedSkills",
                columns: table => new
                {
                    SelectedSkillId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    MySkill1 = table.Column<string>(nullable: true),
                    MySkill10 = table.Column<string>(nullable: true),
                    MySkill2 = table.Column<string>(nullable: true),
                    MySkill3 = table.Column<string>(nullable: true),
                    MySkill4 = table.Column<string>(nullable: true),
                    MySkill5 = table.Column<string>(nullable: true),
                    MySkill6 = table.Column<string>(nullable: true),
                    MySkill7 = table.Column<string>(nullable: true),
                    MySkill8 = table.Column<string>(nullable: true),
                    MySkill9 = table.Column<string>(nullable: true),
                    OtherSkill = table.Column<string>(nullable: true),
                    SkillId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedSkills", x => x.SelectedSkillId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Charge = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Items = table.Column<string>(nullable: true),
                    MutipleItems = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Service = table.Column<string>(nullable: true),
                    ServiceId = table.Column<long>(nullable: false),
                    ServiceType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    MySkill = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Supports",
                columns: table => new
                {
                    SupportId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supports", x => x.SupportId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSelections",
                columns: table => new
                {
                    UserSelectionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    QuestionId = table.Column<long>(nullable: false),
                    ServiceQuestion = table.Column<string>(nullable: true),
                    UserAnswer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSelections", x => x.UserSelectionId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    JobId1 = table.Column<long>(nullable: true),
                    VendorLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_MyJobs_JobId1",
                        column: x => x.JobId1,
                        principalTable: "MyJobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressId = table.Column<int>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressType = table.Column<string>(nullable: true),
                    AddressTypeId = table.Column<long>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(nullable: true),
                    Longitude = table.Column<decimal>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    UserIdId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAddresses_Users_UserIdId",
                        column: x => x.UserIdId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_JobId1",
                table: "Locations",
                column: "JobId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddresses_UserIdId",
                table: "UserAddresses",
                column: "UserIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AppMessages");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Processings");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "SelectedSkills");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Supports");

            migrationBuilder.DropTable(
                name: "UserAddresses");

            migrationBuilder.DropTable(
                name: "UserSelections");

            migrationBuilder.DropTable(
                name: "MyJobs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
