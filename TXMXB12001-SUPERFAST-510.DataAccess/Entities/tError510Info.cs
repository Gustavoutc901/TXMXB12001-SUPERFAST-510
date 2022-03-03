using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TXMXB12001_SUPERFAST_510.DataAccess.DB
{
    public partial class tError510Info
    {
        [Key]
        public Guid IdtError510Info { get; set; }
        public Guid IdHeader510 { get; set; }
        [Required]
        [StringLength(100)]
        public string Field { get; set; }
        [StringLength(50)]
        public string Value { get; set; }
        public int StartLine { get; set; }
        public int EndLine { get; set; }
        public int Line { get; set; }
        [Required]
        public string Text { get; set; }

        [ForeignKey(nameof(IdHeader510))]
        [InverseProperty(nameof(tHeader510.tError510Info))]
        public virtual tHeader510 IdHeader510Navigation { get; set; }
    }
}
