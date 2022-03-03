using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXMXB12001_SUPERFAST_510.DataAccess.DB
{
    public partial class tError510
    {
        [Key]
        public Guid IdError510 { get; set; }
        public Guid IdHeader510 { get; set; }
        public int Line { get; set; }
        public int Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
        public int CreateUser { get; set; }
        public int? UpdateUser { get; set; }

        [ForeignKey(nameof(IdHeader510))]
        [InverseProperty(nameof(tHeader510.tError510))]
        public virtual tHeader510 IdHeader510Navigation { get; set; }
    }
}
