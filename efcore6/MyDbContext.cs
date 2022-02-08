using Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore6
{
    public class MyDbContext : DbContext
    {

        public DbSet<AbstractBaseClass> AbstractEntities { get; private set; }
        public DbSet<FooEntity> FooEntities { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var abstractEntitiesMap = new EntityTypeMappings();

            modelBuilder.ApplyConfiguration(abstractEntitiesMap);
            modelBuilder.ApplyConfiguration(new FooEntityMap());

            abstractEntitiesMap.ConfigureDerivedClasses(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
