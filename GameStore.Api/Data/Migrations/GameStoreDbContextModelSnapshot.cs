﻿// <auto-generated />
using System;
using GameStore.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameStore.Api.Data.Migrations
{
    [DbContext(typeof(GameStoreDbContext))]
    partial class GameStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("GameStore.Api.Entities.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ubisoft"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Rockstar Games"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CD Projekt Red"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Bethesda Game Studios"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Naughty Dog"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Nintendo"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Valve"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Epic Games"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Blizzard Entertainment"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Square Enix"
                        });
                });

            modelBuilder.Entity("GameStore.Api.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameStore.Api.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 3,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 9,
                            Name = "MMO"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Racing"
                        });
                });

            modelBuilder.Entity("GameStore.Api.Entities.Game", b =>
                {
                    b.HasOne("GameStore.Api.Entities.Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameStore.Api.Entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Genre");
                });
#pragma warning restore 612, 618
        }
    }
}
