﻿// <auto-generated />
using System;
using AutomatedLearningSystem.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutomatedLearningSystem.Infrastructure.Migrations
{
    [DbContext(typeof(AutomatedLearningSystemDbContext))]
    partial class AutomatedLearningSystemDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("AutomatedLearningSystem.Domain.Answers.AnswerForQuestion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("AddedDateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Answer")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("AnswerForQuestion");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.LearningItems.LearningItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT");

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("LearningItem");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.LearningPaths.LearningPath", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("LearningPath");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.Questions.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.UserLearningItems.UserLearningItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("LearningItemId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LearningPathId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LearningItemId");

                    b.HasIndex("LearningPathId");

                    b.ToTable("UserLearningItem");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.Answers.AnswerForQuestion", b =>
                {
                    b.HasOne("AutomatedLearningSystem.Domain.Questions.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutomatedLearningSystem.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.LearningPaths.LearningPath", b =>
                {
                    b.HasOne("AutomatedLearningSystem.Domain.Users.User", null)
                        .WithMany("LearningPaths")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.UserLearningItems.UserLearningItem", b =>
                {
                    b.HasOne("AutomatedLearningSystem.Domain.LearningItems.LearningItem", "LearningItem")
                        .WithMany()
                        .HasForeignKey("LearningItemId");

                    b.HasOne("AutomatedLearningSystem.Domain.LearningPaths.LearningPath", null)
                        .WithMany("UserLearningItems")
                        .HasForeignKey("LearningPathId");

                    b.Navigation("LearningItem");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.LearningPaths.LearningPath", b =>
                {
                    b.Navigation("UserLearningItems");
                });

            modelBuilder.Entity("AutomatedLearningSystem.Domain.Users.User", b =>
                {
                    b.Navigation("LearningPaths");
                });
#pragma warning restore 612, 618
        }
    }
}
