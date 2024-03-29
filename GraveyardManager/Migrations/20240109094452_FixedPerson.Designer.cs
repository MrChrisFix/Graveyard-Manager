﻿// <auto-generated />
using System;
using GraveyardManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraveyardManager.Migrations
{
    [DbContext(typeof(GraveyardDbContext))]
    [Migration("20240109094452_FixedPerson")]
    partial class FixedPerson
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("GraveyardManager.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("GraveyardManager.Model.Grave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("PaidUntil")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PlotAcquisition")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlotId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlotId")
                        .IsUnique();

                    b.ToTable("Graves");
                });

            modelBuilder.Entity("GraveyardManager.Model.Graveyard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Graveyards");
                });

            modelBuilder.Entity("GraveyardManager.Model.GraveyardOwner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("GraveyardOwner");
                });

            modelBuilder.Entity("GraveyardManager.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Death")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Funeral")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GraveId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly?>("Ordained")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlotId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RemovedGraveId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GraveId");

                    b.HasIndex("RemovedGraveId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("GraveyardManager.Model.Plot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Angle")
                        .HasColumnType("TEXT");

                    b.Property<int>("GraveyardId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GraveyardPart")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("X")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Y")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GraveyardId");

                    b.ToTable("Plots");
                });

            modelBuilder.Entity("GraveyardManager.Model.RemovedGrave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("GraveRemoval")
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("PlotAcquisition")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlotId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlotId");

                    b.ToTable("RemovedGraves");
                });

            modelBuilder.Entity("GraveyardManager.Model.Grave", b =>
                {
                    b.HasOne("GraveyardManager.Model.Plot", null)
                        .WithOne("Grave")
                        .HasForeignKey("GraveyardManager.Model.Grave", "PlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraveyardManager.Model.Graveyard", b =>
                {
                    b.HasOne("GraveyardManager.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GraveyardManager.Model.GraveyardOwner", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GraveyardManager.Model.GraveyardOwner", b =>
                {
                    b.HasOne("GraveyardManager.Model.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("GraveyardManager.Model.Person", b =>
                {
                    b.HasOne("GraveyardManager.Model.Grave", null)
                        .WithMany("People")
                        .HasForeignKey("GraveId");

                    b.HasOne("GraveyardManager.Model.RemovedGrave", null)
                        .WithMany("People")
                        .HasForeignKey("RemovedGraveId");
                });

            modelBuilder.Entity("GraveyardManager.Model.Plot", b =>
                {
                    b.HasOne("GraveyardManager.Model.Graveyard", null)
                        .WithMany("Plots")
                        .HasForeignKey("GraveyardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraveyardManager.Model.RemovedGrave", b =>
                {
                    b.HasOne("GraveyardManager.Model.Plot", null)
                        .WithMany("RemovedGraves")
                        .HasForeignKey("PlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GraveyardManager.Model.Grave", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("GraveyardManager.Model.Graveyard", b =>
                {
                    b.Navigation("Plots");
                });

            modelBuilder.Entity("GraveyardManager.Model.Plot", b =>
                {
                    b.Navigation("Grave");

                    b.Navigation("RemovedGraves");
                });

            modelBuilder.Entity("GraveyardManager.Model.RemovedGrave", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
