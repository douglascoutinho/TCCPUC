using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RiscSegPre.Infra.Data.Context
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartamento> Apartamento { get; set; }
        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<BatalhaoPoliciaMilitar> BatalhaoPoliciaMilitar { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DelegaciaPoliciaCivil> DelegaciaPoliciaCivil { get; set; }
        public virtual DbSet<Inspecao> Inspecao { get; set; }
        public virtual DbSet<NotaAvaliacaoProcedimento> NotaAvaliacaoProcedimento { get; set; }
        public virtual DbSet<NotaMeioProtecaoFisico> NotaMeioProtecaoFisico { get; set; }
        public virtual DbSet<NotaMeioProtecaoHumano> NotaMeioProtecaoHumano { get; set; }
        public virtual DbSet<NotaMeioProtecaoTecnico> NotaMeioProtecaoTecnico { get; set; }
        public virtual DbSet<Predio> Predio { get; set; }
        public virtual DbSet<Risco> Risco { get; set; }

        public override int SaveChanges()
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dt_cadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("dt_cadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("dt_cadastro").IsModified = false;
                    }
                }
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro - Classe: DataContext Método: SaveChanges");
            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dt_cadastro") != null))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Property("dt_cadastro").CurrentValue = DateTime.Now;
                    }

                    if (entry.State == EntityState.Modified)
                    {
                        entry.Property("dt_cadastro").IsModified = false;
                    }
                }

                return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Erro - Clase: DataContext Método: SaveChangesAsync");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=webContext");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartamento>(entity =>
            {
                entity.HasKey(e => e.id_apartamento)
                    .HasName("PK__Apartame__0440E1AD7C6E3B50");

                entity.Property(e => e.nm_apartamento)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.numero).HasMaxLength(100);

                entity.HasOne(d => d.id_predioNavigation)
                    .WithMany(p => p.Apartamento)
                    .HasForeignKey(d => d.id_predio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Predio_Apartamento");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.id_bairro)
                    .HasName("PK__Bairro__26E7F1296A7DDD5A");

                entity.Property(e => e.nm_bairro)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.aisp)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cidade)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.cisp)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.dt_cadastro).HasColumnType("datetime");

                entity.Property(e => e.estado)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ocorrencias)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.risp)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.id_batalhaoNavigation)
                    .WithMany(p => p.Bairro)
                    .HasForeignKey(d => d.id_batalhao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Batalhao_Bairro");

                entity.HasOne(d => d.id_delegaciaNavigation)
                    .WithMany(p => p.Bairro)
                    .HasForeignKey(d => d.id_delegacia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Delegacia_Bairro");

                entity.HasOne(d => d.id_riscoNavigation)
                    .WithMany(p => p.Bairro)
                    .HasForeignKey(d => d.id_risco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Risco_Bairro");
            });

            modelBuilder.Entity<BatalhaoPoliciaMilitar>(entity =>
            {
                entity.HasKey(e => e.id_batalhao)
                    .HasName("PK__Batalhao__FCB9872BE9515CA8");

                entity.Property(e => e.bairro).HasMaxLength(100);

                entity.Property(e => e.cep).HasMaxLength(100);

                entity.Property(e => e.cidade).HasMaxLength(100);

                entity.Property(e => e.complemento).HasMaxLength(100);

                entity.Property(e => e.ds_delegacia).HasMaxLength(100);

                entity.Property(e => e.estado).HasMaxLength(100);

                entity.Property(e => e.logradouro).HasMaxLength(100);

                entity.Property(e => e.numero).HasMaxLength(100);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.id_cliente)
                    .HasName("PK__Cliente__677F38F5BB32414F");

                entity.Property(e => e.nm_cliente)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DelegaciaPoliciaCivil>(entity =>
            {
                entity.HasKey(e => e.id_delegacia)
                    .HasName("PK__Delegaci__2D23EF659056BA89");

                entity.Property(e => e.bairro).HasMaxLength(100);

                entity.Property(e => e.cep).HasMaxLength(100);

                entity.Property(e => e.cidade).HasMaxLength(100);

                entity.Property(e => e.complemento).HasMaxLength(100);

                entity.Property(e => e.ds_delegacia).HasMaxLength(100);

                entity.Property(e => e.estado).HasMaxLength(100);

                entity.Property(e => e.logradouro).HasMaxLength(100);

                entity.Property(e => e.numero).HasMaxLength(100);
            });

            modelBuilder.Entity<Inspecao>(entity =>
            {
                entity.HasKey(e => e.id_inspecao)
                    .HasName("PK__Inspecao__34BA55287513496D");

                entity.Property(e => e.distanciaComunidade)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.dt_cadastro).HasColumnType("datetime");

                entity.Property(e => e.fotoApartamento)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.fotoPredio)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.motivoReprovacao).HasMaxLength(100);

                entity.Property(e => e.nota).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.situacao)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.id_apartamentoNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_apartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_Apartamento");

                entity.HasOne(d => d.id_bairroNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_bairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_Bairro");

                entity.HasOne(d => d.id_clienteNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_cliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_Cliente");

                entity.HasOne(d => d.id_notaAvaliacaoProcedimentoNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_notaAvaliacaoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_NotaAvaliacaoProcedimento");

                entity.HasOne(d => d.id_notaMeioProtecaoFisicoNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_notaMeioProtecaoFisico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_NotaMeioProtecaoFisico");

                entity.HasOne(d => d.id_notaMeioProtecaoHumanoNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_notaMeioProtecaoHumano)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_NotaMeioProtecaoHumano");

                entity.HasOne(d => d.id_notaMeioProtecaoTecnicoNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_notaMeioProtecaoTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_NotaMeioProtecaoTecnico");

                entity.HasOne(d => d.id_predioNavigation)
                    .WithMany(p => p.Inspecao)
                    .HasForeignKey(d => d.id_predio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inspecao_Predio");
            });

            modelBuilder.Entity<NotaAvaliacaoProcedimento>(entity =>
            {
                entity.HasKey(e => e.id_notaAvaliacaoProcedimento)
                    .HasName("PK__NotaAval__BD6D40AA920EF87B");
            });

            modelBuilder.Entity<NotaMeioProtecaoFisico>(entity =>
            {
                entity.HasKey(e => e.id_notaMeioProtecaoFisico)
                    .HasName("PK__NotaMeio__EB8732599DEEEC5B");
            });

            modelBuilder.Entity<NotaMeioProtecaoHumano>(entity =>
            {
                entity.HasKey(e => e.id_notaMeioProtecaoHumano)
                    .HasName("PK__NotaMeio__9D893953AD5E9E6A");
            });

            modelBuilder.Entity<NotaMeioProtecaoTecnico>(entity =>
            {
                entity.HasKey(e => e.id_notaMeioProtecaoTecnico)
                    .HasName("PK__NotaMeio__3C0114FF72322BBE");
            });

            modelBuilder.Entity<Predio>(entity =>
            {
                entity.HasKey(e => e.id_predio)
                    .HasName("PK__Predio__A7C80C247AB6D62D");

                entity.Property(e => e.bairro).HasMaxLength(100);

                entity.Property(e => e.cep).HasMaxLength(100);

                entity.Property(e => e.cidade).HasMaxLength(100);

                entity.Property(e => e.complemento).HasMaxLength(100);

                entity.Property(e => e.estado).HasMaxLength(100);

                entity.Property(e => e.logradouro).HasMaxLength(100);

                entity.Property(e => e.nm_predio)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.numero).HasMaxLength(100);
            });

            modelBuilder.Entity<Risco>(entity =>
            {
                entity.HasKey(e => e.id_risco)
                    .HasName("PK__Risco__5D916D405FCF52A7");

                entity.Property(e => e.ds_risco).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
