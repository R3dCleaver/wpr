﻿// <auto-generated />
using DemoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Beperking", b =>
                {
                    b.Property<int>("BeperkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BeperkingId"));

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BeperkingId");

                    b.ToTable("Beperkingen");
                });

            modelBuilder.Entity("Deelname", b =>
                {
                    b.Property<int>("DeskundigeId")
                        .HasColumnType("integer");

                    b.Property<int>("OnderzoekId")
                        .HasColumnType("integer");

                    b.HasKey("DeskundigeId", "OnderzoekId");

                    b.HasIndex("OnderzoekId");

                    b.ToTable("Deelname");
                });

            modelBuilder.Entity("DemoApp.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DriverNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("DemoApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DeskundigeBeperking", b =>
                {
                    b.Property<int>("DeskundigeId")
                        .HasColumnType("integer");

                    b.Property<int>("BeperkingId")
                        .HasColumnType("integer");

                    b.HasKey("DeskundigeId", "BeperkingId");

                    b.HasIndex("BeperkingId");

                    b.ToTable("DeskundigeBeperkingen");
                });

            modelBuilder.Entity("Onderzoek", b =>
                {
                    b.Property<int>("OnderzoekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OnderzoekId"));

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Beloning")
                        .HasColumnType("double precision");

                    b.Property<char>("Einddatum")
                        .HasColumnType("character(1)");

                    b.Property<string>("Locatie")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<char>("Startdatum")
                        .HasColumnType("character(1)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("OnderzoekId");

                    b.ToTable("Onderzoek");
                });

            modelBuilder.Entity("DemoApp.Models.Deskundige", b =>
                {
                    b.HasBaseType("DemoApp.Models.User");

                    b.Property<string>("Aandoening")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BenaderingCommercieel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BenaderingVoorkeur")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Beschikbaarheid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Leeftijd")
                        .HasColumnType("integer");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Deskundige");
                });

            modelBuilder.Entity("Deelname", b =>
                {
                    b.HasOne("DemoApp.Models.Deskundige", "Deskundige")
                        .WithMany("Deelnames")
                        .HasForeignKey("DeskundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Onderzoek", "Onderzoek")
                        .WithMany("Deelnames")
                        .HasForeignKey("OnderzoekId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deskundige");

                    b.Navigation("Onderzoek");
                });

            modelBuilder.Entity("DeskundigeBeperking", b =>
                {
                    b.HasOne("Beperking", "Beperking")
                        .WithMany("DeskundigeBeperkingen")
                        .HasForeignKey("BeperkingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoApp.Models.Deskundige", "Deskundige")
                        .WithMany("DeskundigeBeperkingen")
                        .HasForeignKey("DeskundigeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beperking");

                    b.Navigation("Deskundige");
                });

            modelBuilder.Entity("Beperking", b =>
                {
                    b.Navigation("DeskundigeBeperkingen");
                });

            modelBuilder.Entity("Onderzoek", b =>
                {
                    b.Navigation("Deelnames");
                });

            modelBuilder.Entity("DemoApp.Models.Deskundige", b =>
                {
                    b.Navigation("Deelnames");

                    b.Navigation("DeskundigeBeperkingen");
                });
#pragma warning restore 612, 618
        }
    }
}
