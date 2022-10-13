using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FaziTest.Models
{
    public partial class modelContext : DbContext
    {
        public modelContext()
        {
        }

        public modelContext(DbContextOptions<modelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kur> Kurs { get; set; }
        public virtual DbSet<Ocena> Ocenas { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Kur>(entity =>
            {
                entity.HasKey(e => e.Kod)
                    .HasName("PK__KURS__DFD8EB9FC40E6915");

                entity.ToTable("KURS");

                /*entity.Property(e => e.Kod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("kod");*/

                /*entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ime");*/

                /*entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("opis");*/
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.ToTable("OCENA");

               /* entity.Property(e => e.Id).HasColumnName("id");*/

               /* entity.Property(e => e.KursKod)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("kursKod");*/

                /*entity.Property(e => e.Ocena1).HasColumnName("ocena");*/

               /* entity.Property(e => e.StudentId).HasColumnName("studentId");*/

                entity.HasOne(d => d.KursKodNavigation)
                    .WithMany(p => p.Ocenas)
                    .HasForeignKey(d => d.KursKod);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Ocenas)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("STUDENT");

                //entity.Property(e => e.StudentId).HasColumnName("studentId");

                /*entity.Property(e => e.DatumRodjenja)
                    .HasColumnType("date")
                    .HasColumnName("datumRodjenja");*/

                /*entity.Property(e => e.Drzava)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("drzava");*/

                /*entity.Property(e => e.Grad)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("grad");*/

                /*entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ime");*/

                /*entity.Property(e => e.Pol)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("pol");*/

                /*entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("prezime");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
