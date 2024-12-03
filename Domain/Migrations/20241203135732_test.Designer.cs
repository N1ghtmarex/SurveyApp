﻿// <auto-generated />
using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241203135732_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<Guid?>("UserSurveyBindId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_survey_bind_id");

                    b.HasKey("Id")
                        .HasName("pk_answer");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_answer_question_id");

                    b.HasIndex("UserSurveyBindId")
                        .HasDatabaseName("ix_answer_user_survey_bind_id");

                    b.ToTable("answer", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Choice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("uuid")
                        .HasColumnName("answer_id");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uuid")
                        .HasColumnName("question_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_choice");

                    b.HasIndex("AnswerId")
                        .HasDatabaseName("ix_choice_answer_id");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_choice_question_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_choice_user_id");

                    b.ToTable("choice", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid")
                        .HasColumnName("survey_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_question");

                    b.HasIndex("SurveyId")
                        .HasDatabaseName("ix_question_survey_id");

                    b.ToTable("question", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Survey", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id")
                        .HasName("pk_survey");

                    b.ToTable("survey", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_hash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("password_salt");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserSurveyBind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTimeOffset?>("CompletedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completed_at");

                    b.Property<DateTimeOffset>("StartedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("started_at");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("SurveyId")
                        .HasColumnType("uuid")
                        .HasColumnName("survey_id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_user_survey_bind");

                    b.HasIndex("SurveyId")
                        .HasDatabaseName("ix_user_survey_bind_survey_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_survey_bind_user_id");

                    b.ToTable("user_survey_bind", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.HasOne("Domain.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_answer_questions_question_id");

                    b.HasOne("Domain.Entities.UserSurveyBind", null)
                        .WithMany("Answers")
                        .HasForeignKey("UserSurveyBindId")
                        .HasConstraintName("fk_answer_user_survey_binds_user_survey_bind_id");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.Choice", b =>
                {
                    b.HasOne("Domain.Entities.Answer", "Answer")
                        .WithMany("Choices")
                        .HasForeignKey("AnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_choice_answer_answer_id");

                    b.HasOne("Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_choice_questions_question_id");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Choices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_choice_users_user_id");

                    b.Navigation("Answer");

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.HasOne("Domain.Entities.Survey", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_question_surveys_survey_id");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("Domain.Entities.UserSurveyBind", b =>
                {
                    b.HasOne("Domain.Entities.Survey", "Survey")
                        .WithMany("UserSurveyBinds")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_survey_bind_survey_survey_id");

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("UserSurveyBinds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_survey_bind_user_user_id");

                    b.Navigation("Survey");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Answer", b =>
                {
                    b.Navigation("Choices");
                });

            modelBuilder.Entity("Domain.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.Survey", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("UserSurveyBinds");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Choices");

                    b.Navigation("UserSurveyBinds");
                });

            modelBuilder.Entity("Domain.Entities.UserSurveyBind", b =>
                {
                    b.Navigation("Answers");
                });
#pragma warning restore 612, 618
        }
    }
}
