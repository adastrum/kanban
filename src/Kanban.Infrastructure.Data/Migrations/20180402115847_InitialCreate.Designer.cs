﻿// <auto-generated />
using Kanban.Domain.Model.Entities;
using Kanban.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Kanban.Infrastructure.Data.Migrations
{
    [DbContext(typeof(KanbanDbContext))]
    [Migration("20180402115847_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kanban.Domain.Model.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Kanban.Domain.Model.Entities.ProjectTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AssigneeId");

                    b.Property<DateTime>("CompletedDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<Guid>("ProjectId");

                    b.Property<Guid?>("ReporterId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReporterId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("Kanban.Domain.Model.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kanban.Domain.Model.Entities.ProjectTask", b =>
                {
                    b.HasOne("Kanban.Domain.Model.Entities.User", "Assignee")
                        .WithMany()
                        .HasForeignKey("AssigneeId");

                    b.HasOne("Kanban.Domain.Model.Entities.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kanban.Domain.Model.Entities.User", "Reporter")
                        .WithMany()
                        .HasForeignKey("ReporterId");
                });
#pragma warning restore 612, 618
        }
    }
}
