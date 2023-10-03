﻿// <auto-generated />
using System;
using Backend_Final.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_Final.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231003173040_addedEventCategoryid")]
    partial class addedEventCategoryid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Backend_Final.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("Backend_Final.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Backend_Final.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend_Final.Models.CommentTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CommentTitle");
                });

            modelBuilder.Entity("Backend_Final.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CourseFeaturesId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Backend_Final.Models.CourseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseDetail");
                });

            modelBuilder.Entity("Backend_Final.Models.CourseFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseFeature");
                });

            modelBuilder.Entity("Backend_Final.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.EventDetailImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("EventDetailImage");
                });

            modelBuilder.Entity("Backend_Final.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CourseId");

                    b.HasIndex("EventId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Backend_Final.Models.SettingsKeyValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SettingsKeyValue");
                });

            modelBuilder.Entity("Backend_Final.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("Backend_Final.Models.SliderImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("SliderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SliderId");

                    b.ToTable("SliderImage");
                });

            modelBuilder.Entity("Backend_Final.Models.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specilty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("Backend_Final.Models.Subscribers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Backend_Final.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("CourseId");

                    b.HasIndex("EventId");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("Backend_Final.Models.Blog", b =>
                {
                    b.HasOne("Backend_Final.Models.Category", "Category")
                        .WithMany("Blog")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Backend_Final.Models.Course", b =>
                {
                    b.HasOne("Backend_Final.Models.Category", "Category")
                        .WithMany("Course")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Backend_Final.Models.CourseDetail", b =>
                {
                    b.HasOne("Backend_Final.Models.Course", "Course")
                        .WithMany("CourseDetail")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend_Final.Models.CourseFeature", b =>
                {
                    b.HasOne("Backend_Final.Models.Course", "Course")
                        .WithOne("CourseFeature")
                        .HasForeignKey("Backend_Final.Models.CourseFeature", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Backend_Final.Models.Event", b =>
                {
                    b.HasOne("Backend_Final.Models.Category", "Category")
                        .WithMany("Event")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Backend_Final.Models.EventDetailImage", b =>
                {
                    b.HasOne("Backend_Final.Models.Event", "Event")
                        .WithOne("EventDetailImage")
                        .HasForeignKey("Backend_Final.Models.EventDetailImage", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.Post", b =>
                {
                    b.HasOne("Backend_Final.Models.Blog", "Blog")
                        .WithMany("Post")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Final.Models.Course", "Course")
                        .WithMany("Post")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Final.Models.Event", "Event")
                        .WithMany("Post")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Course");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.SliderImage", b =>
                {
                    b.HasOne("Backend_Final.Models.Slider", "Slider")
                        .WithMany("SliderImgae")
                        .HasForeignKey("SliderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slider");
                });

            modelBuilder.Entity("Backend_Final.Models.Speaker", b =>
                {
                    b.HasOne("Backend_Final.Models.Event", "Event")
                        .WithMany("Speakers")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.Tag", b =>
                {
                    b.HasOne("Backend_Final.Models.Blog", "Blog")
                        .WithMany("Tag")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Final.Models.Course", "Course")
                        .WithMany("Tag")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend_Final.Models.Event", "Event")
                        .WithMany("Tag")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Course");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.Blog", b =>
                {
                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Backend_Final.Models.Category", b =>
                {
                    b.Navigation("Blog");

                    b.Navigation("Course");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("Backend_Final.Models.Course", b =>
                {
                    b.Navigation("CourseDetail");

                    b.Navigation("CourseFeature")
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Backend_Final.Models.Event", b =>
                {
                    b.Navigation("EventDetailImage")
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("Speakers");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Backend_Final.Models.Slider", b =>
                {
                    b.Navigation("SliderImgae");
                });
#pragma warning restore 612, 618
        }
    }
}
