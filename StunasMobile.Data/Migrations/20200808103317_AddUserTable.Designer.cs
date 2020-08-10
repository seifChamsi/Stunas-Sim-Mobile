﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StunasMobile.Data.DbContext;

namespace StunasMobile.Data.Migrations
{
    [DbContext(typeof(StunasDBContext))]
    [Migration("20200808103317_AddUserTable")]
    partial class AddUserTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("StunasMobile.Entities.Entitites.Historique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<List<string>>("ChangedColumns")
                        .HasColumnType("text[]");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("MobileId")
                        .HasColumnType("integer");

                    b.Property<List<string>>("NewValues")
                        .HasColumnType("text[]");

                    b.Property<List<string>>("PreviousValues")
                        .HasColumnType("text[]");

                    b.Property<int>("RecordId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MobileId");

                    b.ToTable("Historique");
                });

            modelBuilder.Entity("StunasMobile.Entities.Entitites.Mobile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Codeclient")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("codeclient");

                    b.Property<string>("Data")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("data");

                    b.Property<string>("Forfait")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("forfait");

                    b.Property<string>("Handset")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("handset");

                    b.Property<string>("Montant")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("montant");

                    b.Property<string>("Nom")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("nom");

                    b.Property<decimal>("Numero")
                        .HasColumnType("numeric")
                        .HasColumnName("numero");

                    b.Property<string>("Prixhandset")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("prixhandset");

                    b.Property<string>("Site")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("site");

                    b.Property<string>("Sociéte")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("sociéte");

                    b.HasKey("Id");

                    b.ToTable("mobile");
                });

            modelBuilder.Entity("StunasMobile.Entities.Entitites.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StunasMobile.Entities.Entitites.Historique", b =>
                {
                    b.HasOne("StunasMobile.Entities.Entitites.Mobile", "Mobile")
                        .WithMany("Historiques")
                        .HasForeignKey("MobileId");
                });
#pragma warning restore 612, 618
        }
    }
}
