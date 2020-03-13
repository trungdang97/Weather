using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;

namespace Weather.Data.V1
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            return new DataContext("");
        }
    }
    public class DataContext : DbContext
    {
        public DataContext(string prefix)
        {
            Prefix = prefix;
        }
        public string Prefix { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #region Config database
                var isTesting = (Utils.GetConfig("ConnectionString:IsTesting") == "HAS_TEST");
                if (isTesting)
                {
                    optionsBuilder.UseInMemoryDatabase("testDatabase");
                }
                else
                {
                    var dbType = Utils.GetConfig("ConnectionString:DbType");
                    switch (dbType)
                    {
                        case "MySqlPomeloDatabase":
                            optionsBuilder.UseMySql(Utils.GetConfig("ConnectionString:MySqlPomeloDatabase"));
                            break;
                        case "MSSQLDatabase":
                            optionsBuilder.UseSqlServer(Utils.GetConfig("ConnectionString:MSSQLDatabase"));
                            break;
                        case "OracleDatabase":
                            optionsBuilder.UseOracle(Utils.GetConfig("ConnectionString:OracleDatabase"));
                            break;
                        case "PostgreSQLDatabase":
                            optionsBuilder.UseNpgsql(Utils.GetConfig("ConnectionString:PostgreSQLDatabase"));
                            break;
                        default:
                            //optionsBuilder.UseSqlServer(Utils.GetConfig("ConnectionString:MSSQLDatabase"));
                            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=CMS_KTTV;Uid=sa;Pwd=admin@123;");
                            break;
                    }
                }

                #endregion




                optionsBuilder.ReplaceService<IModelCacheKeyFactory, DynamicModelCacheKeyFactory>();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CMS_NewsCategory>(entity =>
            {
                entity.HasKey(e => e.NewsCategoryId);
            });
        }

        public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }
        public virtual DbSet<AspnetRoles> AspnetRoles { get; set; }
        public virtual DbSet<AspnetUsers> AspnetUsers { get; set; }
        public virtual DbSet<AspnetUsersInRoles> AspnetUsersInRoles { get; set; }
        public virtual DbSet<CMS_Comment> CMS_Comments { get; set; }
        public virtual DbSet<CMS_News> CMS_News { get; set; }
        public virtual DbSet<CMS_NewsCategory> CMS_NewsCategories { get; set; }
        public virtual DbSet<CMS_Post> CMS_Posts { get; set; }
        public virtual DbSet<CMS_PostCategory> CMS_PostCategories { get; set; }
        public virtual DbSet<Idm_Right> Idm_Rights { get; set; }
        public virtual DbSet<Idm_RightsInRole> Idm_RightsInRoles { get; set; }
        public virtual DbSet<Idm_RightsOfUser> Idm_RightsOfUsers { get; set; }
        public virtual DbSet<Navigation> Navigations { get; set; }
        public virtual DbSet<NavigationRole> NavigationRoles {get;set;}
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<RightRole> RightRoles { get; set; }
    }

    public class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            if (context is DataContext dynamicContext)
            {
                return (context.GetType(), dynamicContext.Prefix);
            }
            return context.GetType();
        }
    }

    
}
