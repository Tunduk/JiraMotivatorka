﻿// <auto-generated />
using System;
using JiraLikeYou.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JiraLikeYou.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191225093728_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.Occasion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CountTickets")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DaysInStatus")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("TicketId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TriggerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.HasIndex("UserEmail");

                    b.ToTable("Occasions");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.OccasionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OccasionTypes");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.PatternForOccasionType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("OccasionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SoundLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subtitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OccasionTypeId");

                    b.ToTable("PatternsForOccasion");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.PatternForTrigger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<long>("TriggerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TriggerId");

                    b.ToTable("PatternsForTrigger");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.Ticket", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Priority")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserEmail")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.Trigger", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountTickets")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DaysInStatus")
                        .HasColumnType("INTEGER");

                    b.Property<long>("OccasionTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Priority")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OccasionTypeId");

                    b.ToTable("Triggers");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.User", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.Occasion", b =>
                {
                    b.HasOne("JiraLikeYou.DAL.Entities.Ticket", "Ticket")
                        .WithMany("Occasions")
                        .HasForeignKey("TicketId");

                    b.HasOne("JiraLikeYou.DAL.Entities.User", "User")
                        .WithMany("Occasions")
                        .HasForeignKey("UserEmail");
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.PatternForOccasionType", b =>
                {
                    b.HasOne("JiraLikeYou.DAL.Entities.OccasionType", "OccasionType")
                        .WithMany("PatternsForOccasion")
                        .HasForeignKey("OccasionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.PatternForTrigger", b =>
                {
                    b.HasOne("JiraLikeYou.DAL.Entities.Trigger", "Triggers")
                        .WithMany("PatternsForTrigger")
                        .HasForeignKey("TriggerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JiraLikeYou.DAL.Entities.Trigger", b =>
                {
                    b.HasOne("JiraLikeYou.DAL.Entities.OccasionType", "OccasionType")
                        .WithMany("Triggers")
                        .HasForeignKey("OccasionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
