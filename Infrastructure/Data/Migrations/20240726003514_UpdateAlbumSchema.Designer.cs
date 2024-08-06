﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AlbunsContext))]
    [Migration("20240726003514_UpdateAlbumSchema")]
    partial class UpdateAlbumSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Domain.Entities.Albun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Duration")
                        .HasColumnType("REAL");

                    b.Property<int>("MusicianId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("MusicianName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SongsSerialized")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MusicianId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Albuns");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbunId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubcriberUserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubscriberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlbunId");

                    b.HasIndex("SubscriberId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<int>("UserType");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Admin", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Domain.Entities.Musician", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<int?>("AlbunId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MusicianName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Musiciansquant")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AlbunId");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.Entities.Subscriber", b =>
                {
                    b.HasBaseType("Domain.Entities.User");

                    b.Property<string>("FavoriteGenre")
                        .HasColumnType("TEXT");

                    b.Property<int>("Phone")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.Entities.Albun", b =>
                {
                    b.HasOne("Domain.Entities.Musician", "Musician")
                        .WithMany("Albuns")
                        .HasForeignKey("MusicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Review", null)
                        .WithMany("albuns")
                        .HasForeignKey("ReviewId");

                    b.Navigation("Musician");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.HasOne("Domain.Entities.Albun", "Albun")
                        .WithMany("Reviews")
                        .HasForeignKey("AlbunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Subscriber", "Subscriber")
                        .WithMany("Reviews")
                        .HasForeignKey("SubscriberId");

                    b.Navigation("Albun");

                    b.Navigation("Subscriber");
                });

            modelBuilder.Entity("Domain.Entities.Musician", b =>
                {
                    b.HasOne("Domain.Entities.Albun", "Albun")
                        .WithMany()
                        .HasForeignKey("AlbunId");

                    b.Navigation("Albun");
                });

            modelBuilder.Entity("Domain.Entities.Albun", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Domain.Entities.Review", b =>
                {
                    b.Navigation("albuns");
                });

            modelBuilder.Entity("Domain.Entities.Musician", b =>
                {
                    b.Navigation("Albuns");
                });

            modelBuilder.Entity("Domain.Entities.Subscriber", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
