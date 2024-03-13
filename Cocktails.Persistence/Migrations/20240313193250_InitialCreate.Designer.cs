﻿// <auto-generated />
using System;
using Cocktails.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cocktails.Persistence.Migrations
{
    [DbContext(typeof(CocktailsDb))]
    [Migration("20240313193250_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Cocktails.Domain.Cocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cocktail");
                });

            modelBuilder.Entity("Cocktails.Domain.FavoriteCocktail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CocktailId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CocktailId");

                    b.ToTable("FavoriteCocktails");
                });

            modelBuilder.Entity("Cocktails.Domain.FavoriteCocktail", b =>
                {
                    b.HasOne("Cocktails.Domain.Cocktail", "Cocktail")
                        .WithMany()
                        .HasForeignKey("CocktailId");

                    b.Navigation("Cocktail");
                });
#pragma warning restore 612, 618
        }
    }
}
