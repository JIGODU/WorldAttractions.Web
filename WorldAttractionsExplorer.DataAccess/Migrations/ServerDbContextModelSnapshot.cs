﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldAttractionsExplorer.DataAccess;

#nullable disable

namespace WorldAttractionsExplorer.DataAccess.Migrations
{
    [DbContext(typeof(ServerDbContext))]
    partial class ServerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.AttractionTags", b =>
                {
                    b.Property<int>("AttractionId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("AttractionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("AttractionTags");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Attractions", b =>
                {
                    b.Property<int>("AttractionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AttractionId"));

                    b.Property<string>("AttractionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<double>("AverageRating")
                        .HasColumnType("double");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EditorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedOn")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("LastModifiedOn"));

                    b.Property<int>("PrimaryImageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<DateTime>("PublishedDate"));

                    b.HasKey("AttractionId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CountryId");

                    b.HasIndex("EditorId");

                    b.HasIndex("PrimaryImageId")
                        .IsUnique();

                    b.ToTable("Attractions");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CountryId"));

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Images", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ImageId"));

                    b.Property<int>("AttractionId")
                        .HasColumnType("int");

                    b.Property<int?>("AttractionsAttractionId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("AttractionId");

                    b.HasIndex("AttractionsAttractionId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Reviews", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("AttractionId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PublishingDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Rating")
                        .HasColumnType("double");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ReviewId");

                    b.HasIndex("AttractionId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Tags", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("TagId"));

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Users", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfJoin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.AttractionTags", b =>
                {
                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Attractions", "Attraction")
                        .WithMany("AttractionTags")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Tags", "Tag")
                        .WithMany("AttractionTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attraction");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Attractions", b =>
                {
                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Users", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Country", "Country")
                        .WithMany("Attractions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Users", "Editor")
                        .WithMany()
                        .HasForeignKey("EditorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Images", "PrimaryImage")
                        .WithOne()
                        .HasForeignKey("WorldAttractionsExplorer.DataAccess.Models.Attractions", "PrimaryImageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Country");

                    b.Navigation("Editor");

                    b.Navigation("PrimaryImage");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Images", b =>
                {
                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Attractions", "Attraction")
                        .WithMany()
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Attractions", null)
                        .WithMany("OptionalImages")
                        .HasForeignKey("AttractionsAttractionId");

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Users", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attraction");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Reviews", b =>
                {
                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Attractions", "Attraction")
                        .WithMany("Reviews")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorldAttractionsExplorer.DataAccess.Models.Users", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Attraction");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Attractions", b =>
                {
                    b.Navigation("AttractionTags");

                    b.Navigation("OptionalImages");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Country", b =>
                {
                    b.Navigation("Attractions");
                });

            modelBuilder.Entity("WorldAttractionsExplorer.DataAccess.Models.Tags", b =>
                {
                    b.Navigation("AttractionTags");
                });
#pragma warning restore 612, 618
        }
    }
}
