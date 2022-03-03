

namespace TXMXB12001_SUPERFAST_510.DataAccess.DataBase
{
    #region Using's
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    #endregion Using's
    /// <summary>
    ///
    /// </summary>
    public partial class ContextDb
    {
        #region Members
        /// <summary>
        ///
        /// </summary>
        public string connectionString = string.Empty;
        public string PathFile = string.Empty;

        #endregion Members
        #region Public Methods
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            AddAuditInfo();
            return base.SaveChanges();
        }
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            AddAuditInfo();
            return await base.SaveChangesAsync();
        }
        #endregion Public Methods
        #region Private Methods
        /// <summary>
        ///
        /// </summary>
        private void AddAuditInfo()
        {
            IEnumerable<EntityEntry> entries = ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    PropertyInfo propertyInfoCreateDate = entry.Entity.GetType().GetProperty("CreateDate");
                    if (propertyInfoCreateDate != null)
                    {
                        propertyInfoCreateDate.SetValue(entry.Entity, DateTime.Now);
                    }
                }
                PropertyInfo propertyInfoUpdateDate = entry.Entity.GetType().GetProperty("UpdateDate");
                if (propertyInfoUpdateDate != null)
                {
                    propertyInfoUpdateDate.SetValue(entry.Entity, DateTime.Now);
                }
            }
        }
        /// <summary>
        ///
        /// </summary>
        private void GetConnectionString()
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false)
                .Build();
#if DEBUG
            connectionString = configurationRoot.GetConnectionString("Dev");
#else
                connectionString = configurationRoot.GetConnectionString("QA");
#endif
        }

        #endregion Private Methods

    }
}

