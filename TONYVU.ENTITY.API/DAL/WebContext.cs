using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.DAL
{
    public class WebContext:DbContext
    {
        public WebContext()
            : base("name=WebApplicationContext")
        {
            Database.SetInitializer<WebContext>(new CreateDatabaseIfNotExists<WebContext>());
        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<GroupRole> GroupRoles { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<TypeProduct> TypeProducts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }


    }
}
