using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOO_Rul
{
    public class Db: DbContext
    {
        public DbSet<ProductClass> ProductClasc { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"192.168.200.35";
            //sb.InitialCatalog = "192.168.200.35";
            sb.ApplicationName = "user03";
            sb.Password = "97965";
            sb.IntegratedSecurity = true;
            optionsBuilder.UseSqlServer(sb.ToString());
            base.OnConfiguring(optionsBuilder);
        }
        static Db db;
         public static Db GetDb()
        {
            if (db == null)
                db = new Db();
            return db;
        }
    }
}
