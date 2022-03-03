using Microsoft.EntityFrameworkCore;
using TXMXB12001_SUPERFAST_510.DataAccess.DB;

//GetConnectionString();
//optionsBuilder.UseSqlServer(connectionString);

namespace TXMXB12001_SUPERFAST_510.DataAccess.DataBase
{
    public partial class ContextDb : DbContext
    {
        public ContextDb()
        {
            GetConnectionString();
        }

        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
            GetConnectionString();
        }

        public virtual DbSet<tAnexo510> tAnexo510 { get; set; }
        public virtual DbSet<tDetalle510> tDetalle510 { get; set; }
        public virtual DbSet<tError510> tError510 { get; set; }
        public virtual DbSet<tError510Info> tError510Info { get; set; }
        public virtual DbSet<tHeader510> tHeader510 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tAnexo510>(entity =>
            {
                entity.HasKey(e => e.IdAnexo510)
                    .HasName("PK_tAnexo510_1");

                entity.Property(e => e.IdAnexo510).ValueGeneratedNever();

                entity.Property(e => e.AmountAuthorized).IsUnicode(false);

                entity.Property(e => e.AmountOther).IsUnicode(false);

                entity.Property(e => e.AplicationTransactionCounter).IsUnicode(false);

                entity.Property(e => e.ApplicationC).IsUnicode(false);

                entity.Property(e => e.ApplicationInterchangeProfile).IsUnicode(false);

                entity.Property(e => e.CardholderVerificationMethod).IsUnicode(false);

                entity.Property(e => e.Cryptogram).IsUnicode(false);

                entity.Property(e => e.DedicatedFileName).IsUnicode(false);

                entity.Property(e => e.InterfaceDeviceSerialNumber).IsUnicode(false);

                entity.Property(e => e.IssuerAD).IsUnicode(false);

                entity.Property(e => e.IssuerAuthenticationData).IsUnicode(false);

                entity.Property(e => e.NoAutorizacion).IsUnicode(false);

                entity.Property(e => e.NoCuenta).IsUnicode(false);

                entity.Property(e => e.TeminalCapabilities).IsUnicode(false);

                entity.Property(e => e.TerminalApplicationVersionNumber).IsUnicode(false);

                entity.Property(e => e.TerminalCountryCode).IsUnicode(false);

                entity.Property(e => e.TerminalType).IsUnicode(false);

                entity.Property(e => e.TerminalVerificationResult).IsUnicode(false);

                entity.Property(e => e.TipoRegistro).IsUnicode(false);

                entity.Property(e => e.TransactionCurrencyCode).IsUnicode(false);

                entity.Property(e => e.TransactionDate).IsUnicode(false);

                entity.Property(e => e.TransactionType).IsUnicode(false);

                entity.Property(e => e.UnpredictableNumber).IsUnicode(false);

                entity.HasOne(d => d.IdDetalle510Navigation)
                    .WithMany(p => p.tAnexo510)
                    .HasForeignKey(d => d.IdDetalle510)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tAnexo510_tDetalle5101");
            });

            modelBuilder.Entity<tDetalle510>(entity =>
            {
                entity.Property(e => e.IdDetalle510).ValueGeneratedNever();

                entity.Property(e => e.AuthenticationCollectorIndicator).IsUnicode(false);

                entity.Property(e => e.Clavecomercio).IsUnicode(false);

                entity.Property(e => e.CodigoPostal).IsUnicode(false);

                entity.Property(e => e.ComercioElectroniCoidct).IsUnicode(false);

                entity.Property(e => e.ComercioElectronicoIcavv).IsUnicode(false);

                entity.Property(e => e.ComercioElectronicoIce).IsUnicode(false);

                entity.Property(e => e.ComercioElectronicoIta).IsUnicode(false);

                entity.Property(e => e.ComercioElectronicoTc).IsUnicode(false);

                entity.Property(e => e.ComercioElectronicoTid).IsUnicode(false);

                entity.Property(e => e.DireccionComercio).IsUnicode(false);

                entity.Property(e => e.EstatusComercio).IsUnicode(false);

                entity.Property(e => e.FamiliaComercio).IsUnicode(false);

                entity.Property(e => e.FiidAdquiriente).IsUnicode(false);

                entity.Property(e => e.FiidEmisor).IsUnicode(false);

                entity.Property(e => e.IndicadorCV2).IsUnicode(false);

                entity.Property(e => e.IndicadorMedioAcceso).IsUnicode(false);

                entity.Property(e => e.IndicadorPagoInterbancario).IsUnicode(false);

                entity.Property(e => e.MarcaProducto).IsUnicode(false);

                entity.Property(e => e.MccoGiroComercio).IsUnicode(false);

                entity.Property(e => e.NaturalezaContable).IsUnicode(false);

                entity.Property(e => e.NoCuenta).IsUnicode(false);

                entity.Property(e => e.NombreComercio).IsUnicode(false);

                entity.Property(e => e.NumeroAutorizacion).IsUnicode(false);

                entity.Property(e => e.PaisOrigenTX).IsUnicode(false);

                entity.Property(e => e.PoblacionComercio).IsUnicode(false);

                entity.Property(e => e.RFCComercio).IsUnicode(false);

                entity.Property(e => e.ReferenciaTransaccion).IsUnicode(false);

                entity.Property(e => e.ServiceCode).IsUnicode(false);

                entity.HasOne(d => d.IdHeader510Navigation)
                    .WithMany(p => p.tDetalle510)
                    .HasForeignKey(d => d.IdHeader510)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tDetalle510_tHeader510");
            });

            modelBuilder.Entity<tError510>(entity =>
            {
                entity.HasKey(e => e.IdError510)
                    .HasName("PK_tError510_1");

                entity.Property(e => e.IdError510).ValueGeneratedNever();

                entity.HasOne(d => d.IdHeader510Navigation)
                    .WithMany(p => p.tError510)
                    .HasForeignKey(d => d.IdHeader510)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tError510_tHeader510");
            });

            modelBuilder.Entity<tError510Info>(entity =>
            {
                entity.HasKey(e => e.IdtError510Info)
                    .HasName("PK_tError510Info_1");

                entity.Property(e => e.IdtError510Info).ValueGeneratedNever();

                entity.Property(e => e.Field).IsUnicode(false);

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.IdHeader510Navigation)
                    .WithMany(p => p.tError510Info)
                    .HasForeignKey(d => d.IdHeader510)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tError510Info_tHeader510");
            });

            modelBuilder.Entity<tHeader510>(entity =>
            {
                entity.Property(e => e.IdHeader510).ValueGeneratedNever();

                entity.Property(e => e.NameFile).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
