using Microsoft.EntityFrameworkCore;
using System.Runtime.Loader;
using UnitedLibraryAPI.Models;

namespace UnitedLibraryAPI.Data
{
    public class UnitedLibraryContext : DbContext
    {
        public UnitedLibraryContext(DbContextOptions<UnitedLibraryContext> options) 
            : base(options) 
        {
        
        }

        public DbSet<Library> Libraries { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Book>  Books { get; set; }

        public DbSet<Novel> Novels { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<LibraryBook> LibraryBooks { get; set; }

        public DbSet<BookNovel> BookNovels { get; set; }

        public DbSet<NovelWriter> NovelWriters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Ukrainian_CP1251_CI_AS");

            modelBuilder.Entity<LibraryBook>()
                .HasKey(lb => new { lb.LibraryId, lb.BookId });
            modelBuilder.Entity<LibraryBook>()
                .HasOne(lb => lb.Library)
                .WithMany(b => b.Books)
                .HasForeignKey(lb => lb.LibraryId);
            modelBuilder.Entity<LibraryBook>()
                .HasOne(lb => lb.Book)
                .WithMany(l => l.Libraries)
                .HasForeignKey(lb => lb.BookId);

            modelBuilder.Entity<BookNovel>()
                .HasKey(bn => new { bn.BookId, bn.NovelId });
            modelBuilder.Entity<BookNovel>()
                .HasOne(bn => bn.Book)
                .WithMany(n => n.Novels)
                .HasForeignKey(bn => bn.BookId);
            modelBuilder.Entity<BookNovel>()
                .HasOne(bn => bn.Novel)
                .WithMany(b => b.Books)
                .HasForeignKey(bn => bn.NovelId);

            modelBuilder.Entity<NovelWriter>()
                .HasKey(nw => new { nw.NovelId, nw.WriterId });
            modelBuilder.Entity<NovelWriter>()
                .HasOne(nw => nw.Novel)
                .WithMany(w => w.Writers)
                .HasForeignKey(nw => nw.NovelId);
            modelBuilder.Entity<NovelWriter>()
                .HasOne(nw => nw.Writer)
                .WithMany(n => n.Novels)
                .HasForeignKey(nw => nw.WriterId);
        }
    }
}
