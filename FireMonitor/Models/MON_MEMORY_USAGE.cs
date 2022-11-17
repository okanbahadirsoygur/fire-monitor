using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireMonitor.Models
{
    [Table("MON$MEMORY_USAGE")]
    public class MON_MEMORY_USAGE
    {
        [Key]
        [Column("MON$STAT_ID")]
        public int? MON_STAT_ID { get; set; }

  
        [Column("MON$MEMORY_USED", TypeName = "bigint")]
        public int MON_MEMORY_USED { get; set; }

    }
}

