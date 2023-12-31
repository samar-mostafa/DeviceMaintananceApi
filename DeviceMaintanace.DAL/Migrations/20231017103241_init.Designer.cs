﻿// <auto-generated />
using DeviceMaintanace.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeviceMaintanace.DAL.Migrations
{
    [DbContext(typeof(DeviceMaintanaceContext))]
    [Migration("20231017103241_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DeviceMaintanace.Tables.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.BrancheDepartment", b =>
                {
                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.HasKey("BranchId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("BrancheDepartments");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Device", b =>
                {
                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DeviceModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeviceTypeId")
                        .HasColumnType("int");

                    b.HasKey("SerialNumber");

                    b.HasIndex("DeviceTypeId")
                        .IsUnique();

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.DeviceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeviceStatuses");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.DeviceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("deviceTypes");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Employee", b =>
                {
                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BrancheDepartmentId1")
                        .HasColumnType("int");

                    b.Property<int>("BrancheDepartmentId2")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MobilePhone");

                    b.HasIndex("BrancheDepartmentId1", "BrancheDepartmentId2");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.BrancheDepartment", b =>
                {
                    b.HasOne("DeviceMaintanace.Tables.Branch", "Branch")
                        .WithMany("BranchesDepartments")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeviceMaintanace.Tables.Department", "Department")
                        .WithMany("BranchesDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Device", b =>
                {
                    b.HasOne("DeviceMaintanace.Tables.DeviceType", "DeviceType")
                        .WithOne("Device")
                        .HasForeignKey("DeviceMaintanace.Tables.Device", "DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceType");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Employee", b =>
                {
                    b.HasOne("DeviceMaintanace.Tables.BrancheDepartment", "BrancheDepartment")
                        .WithMany()
                        .HasForeignKey("BrancheDepartmentId1", "BrancheDepartmentId2")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BrancheDepartment");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Branch", b =>
                {
                    b.Navigation("BranchesDepartments");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.Department", b =>
                {
                    b.Navigation("BranchesDepartments");
                });

            modelBuilder.Entity("DeviceMaintanace.Tables.DeviceType", b =>
                {
                    b.Navigation("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
