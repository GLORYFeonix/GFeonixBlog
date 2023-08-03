﻿// <auto-generated />
using System;
using GFeonixBlog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GFeonixBlog.Data.Migrations
{
    [DbContext(typeof(BlogContext))]
    [Migration("20230629052831_Add Markdown")]
    partial class AddMarkdown
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.Property<int>("CategoriesID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PostsID")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriesID", "PostsID");

                    b.HasIndex("PostsID");

                    b.ToTable("CategoryPost");
                });

            modelBuilder.Entity("GFeonixBlog.Data.Models.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GFeonixBlog.Data.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Markdown")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("CategoryPost", b =>
                {
                    b.HasOne("GFeonixBlog.Data.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFeonixBlog.Data.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GFeonixBlog.Data.Models.Category", b =>
                {
                    b.HasOne("GFeonixBlog.Data.Models.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentID");

                    b.Navigation("Parent");
                });
#pragma warning restore 612, 618
        }
    }
}
