using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXMXB12001_SUPERFAST_510.DataAccess.DB
{
    public partial class tHeader510
    {
        public tHeader510()
        {
            tDetalle510 = new HashSet<tDetalle510>();
            tError510 = new HashSet<tError510>();
            tError510Info = new HashSet<tError510Info>();
        }

        [Key]
        public Guid IdHeader510 { get; set; }
        [StringLength(200)]
        public string NameFile { get; set; }
        public int? IdStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateProcessing { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateProcess { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }

        
        [InverseProperty("IdHeader510Navigation")]
        public virtual ICollection<tDetalle510> tDetalle510 { get; set; }
        [InverseProperty("IdHeader510Navigation")]
        public virtual ICollection<tError510> tError510 { get; set; }
        [InverseProperty("IdHeader510Navigation")]
        public virtual ICollection<tError510Info> tError510Info { get; set; }
    }
}
