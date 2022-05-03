using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Kiemtracuoiky.Models
{
    public partial class UserCSDL : DbContext
    {
        public UserCSDL()
            : base("name=UserCSDL1")
        {
        }

        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Donhang> Donhangs { get; set; }
        public virtual DbSet<Giohang> Giohangs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<QTV> QTVs { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Danhmuc>()
                .HasMany(e => e.Sanphams)
                .WithRequired(e => e.Danhmuc)
                .HasForeignKey(e => e.idDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Khachhang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<Khachhang>()
                .HasOptional(e => e.Donhang)
                .WithRequired(e => e.Khachhang);

            modelBuilder.Entity<Khachhang>()
                .HasMany(e => e.Giohangs)
                .WithOptional(e => e.Khachhang)
                .HasForeignKey(e => e.idKH);

            modelBuilder.Entity<QTV>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Giamgia)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .Property(e => e.Hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Donhangs)
                .WithOptional(e => e.Sanpham)
                .HasForeignKey(e => e.idSP);

            modelBuilder.Entity<Sanpham>()
                .HasMany(e => e.Giohangs)
                .WithOptional(e => e.Sanpham)
                .HasForeignKey(e => e.idSP);
        }
    }
}
