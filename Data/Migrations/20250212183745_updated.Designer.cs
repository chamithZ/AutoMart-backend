﻿// <auto-generated />
using System;
using AutoStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoStore.Data.Migrations
{
    [DbContext(typeof(AutoStoreContext))]
    [Migration("20250212183745_updated")]
    partial class updated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("AutoStore.Entities.Order", b =>
                {
                    b.Property<int>("orderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<int>("partId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("orderId");

                    b.HasIndex("partId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("AutoStore.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PartTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("date")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("PartTypeId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("AutoStore.Entities.PartType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PartTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Engine"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Transmission"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Suspension"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Brakes"
                        });
                });

            modelBuilder.Entity("AutoStore.Entities.Order", b =>
                {
                    b.HasOne("AutoStore.Entities.Part", "Part")
                        .WithMany()
                        .HasForeignKey("partId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("AutoStore.Entities.Part", b =>
                {
                    b.HasOne("AutoStore.Entities.PartType", "PartType")
                        .WithMany()
                        .HasForeignKey("PartTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartType");
                });
#pragma warning restore 612, 618
        }
    }
}
