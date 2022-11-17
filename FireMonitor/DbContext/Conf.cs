using System;
using System.Data.Entity;
using EntityFramework.Firebird;

namespace FireMonitor.DbContextContext
{
    public class Conf : DbConfiguration
    {
        public Conf() 
        {
            SetProviderServices(FbProviderServices.ProviderInvariantName, FbProviderServices.Instance);
        }
    }
}

