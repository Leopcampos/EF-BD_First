using System;
using System.Collections.Generic;
using FadamiBD_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FadamiBD_First.Data
{
    public partial class DBFirst_FadamiContext : DbContext
    {
        public DBFirst_FadamiContext()
        {
        }

        public DBFirst_FadamiContext(DbContextOptions<DBFirst_FadamiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LEOCAMPOS;Initial Catalog=DB-First_Fadami;Integrated Security=True;TrustServerCertificate=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.ToTable("USUARIO");

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

                entity.Property(e => e.BlAtivo).HasColumnName("BL_ATIVO");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CPF");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOGIN");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOME");

                entity.Property(e => e.QtdErroLogin).HasColumnName("QTD_ERRO_LOGIN");

                entity.Property(e => e.Senha)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SENHA");

                entity.Property(e => e.UltimoAcesso).HasColumnName("ULTIMO_ACESSO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
