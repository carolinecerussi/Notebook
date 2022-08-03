﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notebook.Models;

namespace Notebook.Migrations
{
    [DbContext(typeof(NotebookContext))]
    [Migration("20220803175714_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Notebook.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Notebook.Models.CategoryNote", b =>
                {
                    b.Property<int>("CategoryNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.HasKey("CategoryNoteId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("NoteId");

                    b.ToTable("CategoryNote");
                });

            modelBuilder.Entity("Notebook.Models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NoteTitle")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("NoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("Notebook.Models.CategoryNote", b =>
                {
                    b.HasOne("Notebook.Models.Category", "Category")
                        .WithMany("JoinEntities")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Notebook.Models.Note", "Note")
                        .WithMany("JoinEntities")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("Notebook.Models.Category", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("Notebook.Models.Note", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
