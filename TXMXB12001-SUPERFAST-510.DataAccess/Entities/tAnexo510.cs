using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXMXB12001_SUPERFAST_510.DataAccess.DB
{
    public partial class tAnexo510
    {
        [Key]
        public Guid IdAnexo510 { get; set; }
        public Guid IdDetalle510 { get; set; }
        [Required]
        [StringLength(300)]
        public string NoAutorizacion { get; set; }
        [Required]
        [StringLength(300)]
        public string NoCuenta { get; set; }
        [Required]
        [StringLength(300)]
        public string TipoRegistro { get; set; }
        [Required]
        [StringLength(300)]
        public string ApplicationC { get; set; }
        [Required]
        [StringLength(300)]
        public string Cryptogram { get; set; }
        [Required]
        [StringLength(300)]
        public string IssuerAD { get; set; }
        [Required]
        [StringLength(300)]
        public string UnpredictableNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string AplicationTransactionCounter { get; set; }
        [Required]
        [StringLength(300)]
        public string TerminalVerificationResult { get; set; }
        [Required]
        [StringLength(300)]
        public string TransactionDate { get; set; }
        [Required]
        [StringLength(300)]
        public string TransactionType { get; set; }
        [Required]
        [StringLength(300)]
        public string AmountAuthorized { get; set; }
        [Required]
        [StringLength(300)]
        public string TransactionCurrencyCode { get; set; }
        [Required]
        [StringLength(300)]
        public string ApplicationInterchangeProfile { get; set; }
        [Required]
        [StringLength(300)]
        public string TerminalCountryCode { get; set; }
        [Required]
        [StringLength(300)]
        public string AmountOther { get; set; }
        [Required]
        [StringLength(300)]
        public string CardholderVerificationMethod { get; set; }
        [Required]
        [StringLength(300)]
        public string TeminalCapabilities { get; set; }
        [Required]
        [StringLength(300)]
        public string TerminalType { get; set; }
        [Required]
        [StringLength(300)]
        public string InterfaceDeviceSerialNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string DedicatedFileName { get; set; }
        [Required]
        [StringLength(300)]
        public string TerminalApplicationVersionNumber { get; set; }
        [Required]
        [StringLength(300)]
        public string IssuerAuthenticationData { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }

        [ForeignKey(nameof(IdDetalle510))]
        [InverseProperty(nameof(tDetalle510.tAnexo510))]
        public virtual tDetalle510 IdDetalle510Navigation { get; set; }
    }
}
