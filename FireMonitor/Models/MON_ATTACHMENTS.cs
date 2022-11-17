using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FireMonitor.Models
{
    [Table("MON$ATTACHMENTS")]
    public class MON_ATTACHMENTS
    {
        [Key]
        [Column("MON$ATTACHMENT_ID")]
        public int? MON_ATTACHMENT_ID { get; set; }

        [Column("MON$ATTACHMENT_NAME")]
        public string? MON_ATTACHMENT_NAME {get;set;}


        [Column("MON$REMOTE_HOST")]
        public string? MON_REMOTE_HOST { get; set; }

        [Column("MON$REMOTE_ADDRESS")]
        public string? MON_REMOTE_ADDRESS { get; set; }


        [Column("MON$REMOTE_OS_USER")]
        public string? MON_REMOTE_OS_USER{ get; set; }


        [Column("MON$TIMESTAMP")]
        public DateTime? MON_TIMESTAMP { get; set; }

        [Column("MON$CLIENT_VERSION")]
        public String? MON_CLIENT_VERSION { get; set; }

        [Column("MON$USER")]
        public String? MON_USER{ get; set; }

        [Column("MON$REMOTE_PROCESS")]
        public String? MON_REMOTE_PROCESS { get; set; }

        [Column("MON$REMOTE_VERSION")]
        public String? MON_REMOTE_VERSION { get; set; }

        [Column("MON$STAT_ID")]
        public int? MON_STAT_ID { get; set; }

        [Column("MON$REMOTE_PID")]
        public int? MON_REMOTE_PID { get; set; }
    }
}

