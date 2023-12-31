﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitedLibraryAPI.Data;

#nullable disable

namespace UnitedLibraryAPI.Migrations
{
    [DbContext(typeof(UnitedLibraryContext))]
    partial class UnitedLibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("SQL_Ukrainian_CP1251_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UnitedLibraryAPI.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FrontCoverPath")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.BookNovel", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("NovelId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "NovelId");

                    b.HasIndex("NovelId");

                    b.ToTable("BookNovels");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.LibraryBook", b =>
                {
                    b.Property<int>("LibraryId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("InAvailable")
                        .HasColumnType("int");

                    b.HasKey("LibraryId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("LibraryBooks");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Novel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Novels");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.NovelWriter", b =>
                {
                    b.Property<int>("NovelId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("NovelId", "WriterId");

                    b.HasIndex("WriterId");

                    b.ToTable("NovelWriters");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Writer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ThirdName")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Address", b =>
                {
                    b.HasOne("UnitedLibraryAPI.Models.Library", "Library")
                        .WithOne("PhysicalAddress")
                        .HasForeignKey("UnitedLibraryAPI.Models.Address", "LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Library");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.BookNovel", b =>
                {
                    b.HasOne("UnitedLibraryAPI.Models.Book", "Book")
                        .WithMany("Novels")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnitedLibraryAPI.Models.Novel", "Novel")
                        .WithMany("Books")
                        .HasForeignKey("NovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Novel");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.LibraryBook", b =>
                {
                    b.HasOne("UnitedLibraryAPI.Models.Book", "Book")
                        .WithMany("Libraries")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnitedLibraryAPI.Models.Library", "Library")
                        .WithMany("Books")
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Library");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.NovelWriter", b =>
                {
                    b.HasOne("UnitedLibraryAPI.Models.Novel", "Novel")
                        .WithMany("Writers")
                        .HasForeignKey("NovelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UnitedLibraryAPI.Models.Writer", "Writer")
                        .WithMany("Novels")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Novel");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Book", b =>
                {
                    b.Navigation("Libraries");

                    b.Navigation("Novels");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Library", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("PhysicalAddress");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Novel", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Writers");
                });

            modelBuilder.Entity("UnitedLibraryAPI.Models.Writer", b =>
                {
                    b.Navigation("Novels");
                });
#pragma warning restore 612, 618
        }
    }
}
