using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MRMS.DAL.Migrations
{
    public partial class MRMS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RL = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Accountant = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.AgencyId);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.DesignationId);
                });

            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    FileTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.FileTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCenters",
                columns: table => new
                {
                    MedicalCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCenters", x => x.MedicalCenterId);
                });

            migrationBuilder.CreateTable(
                name: "TrainingCentres",
                columns: table => new
                {
                    TrainingCentreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingCentres", x => x.TrainingCentreId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AgencySyndicates",
                columns: table => new
                {
                    AgencySyndicateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencySyndicates", x => x.AgencySyndicateId);
                    table.ForeignKey(
                        name: "FK_AgencySyndicates_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MothersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Spouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateOfBrith = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthCertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "DesignationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Demands",
                columns: table => new
                {
                    DemandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DemandExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demands", x => x.DemandId);
                    table.ForeignKey(
                        name: "FK_Demands_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeFiles",
                columns: table => new
                {
                    EmployeeFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFiles", x => x.EmployeeFileId);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandFiles",
                columns: table => new
                {
                    DemandFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandFiles", x => x.DemandFileId);
                    table.ForeignKey(
                        name: "FK_DemandFiles_Demands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "Demands",
                        principalColumn: "DemandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DemandFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandIssues",
                columns: table => new
                {
                    DemandIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandIssues", x => x.DemandIssueId);
                    table.ForeignKey(
                        name: "FK_DemandIssues_Demands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "Demands",
                        principalColumn: "DemandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    TradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    MaleQuota = table.Column<int>(type: "int", nullable: false),
                    FemaleQuota = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    OverTime = table.Column<int>(type: "int", nullable: false),
                    Food = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Accomodation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContractPeriod = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DemandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.TradeId);
                    table.ForeignKey(
                        name: "FK_Trades_Demands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "Demands",
                        principalColumn: "DemandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DemandIssueComment",
                columns: table => new
                {
                    DemandIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandIssueComment", x => x.DemandIssueCommentId);
                    table.ForeignKey(
                        name: "FK_DemandIssueComment_DemandIssues_DemandIssueId",
                        column: x => x.DemandIssueId,
                        principalTable: "DemandIssues",
                        principalColumn: "DemandIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantFiles",
                columns: table => new
                {
                    ApplicantFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantFiles", x => x.ApplicantFileId);
                    table.ForeignKey(
                        name: "FK_ApplicantFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantIssueComment",
                columns: table => new
                {
                    ApplicantIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantIssueComment", x => x.ApplicantIssueCommentId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicantIssues",
                columns: table => new
                {
                    ApplicantIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantIssues", x => x.ApplicantIssueId);
                });

            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasssportNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportExpiry = table.Column<DateTime>(type: "date", nullable: false),
                    Height = table.Column<double>(type: "FLOAT", nullable: false),
                    Weight = table.Column<double>(type: "FLOAT", nullable: false),
                    JobExperience = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FathersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MothersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Spouse = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateOfBrith = table.Column<DateTime>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthCertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Religion = table.Column<int>(type: "int", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicants_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Applications_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "TradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Callings",
                columns: table => new
                {
                    CallingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    TradeId = table.Column<int>(type: "int", nullable: false),
                    CallingStatus = table.Column<int>(type: "int", nullable: false),
                    CallingGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallingIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Callings", x => x.CallingId);
                    table.ForeignKey(
                        name: "FK_Callings_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Callings_Trades_TradeId",
                        column: x => x.TradeId,
                        principalTable: "Trades",
                        principalColumn: "TradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forwardings",
                columns: table => new
                {
                    ForwardingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forwardings", x => x.ForwardingId);
                    table.ForeignKey(
                        name: "FK_Forwardings_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DemandId = table.Column<int>(type: "int", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    MedicalCenterId = table.Column<int>(type: "int", nullable: false),
                    AgencySyndicateId = table.Column<int>(type: "int", nullable: false),
                    MedicalStatus = table.Column<int>(type: "int", nullable: false),
                    SlipIssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    MedicalDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedicalRecordId);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_AgencySyndicates_AgencySyndicateId",
                        column: x => x.AgencySyndicateId,
                        principalTable: "AgencySyndicates",
                        principalColumn: "AgencySyndicateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Demands_DemandId",
                        column: x => x.DemandId,
                        principalTable: "Demands",
                        principalColumn: "DemandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_MedicalCenters_MedicalCenterId",
                        column: x => x.MedicalCenterId,
                        principalTable: "MedicalCenters",
                        principalColumn: "MedicalCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RejectedApplicants",
                columns: table => new
                {
                    RejectedApplicantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    RejectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejectedApplicants", x => x.RejectedApplicantId);
                    table.ForeignKey(
                        name: "FK_RejectedApplicants_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visas",
                columns: table => new
                {
                    VisaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visas", x => x.VisaId);
                    table.ForeignKey(
                        name: "FK_Visas_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "ApplicantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFiles",
                columns: table => new
                {
                    ApplicationFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFiles", x => x.ApplicationFileId);
                    table.ForeignKey(
                        name: "FK_ApplicationFiles_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationFileTransfers",
                columns: table => new
                {
                    ApplicationFileTransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "date", nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationFileTransfers", x => x.ApplicationFileTransferId);
                    table.ForeignKey(
                        name: "FK_ApplicationFileTransfers_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationFileTransfers_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationIssues",
                columns: table => new
                {
                    ApplicationIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationIssues", x => x.ApplicationIssueId);
                    table.ForeignKey(
                        name: "FK_ApplicationIssues_Applications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Applications",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallingFiles",
                columns: table => new
                {
                    CallingFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallingId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallingFiles", x => x.CallingFileId);
                    table.ForeignKey(
                        name: "FK_CallingFiles_Callings_CallingId",
                        column: x => x.CallingId,
                        principalTable: "Callings",
                        principalColumn: "CallingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallingFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallingIssues",
                columns: table => new
                {
                    CallingIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallingId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallingIssues", x => x.CallingIssueId);
                    table.ForeignKey(
                        name: "FK_CallingIssues_Callings_CallingId",
                        column: x => x.CallingId,
                        principalTable: "Callings",
                        principalColumn: "CallingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BMETs",
                columns: table => new
                {
                    BMETId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BMETs", x => x.BMETId);
                    table.ForeignKey(
                        name: "FK_BMETs_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FingerPrints",
                columns: table => new
                {
                    FingerPrintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    FingerPrintStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FingerPrints", x => x.FingerPrintId);
                    table.ForeignKey(
                        name: "FK_FingerPrints_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForwardingFiles",
                columns: table => new
                {
                    ForwardingFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwardingFiles", x => x.ForwardingFileId);
                    table.ForeignKey(
                        name: "FK_ForwardingFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForwardingFiles_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForwardingFileTransfers",
                columns: table => new
                {
                    ForwardingFileTransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "date", nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwardingFileTransfers", x => x.ForwardingFileTransferId);
                    table.ForeignKey(
                        name: "FK_ForwardingFileTransfers_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ForwardingFileTransfers_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForwardingIssues",
                columns: table => new
                {
                    ForwardingIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwardingIssues", x => x.ForwardingIssueId);
                    table.ForeignKey(
                        name: "FK_ForwardingIssues_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrainingCentreId = table.Column<int>(type: "int", nullable: false),
                    ForwardingId = table.Column<int>(type: "int", nullable: false),
                    TrainingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrainingStatus = table.Column<int>(type: "int", nullable: false),
                    TrainingDuration = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_Trainings_Forwardings_ForwardingId",
                        column: x => x.ForwardingId,
                        principalTable: "Forwardings",
                        principalColumn: "ForwardingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_TrainingCentres_TrainingCentreId",
                        column: x => x.TrainingCentreId,
                        principalTable: "TrainingCentres",
                        principalColumn: "TrainingCentreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalFiles",
                columns: table => new
                {
                    MedicalFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalFiles", x => x.MedicalFileId);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalFiles_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalIssues",
                columns: table => new
                {
                    MedicalIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalIssues", x => x.MedicalIssueId);
                    table.ForeignKey(
                        name: "FK_MedicalIssues_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedicalRecordId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaId = table.Column<int>(type: "int", nullable: false),
                    AirlinesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeparturePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArrivalPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flights_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisaFiles",
                columns: table => new
                {
                    VisaFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaFiles", x => x.VisaFileId);
                    table.ForeignKey(
                        name: "FK_VisaFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisaFiles_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisaFileTransfers",
                columns: table => new
                {
                    VisaFileTransferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "date", nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaFileTransfers", x => x.VisaFileTransferId);
                    table.ForeignKey(
                        name: "FK_VisaFileTransfers_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisaFileTransfers_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisaIssues",
                columns: table => new
                {
                    VisaIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaIssues", x => x.VisaIssueId);
                    table.ForeignKey(
                        name: "FK_VisaIssues_Visas_VisaId",
                        column: x => x.VisaId,
                        principalTable: "Visas",
                        principalColumn: "VisaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationIssueComment",
                columns: table => new
                {
                    ApplicationIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationIssueComment", x => x.ApplicationIssueCommentId);
                    table.ForeignKey(
                        name: "FK_ApplicationIssueComment_ApplicationIssues_ApplicationIssueId",
                        column: x => x.ApplicationIssueId,
                        principalTable: "ApplicationIssues",
                        principalColumn: "ApplicationIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallingIssueComment",
                columns: table => new
                {
                    CallingIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CallingIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallingIssueComment", x => x.CallingIssueCommentId);
                    table.ForeignKey(
                        name: "FK_CallingIssueComment_CallingIssues_CallingIssueId",
                        column: x => x.CallingIssueId,
                        principalTable: "CallingIssues",
                        principalColumn: "CallingIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForwardingIssueComment",
                columns: table => new
                {
                    ForwardingIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ForwardingIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForwardingIssueComment", x => x.ForwardingIssueCommentId);
                    table.ForeignKey(
                        name: "FK_ForwardingIssueComment_ForwardingIssues_ForwardingIssueId",
                        column: x => x.ForwardingIssueId,
                        principalTable: "ForwardingIssues",
                        principalColumn: "ForwardingIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalIssueComment",
                columns: table => new
                {
                    MedicalIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalIssueComment", x => x.MedicalIssueCommentId);
                    table.ForeignKey(
                        name: "FK_MedicalIssueComment_MedicalIssues_MedicalIssueId",
                        column: x => x.MedicalIssueId,
                        principalTable: "MedicalIssues",
                        principalColumn: "MedicalIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightFiles",
                columns: table => new
                {
                    FlightFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightFiles", x => x.FlightFileId);
                    table.ForeignKey(
                        name: "FK_FlightFiles_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "FileTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightFiles_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightIssues",
                columns: table => new
                {
                    FlightIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "date", nullable: false),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightIssues", x => x.FlightIssueId);
                    table.ForeignKey(
                        name: "FK_FlightIssues_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisaIssueComment",
                columns: table => new
                {
                    VisaIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisaIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisaIssueComment", x => x.VisaIssueCommentId);
                    table.ForeignKey(
                        name: "FK_VisaIssueComment_VisaIssues_VisaIssueId",
                        column: x => x.VisaIssueId,
                        principalTable: "VisaIssues",
                        principalColumn: "VisaIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightIssueComment",
                columns: table => new
                {
                    FlightIssueCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightIssueId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightIssueComment", x => x.FlightIssueCommentId);
                    table.ForeignKey(
                        name: "FK_FlightIssueComment_FlightIssues_FlightIssueId",
                        column: x => x.FlightIssueId,
                        principalTable: "FlightIssues",
                        principalColumn: "FlightIssueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgencySyndicates_AgencyId",
                table: "AgencySyndicates",
                column: "AgencyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_ApplicantId",
                table: "ApplicantFiles",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantFiles_FileTypeId",
                table: "ApplicantFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssueComment_ApplicantIssueId",
                table: "ApplicantIssueComment",
                column: "ApplicantIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantIssues_ApplicantId",
                table: "ApplicantIssues",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_AgentId",
                table: "Applicants",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_TrainingId",
                table: "Applicants",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_ApplicationId",
                table: "ApplicationFiles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFiles_FileTypeId",
                table: "ApplicationFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileTransfers_ApplicationId",
                table: "ApplicationFileTransfers",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationFileTransfers_FileTypeId",
                table: "ApplicationFileTransfers",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationIssueComment_ApplicationIssueId",
                table: "ApplicationIssueComment",
                column: "ApplicationIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationIssues_ApplicationId",
                table: "ApplicationIssues",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AgencyId",
                table: "Applications",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_TradeId",
                table: "Applications",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_BMETs_ForwardingId",
                table: "BMETs",
                column: "ForwardingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CallingFiles_CallingId",
                table: "CallingFiles",
                column: "CallingId");

            migrationBuilder.CreateIndex(
                name: "IX_CallingFiles_FileTypeId",
                table: "CallingFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CallingIssueComment_CallingIssueId",
                table: "CallingIssueComment",
                column: "CallingIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_CallingIssues_CallingId",
                table: "CallingIssues",
                column: "CallingId");

            migrationBuilder.CreateIndex(
                name: "IX_Callings_ApplicantId",
                table: "Callings",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Callings_TradeId",
                table: "Callings",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CountryId",
                table: "Companies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandFiles_DemandId",
                table: "DemandFiles",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandFiles_FileTypeId",
                table: "DemandFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandIssueComment_DemandIssueId",
                table: "DemandIssueComment",
                column: "DemandIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_DemandIssues_DemandId",
                table: "DemandIssues",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_Demands_CompanyId",
                table: "Demands",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_EmployeeId",
                table: "EmployeeFiles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFiles_FileTypeId",
                table: "EmployeeFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_FingerPrints_ForwardingId",
                table: "FingerPrints",
                column: "ForwardingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightFiles_FileTypeId",
                table: "FlightFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightFiles_FlightId",
                table: "FlightFiles",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightIssueComment_FlightIssueId",
                table: "FlightIssueComment",
                column: "FlightIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightIssues_FlightId",
                table: "FlightIssues",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_VisaId",
                table: "Flights",
                column: "VisaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingFiles_FileTypeId",
                table: "ForwardingFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingFiles_ForwardingId",
                table: "ForwardingFiles",
                column: "ForwardingId");

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingFileTransfers_FileTypeId",
                table: "ForwardingFileTransfers",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingFileTransfers_ForwardingId",
                table: "ForwardingFileTransfers",
                column: "ForwardingId");

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingIssueComment_ForwardingIssueId",
                table: "ForwardingIssueComment",
                column: "ForwardingIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ForwardingIssues_ForwardingId",
                table: "ForwardingIssues",
                column: "ForwardingId");

            migrationBuilder.CreateIndex(
                name: "IX_Forwardings_ApplicantId",
                table: "Forwardings",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_FileTypeId",
                table: "MedicalFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalFiles_MedicalRecordId",
                table: "MedicalFiles",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalIssueComment_MedicalIssueId",
                table: "MedicalIssueComment",
                column: "MedicalIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalIssues_MedicalRecordId",
                table: "MedicalIssues",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AgencySyndicateId",
                table: "MedicalRecords",
                column: "AgencySyndicateId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ApplicantId",
                table: "MedicalRecords",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_DemandId",
                table: "MedicalRecords",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_MedicalCenterId",
                table: "MedicalRecords",
                column: "MedicalCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_RejectedApplicants_ApplicantId",
                table: "RejectedApplicants",
                column: "ApplicantId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trades_DemandId",
                table: "Trades",
                column: "DemandId");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ForwardingId",
                table: "Trainings",
                column: "ForwardingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingCentreId",
                table: "Trainings",
                column: "TrainingCentreId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaFiles_FileTypeId",
                table: "VisaFiles",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaFiles_VisaId",
                table: "VisaFiles",
                column: "VisaId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaFileTransfers_FileTypeId",
                table: "VisaFileTransfers",
                column: "FileTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaFileTransfers_VisaId",
                table: "VisaFileTransfers",
                column: "VisaId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaIssueComment_VisaIssueId",
                table: "VisaIssueComment",
                column: "VisaIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_VisaIssues_VisaId",
                table: "VisaIssues",
                column: "VisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Visas_ApplicantId",
                table: "Visas",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantFiles_Applicants_ApplicantId",
                table: "ApplicantFiles",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantIssueComment_ApplicantIssues_ApplicantIssueId",
                table: "ApplicantIssueComment",
                column: "ApplicantIssueId",
                principalTable: "ApplicantIssues",
                principalColumn: "ApplicantIssueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantIssues_Applicants_ApplicantId",
                table: "ApplicantIssues",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Trainings_TrainingId",
                table: "Applicants",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "TrainingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forwardings_Applicants_ApplicantId",
                table: "Forwardings");

            migrationBuilder.DropTable(
                name: "ApplicantFiles");

            migrationBuilder.DropTable(
                name: "ApplicantIssueComment");

            migrationBuilder.DropTable(
                name: "ApplicationFiles");

            migrationBuilder.DropTable(
                name: "ApplicationFileTransfers");

            migrationBuilder.DropTable(
                name: "ApplicationIssueComment");

            migrationBuilder.DropTable(
                name: "BMETs");

            migrationBuilder.DropTable(
                name: "CallingFiles");

            migrationBuilder.DropTable(
                name: "CallingIssueComment");

            migrationBuilder.DropTable(
                name: "DemandFiles");

            migrationBuilder.DropTable(
                name: "DemandIssueComment");

            migrationBuilder.DropTable(
                name: "EmployeeFiles");

            migrationBuilder.DropTable(
                name: "FingerPrints");

            migrationBuilder.DropTable(
                name: "FlightFiles");

            migrationBuilder.DropTable(
                name: "FlightIssueComment");

            migrationBuilder.DropTable(
                name: "ForwardingFiles");

            migrationBuilder.DropTable(
                name: "ForwardingFileTransfers");

            migrationBuilder.DropTable(
                name: "ForwardingIssueComment");

            migrationBuilder.DropTable(
                name: "MedicalFiles");

            migrationBuilder.DropTable(
                name: "MedicalIssueComment");

            migrationBuilder.DropTable(
                name: "RejectedApplicants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VisaFiles");

            migrationBuilder.DropTable(
                name: "VisaFileTransfers");

            migrationBuilder.DropTable(
                name: "VisaIssueComment");

            migrationBuilder.DropTable(
                name: "ApplicantIssues");

            migrationBuilder.DropTable(
                name: "ApplicationIssues");

            migrationBuilder.DropTable(
                name: "CallingIssues");

            migrationBuilder.DropTable(
                name: "DemandIssues");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "FlightIssues");

            migrationBuilder.DropTable(
                name: "ForwardingIssues");

            migrationBuilder.DropTable(
                name: "MedicalIssues");

            migrationBuilder.DropTable(
                name: "FileType");

            migrationBuilder.DropTable(
                name: "VisaIssues");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Callings");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "Visas");

            migrationBuilder.DropTable(
                name: "AgencySyndicates");

            migrationBuilder.DropTable(
                name: "MedicalCenters");

            migrationBuilder.DropTable(
                name: "Demands");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Forwardings");

            migrationBuilder.DropTable(
                name: "TrainingCentres");
        }
    }
}
