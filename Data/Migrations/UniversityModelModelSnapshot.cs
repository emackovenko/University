﻿// <auto-generated />
using Data.University;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Data.Migrations
{
    [DbContext(typeof(UniversityModel))]
    partial class UniversityModelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Data.University.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apartment");

                    b.Property<string>("Bulding");

                    b.Property<int?>("CountryId");

                    b.Property<int?>("DisctrictId");

                    b.Property<int?>("DistrictId");

                    b.Property<int?>("LocalityId");

                    b.Property<int?>("RegionId");

                    b.Property<int?>("StreetId");

                    b.Property<int?>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("DistrictId");

                    b.HasIndex("LocalityId");

                    b.HasIndex("RegionId");

                    b.HasIndex("StreetId");

                    b.HasIndex("TownId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Data.University.Cathedra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Cathedras");
                });

            modelBuilder.Entity("Data.University.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Citizenships");
                });

            modelBuilder.Entity("Data.University.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Commands");
                });

            modelBuilder.Entity("Data.University.CommandPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CommandId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("CommandId");

                    b.HasIndex("RoleId");

                    b.ToTable("CommandPermissions");
                });

            modelBuilder.Entity("Data.University.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Data.University.Direction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("EducationLevelId");

                    b.Property<int?>("EducationProgramTypeId");

                    b.Property<int?>("EducationStandartTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("EducationProgramTypeId");

                    b.HasIndex("EducationStandartTypeId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("Data.University.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Data.University.DisciplineCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("DisciplineCycles");
                });

            modelBuilder.Entity("Data.University.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<int?>("RegionId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Data.University.EducationCompetence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationCompetences");
                });

            modelBuilder.Entity("Data.University.EducationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationForms");
                });

            modelBuilder.Entity("Data.University.EducationLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationLevels");
                });

            modelBuilder.Entity("Data.University.EducationPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("BeginDate");

                    b.Property<int?>("CathedraId");

                    b.Property<int?>("DirectionId");

                    b.Property<int?>("EducationFormId");

                    b.Property<int?>("EducationProgramTypeId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name");

                    b.Property<int?>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CathedraId");

                    b.HasIndex("DirectionId");

                    b.HasIndex("EducationFormId");

                    b.HasIndex("EducationProgramTypeId");

                    b.HasIndex("FacultyId");

                    b.ToTable("EducationPlans");
                });

            modelBuilder.Entity("Data.University.EducationPlanCompoment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationPlanCompoments");
                });

            modelBuilder.Entity("Data.University.EducationPlanGraphic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("CourseWorkTest");

                    b.Property<bool?>("CreditTest");

                    b.Property<bool?>("DiffCreditTest");

                    b.Property<int?>("EducationPlanItemElementId");

                    b.Property<int?>("EducationPlanItemId");

                    b.Property<bool?>("ExaminationTest");

                    b.Property<int>("IndependentWorkHours");

                    b.Property<int>("LaboratoryHours");

                    b.Property<int>("LectionHours");

                    b.Property<int>("PracticeHours");

                    b.Property<int>("SemesterNo");

                    b.Property<bool?>("SettlementWorkTest");

                    b.Property<double>("Zet");

                    b.HasKey("Id");

                    b.HasIndex("EducationPlanItemId");

                    b.ToTable("EducationPlanGraphics");
                });

            modelBuilder.Entity("Data.University.EducationPlanItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("ComponentId");

                    b.Property<int?>("DisciplineCycleId");

                    b.Property<int?>("DisciplineId");

                    b.Property<int?>("EducationCompetenceId");

                    b.Property<int?>("EducationPlanComponentId");

                    b.Property<int?>("EducationPlanId");

                    b.Property<bool?>("IsChecked");

                    b.HasKey("Id");

                    b.HasIndex("ComponentId");

                    b.HasIndex("DisciplineCycleId");

                    b.HasIndex("DisciplineId");

                    b.HasIndex("EducationCompetenceId");

                    b.HasIndex("EducationPlanId");

                    b.ToTable("EducationPlanItems");
                });

            modelBuilder.Entity("Data.University.EducationProgramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("EducationProgramTypes");
                });

            modelBuilder.Entity("Data.University.EducationStandartType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("EducationStandartTypes");
                });

            modelBuilder.Entity("Data.University.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("Data.University.FinanceSource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsBudget");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FinanceSources");
                });

            modelBuilder.Entity("Data.University.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Data.University.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdmissionYear");

                    b.Property<int?>("EducationFormId");

                    b.Property<int?>("EducationPlanId");

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EducationFormId");

                    b.HasIndex("EducationPlanId");

                    b.HasIndex("FacultyId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Data.University.IdentityDocument", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CitizenshipId");

                    b.Property<DateTime?>("Date");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Number");

                    b.Property<int?>("OrganizationId");

                    b.Property<string>("Patronimyc");

                    b.Property<int?>("PersonId");

                    b.Property<string>("Series");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TypeId");

                    b.ToTable("IdentityDocuments");
                });

            modelBuilder.Entity("Data.University.IdentityOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IdentityOrganizations");
                });

            modelBuilder.Entity("Data.University.IdentityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("IdentityTypes");
                });

            modelBuilder.Entity("Data.University.InterfaceElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("InterfaceElements");
                });

            modelBuilder.Entity("Data.University.InterfacePermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InterfaceElementId");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("InterfaceElementId");

                    b.HasIndex("RoleId");

                    b.ToTable("InterfacePermissions");
                });

            modelBuilder.Entity("Data.University.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DistrictId");

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Data.University.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GenderId");

                    b.Property<string>("LastName");

                    b.Property<string>("Patronimyc");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Data.University.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Data.University.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsAstuAccessRequired");

                    b.Property<bool?>("IsWorkOkAccessRequired");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Data.University.Street", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentId");

                    b.Property<int>("ParentLevel");

                    b.Property<string>("Prefix");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Data.University.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FinanceSourceId");

                    b.Property<int?>("GroupId");

                    b.Property<string>("PersonFileNumber");

                    b.Property<int?>("PersonId");

                    b.Property<int?>("StudentStateId");

                    b.HasKey("Id");

                    b.HasIndex("FinanceSourceId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PersonId");

                    b.HasIndex("StudentStateId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Data.University.StudentState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("StudentStates");
                });

            modelBuilder.Entity("Data.University.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CathedraId");

                    b.Property<int?>("PersonId");

                    b.HasKey("Id");

                    b.HasIndex("CathedraId");

                    b.HasIndex("PersonId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Data.University.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FiasCode");

                    b.Property<string>("KladrCode");

                    b.Property<string>("Name");

                    b.Property<string>("Prefix");

                    b.Property<int?>("RegionId");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Data.University.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Login");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Patronimyc");

                    b.Property<string>("Phone");

                    b.Property<int?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Data.University.Address", b =>
                {
                    b.HasOne("Data.University.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Locality", "Locality")
                        .WithMany()
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Street", "Street")
                        .WithMany()
                        .HasForeignKey("StreetId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.CommandPermission", b =>
                {
                    b.HasOne("Data.University.Command", "Command")
                        .WithMany("Permissions")
                        .HasForeignKey("CommandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("AvailableCommands")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Direction", b =>
                {
                    b.HasOne("Data.University.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationProgramType", "EducationProgramType")
                        .WithMany()
                        .HasForeignKey("EducationProgramTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationStandartType", "EducationStandartType")
                        .WithMany()
                        .HasForeignKey("EducationStandartTypeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.District", b =>
                {
                    b.HasOne("Data.University.Region", "Region")
                        .WithMany("Districts")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.EducationPlan", b =>
                {
                    b.HasOne("Data.University.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Direction", "Direction")
                        .WithMany()
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationForm", "EducationForm")
                        .WithMany()
                        .HasForeignKey("EducationFormId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationProgramType", "EducationProgramType")
                        .WithMany()
                        .HasForeignKey("EducationProgramTypeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Faculty", "Faculty")
                        .WithMany()
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.EducationPlanGraphic", b =>
                {
                    b.HasOne("Data.University.EducationPlanItem", "EducationPlanItem")
                        .WithMany("Graphics")
                        .HasForeignKey("EducationPlanItemId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.EducationPlanItem", b =>
                {
                    b.HasOne("Data.University.EducationPlanCompoment", "Component")
                        .WithMany()
                        .HasForeignKey("ComponentId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.DisciplineCycle", "Cycle")
                        .WithMany()
                        .HasForeignKey("DisciplineCycleId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationCompetence", "Competence")
                        .WithMany()
                        .HasForeignKey("EducationCompetenceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationPlan", "EducationPlan")
                        .WithMany("Items")
                        .HasForeignKey("EducationPlanId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Group", b =>
                {
                    b.HasOne("Data.University.EducationForm", "EducationForm")
                        .WithMany()
                        .HasForeignKey("EducationFormId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.EducationPlan", "EducationPlan")
                        .WithMany()
                        .HasForeignKey("EducationPlanId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Faculty", "Faculty")
                        .WithMany("Groups")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.IdentityDocument", b =>
                {
                    b.HasOne("Data.University.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.IdentityOrganization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany("IdentityDocuments")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.IdentityType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.InterfacePermission", b =>
                {
                    b.HasOne("Data.University.InterfaceElement", "InterfaceElement")
                        .WithMany("Permissions")
                        .HasForeignKey("InterfaceElementId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("AvailableViews")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Locality", b =>
                {
                    b.HasOne("Data.University.District", "District")
                        .WithMany("Localities")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Person", b =>
                {
                    b.HasOne("Data.University.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Region", b =>
                {
                    b.HasOne("Data.University.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Student", b =>
                {
                    b.HasOne("Data.University.FinanceSource", "FinanceSource")
                        .WithMany()
                        .HasForeignKey("FinanceSourceId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.StudentState", "State")
                        .WithMany()
                        .HasForeignKey("StudentStateId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Teacher", b =>
                {
                    b.HasOne("Data.University.Cathedra", "Cathedra")
                        .WithMany()
                        .HasForeignKey("CathedraId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Data.University.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.Town", b =>
                {
                    b.HasOne("Data.University.Region", "Region")
                        .WithMany("Towns")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("Data.University.User", b =>
                {
                    b.HasOne("Data.University.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
