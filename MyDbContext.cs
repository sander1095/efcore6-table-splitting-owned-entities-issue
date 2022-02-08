using Microsoft.EntityFrameworkCore;

namespace efcore6_table_splitting_owned_entities_issue
{
    public class MyDbContext : DbContext
    {

        public DbSet<AbstractBaseClass> AbstractEntities { get; private set; }
        public DbSet<FooEntity> FooEntities { get; set; }

        public MyDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var abstractEntitiesMap = new AbstractBaseClassMap();
            abstractEntitiesMap.ConfigureDerivedClasses(modelBuilder);

            modelBuilder.ApplyConfiguration(abstractEntitiesMap);

            modelBuilder.ApplyConfiguration(new FooEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
