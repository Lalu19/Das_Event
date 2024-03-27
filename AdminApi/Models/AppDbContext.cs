
using AdminApi.Models.App;
using AdminApi.Models.Helper;
using AdminApi.Models.Menu;
using AdminApi.Models.User;
using Microsoft.EntityFrameworkCore;
using System;



//using AdminApi.Models.App;

namespace AdminApi.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<LogHistory> LogHistory { get; set; }
        public virtual DbSet<AppMenu> Menu { get; set; }
        public virtual DbSet<MenuGroup> MenuGroup { get; set; }
        public virtual DbSet<MenuGroupWiseMenuMapping> MenuGroupWiseMenuMapping { get; set; }
        public virtual DbSet<DigitalCatalog> DigitalCatalogs { get; set; }
        public virtual DbSet<InnerPage> InnerPages { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   

            modelBuilder.Seed();//use this for Sql server,Mysql,Sqlite and PostgreSql
                                //modelBuilder.SeedOracle();//use this only for Oracle
            #region 
            //DigitalCatalogs

            modelBuilder.Entity<DigitalCatalog>()
            .Property(s => s.CreatedOn)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<DigitalCatalog>()
            .Property(s => s.IsDeleted)
            .HasDefaultValue(false)
            .ValueGeneratedNever();


            modelBuilder.Entity<InnerPage>()
           .Property(s => s.CreatedOn)
           .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InnerPage>()
            .Property(s => s.IsDeleted)
            .HasDefaultValue(false)
            .ValueGeneratedNever();

            #endregion
        }

    }
}
