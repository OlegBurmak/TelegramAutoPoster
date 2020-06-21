﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAPoster.Models;

namespace TAPoster.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200621134701_Deley")]
    partial class Deley
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TAPoster.Models.PostSetting", b =>
                {
                    b.Property<int>("PostSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostCount")
                        .HasColumnType("int");

                    b.Property<string>("PostFilter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostItemComment")
                        .HasColumnType("int");

                    b.Property<int>("PostItemLike")
                        .HasColumnType("int");

                    b.Property<int>("PostItemRepost")
                        .HasColumnType("int");

                    b.Property<int>("PostItemView")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostSettingId");

                    b.HasIndex("UserId");

                    b.ToTable("PostSetting");
                });

            modelBuilder.Entity("TAPoster.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TAPoster.Models.UserSetting", b =>
                {
                    b.Property<int>("UserSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Deley")
                        .HasColumnType("int");

                    b.Property<int>("TelegramGroup")
                        .HasColumnType("int");

                    b.Property<string>("TelegramToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VkApiVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VkToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserSettingId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserSetting");
                });

            modelBuilder.Entity("TAPoster.Models.PostSetting", b =>
                {
                    b.HasOne("TAPoster.Models.User", "User")
                        .WithMany("PostSettings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TAPoster.Models.UserSetting", b =>
                {
                    b.HasOne("TAPoster.Models.User", "User")
                        .WithOne("UserSetting")
                        .HasForeignKey("TAPoster.Models.UserSetting", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
