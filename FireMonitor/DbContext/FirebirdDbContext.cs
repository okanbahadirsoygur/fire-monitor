using System;
using System.Data.Entity;
using FirebirdSql.Data.FirebirdClient;
using FireMonitor.Models;

namespace FireMonitor.DbContextContext
{
    public class FirebirdDbContext: DbContext
    {
        public DbSet<MON_DATABASE> MON_DATABASE { get; set; }
        public DbSet<MON_ATTACHMENTS> MON_ATTACHMENTS { get; set; }
        public DbSet<MON_MEMORY_USAGE> MON_MEMORY_USAGE { get; set; }
        
        public FirebirdDbContext(string? con = "database=localhost:/firebird/data/altindag.fdb;user=sysdba;password=") : base (new FbConnection(con), true)
        { }
    }
}

