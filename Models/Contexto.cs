using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_Filme.Models
{
    public partial class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaFilme> CategoriaFilmes { get; set; } = null!;
        public virtual DbSet<Filme> Filmes { get; set; } = null!;
        public virtual DbSet<NacionalidadeFilme> NacionalidadeFilmes { get; set; } = null!;
        public virtual DbSet<StreamingFilme> StreamingFilmes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QRT88F9\\SQLEXPRESS;database=Filme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaFilme>(entity =>
            {
                entity.ToTable("CategoriaFilme");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Filme>(entity =>
            {
                entity.ToTable("Filme");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_Id");

                entity.Property(e => e.NacionalidadeId).HasColumnName("Nacionalidade_Id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StreamingId).HasColumnName("Streaming_Id");

                entity.Property(e => e.Url)
                    .IsUnicode(false)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<NacionalidadeFilme>(entity =>
            {
                entity.ToTable("NacionalidadeFilme");

                entity.Property(e => e.Nacionalidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StreamingFilme>(entity =>
            {
                entity.ToTable("StreamingFilme");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
