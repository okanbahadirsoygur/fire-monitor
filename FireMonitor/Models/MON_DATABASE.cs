using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireMonitor.Models
{
    [Table("MON$DATABASE")]
    public class MON_DATABASE
    {
        [Key]
        [Column("MON$GUID")]
        public String? MON_GENUID { get; set; }

        [Column("MON$DATABASE_NAME")]
        public String? MON_DATABASE_NAME { get; set; }
     
    }
}

