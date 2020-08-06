using Microsoft.EntityFrameworkCore;
using StunasMobile.Entities.Entitites;

#nullable disable

namespace StunasMobile.Data.DbContext
{
    public partial class StunasDBContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StunasDBContext()
        {
        }

        public StunasDBContext(DbContextOptions<StunasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mobile> Mobiles { get; set; }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mobile>(entity =>
            {
                entity.ToTable("mobile");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Codeclient)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("codeclient");

                entity.Property(e => e.Data)
                    .HasMaxLength(20)
                    .HasColumnName("data");

                entity.Property(e => e.Forfait)
                    .HasMaxLength(50)
                    .HasColumnName("forfait");

                entity.Property(e => e.Handset)
                    .HasMaxLength(50)
                    .HasColumnName("handset");

                entity.Property(e => e.Montant)
                    .HasMaxLength(50)
                    .HasColumnName("montant");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .HasColumnName("nom");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Prixhandset)
                    .HasMaxLength(20)
                    .HasColumnName("prixhandset");

                entity.Property(e => e.Site)
                    .HasMaxLength(50)
                    .HasColumnName("site");

                entity.Property(e => e.Sociéte)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("sociéte");
            });

            OnModelCreatingPartial(modelBuilder);
        }

     
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
