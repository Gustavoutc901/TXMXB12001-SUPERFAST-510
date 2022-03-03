using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXMXB12001_SUPERFAST_510.DataAccess.DB
{
    public partial class tDetalle510
    {
        public tDetalle510()
        {
            tAnexo510 = new HashSet<tAnexo510>();
        }

        [Key]
        public Guid IdDetalle510 { get; set; }
        public Guid IdHeader510 { get; set; }
        public long Bancoemisor { get; set; }
        public long? IdCardCipher { get; set; }
        [Required]
        [StringLength(300)]
        public string NoCuenta { get; set; }
        [Required]
        [StringLength(300)]
        public string NaturalezaContable { get; set; }
        [Required]
        [StringLength(300)]
        public string MarcaProducto { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaConsumo { get; set; }
        public TimeSpan? HoraConsumo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaProceso { get; set; }
        public long TipoTransaccion { get; set; }
        public long NumeroLiquidacion { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteOrigenTotal { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteOrigenConsumo { get; set; }
        public long ClaveMonedaImporteOrigen { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteDestinoTotal { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteDestinoConsumo { get; set; }
        public long ClaveMonedaDestino { get; set; }
        [Column(TypeName = "decimal(7, 4)")]
        public decimal ParidadDestino { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteLiquidacionTotal { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal ImporteLiquidacionConsumo { get; set; }
        public long ClaveMonedaLiquidacion { get; set; }
        [Column(TypeName = "decimal(7, 4)")]
        public decimal ParidadLiquidacion { get; set; }
        [Column(TypeName = "decimal(17, 6)")]
        public decimal? ImporteCuotaIntercambio { get; set; }
        [Column(TypeName = "decimal(17, 6)")]
        public decimal? IvaCuotaIntercambio { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal? ImporteCalculadoParaAplicacionTH { get; set; }
        [Column(TypeName = "decimal(13, 2)")]
        public decimal? ImporteCalculadoAplicacionTH { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PorcentajeComisionAplicacionTH { get; set; }
        [Required]
        [StringLength(300)]
        public string Clavecomercio { get; set; }
        [StringLength(300)]
        public string MccoGiroComercio { get; set; }
        [StringLength(300)]
        public string NombreComercio { get; set; }
        [StringLength(300)]
        public string DireccionComercio { get; set; }
        [Required]
        [StringLength(300)]
        public string PaisOrigenTX { get; set; }
        [StringLength(300)]
        public string CodigoPostal { get; set; }
        [StringLength(300)]
        public string PoblacionComercio { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal PorcentajeCuotaIntercambio { get; set; }
        [StringLength(300)]
        public string FamiliaComercio { get; set; }
        [StringLength(300)]
        public string RFCComercio { get; set; }
        [StringLength(300)]
        public string EstatusComercio { get; set; }
        public long NumeroFuente { get; set; }
        [Required]
        [StringLength(300)]
        public string NumeroAutorizacion { get; set; }
        public long BancoReceptor { get; set; }
        [Required]
        [StringLength(300)]
        public string ReferenciaTransaccion { get; set; }
        public long? ModoAutorizacion { get; set; }
        [Required]
        [StringLength(300)]
        public string IndicadorMedioAcceso { get; set; }
        public long PagosDiferidos { get; set; }
        public long PagosDiferidosParcializacion { get; set; }
        public long PagosDiferidosTipoPlan { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Sobretasa { get; set; }
        [Column(TypeName = "decimal(7, 2)")]
        public decimal? IvaSobretasa { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? PorcentajeSobreTasa { get; set; }
        public long PagosDiferidosIndicadorCobroA { get; set; }
        [Required]
        [StringLength(300)]
        public string FiidEmisor { get; set; }
        [StringLength(300)]
        public string ComercioElectroniCoidct { get; set; }
        [StringLength(300)]
        public string ComercioElectronicoIce { get; set; }
        [StringLength(300)]
        public string AuthenticationCollectorIndicator { get; set; }
        [StringLength(300)]
        public string ComercioElectronicoTc { get; set; }
        [StringLength(300)]
        public string ComercioElectronicoIta { get; set; }
        [StringLength(300)]
        public string ComercioElectronicoTid { get; set; }
        public long? PosentryMode { get; set; }
        [StringLength(300)]
        public string IndicadorCV2 { get; set; }
        [StringLength(300)]
        public string ComercioElectronicoIcavv { get; set; }
        [Required]
        [StringLength(300)]
        public string FiidAdquiriente { get; set; }
        [StringLength(300)]
        public string IndicadorPagoInterbancario { get; set; }
        [StringLength(300)]
        public string ServiceCode { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }
        [StringLength(300)]
        public string DescrpEstado { get; set; }
        [ForeignKey(nameof(IdHeader510))]
        [InverseProperty(nameof(tHeader510.tDetalle510))]
        public virtual tHeader510 IdHeader510Navigation { get; set; }
        [InverseProperty("IdDetalle510Navigation")]
        public virtual ICollection<tAnexo510> tAnexo510 { get; set; }
    }
}
