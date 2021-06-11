﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Modix.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Modix.Data.Migrations.Migrations
{
    [DbContext(typeof(ModixDbContext))]
    [Migration("20210611200336_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Modix.Data.Users.GuildUserEntity", b =>
                {
                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FirstSeen")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("GuildId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GuildUsers", "Users");
                });

            modelBuilder.Entity("Modix.Data.Users.GuildUserVersionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("GuildId")
                        .HasColumnType("bigint");

                    b.Property<long?>("NextVersionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nickname")
                        .HasColumnType("text");

                    b.Property<long?>("PreviousVersionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NextVersionId")
                        .IsUnique();

                    b.HasIndex("PreviousVersionId")
                        .IsUnique();

                    b.HasIndex("GuildId", "UserId");

                    b.ToTable("GuildUserVersions", "Users");
                });

            modelBuilder.Entity("Modix.Data.Users.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FirstSeen")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users", "Users");
                });

            modelBuilder.Entity("Modix.Data.Users.UserVersionEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("AvatarHash")
                        .HasColumnType("text");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Discriminator")
                        .HasColumnType("integer");

                    b.Property<long?>("NextVersionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PreviousVersionId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("NextVersionId")
                        .IsUnique();

                    b.HasIndex("PreviousVersionId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("UserVersions", "Users");
                });

            modelBuilder.Entity("Modix.Data.Users.GuildUserEntity", b =>
                {
                    b.HasOne("Modix.Data.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Modix.Data.Users.GuildUserVersionEntity", b =>
                {
                    b.HasOne("Modix.Data.Users.GuildUserVersionEntity", "NextVersion")
                        .WithOne()
                        .HasForeignKey("Modix.Data.Users.GuildUserVersionEntity", "NextVersionId");

                    b.HasOne("Modix.Data.Users.GuildUserVersionEntity", "PreviousVersion")
                        .WithOne()
                        .HasForeignKey("Modix.Data.Users.GuildUserVersionEntity", "PreviousVersionId");

                    b.HasOne("Modix.Data.Users.GuildUserEntity", "GuildUser")
                        .WithMany()
                        .HasForeignKey("GuildId", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GuildUser");

                    b.Navigation("NextVersion");

                    b.Navigation("PreviousVersion");
                });

            modelBuilder.Entity("Modix.Data.Users.UserVersionEntity", b =>
                {
                    b.HasOne("Modix.Data.Users.UserVersionEntity", "NextVersion")
                        .WithOne()
                        .HasForeignKey("Modix.Data.Users.UserVersionEntity", "NextVersionId");

                    b.HasOne("Modix.Data.Users.UserVersionEntity", "PreviousVersion")
                        .WithOne()
                        .HasForeignKey("Modix.Data.Users.UserVersionEntity", "PreviousVersionId");

                    b.HasOne("Modix.Data.Users.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextVersion");

                    b.Navigation("PreviousVersion");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}