using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore6_table_splitting_owned_entities_issue
{
    public class AbstractBaseClassMap : IEntityTypeConfiguration<AbstractBaseClass>
    {
        public void Configure(EntityTypeBuilder<AbstractBaseClass> builder)
        {
            builder.ToTable("SomeEntity");

            builder.HasKey(c => c.Id);

            builder.HasOne(x => x.FooEntity)
                .WithMany()
                .HasForeignKey(d => d.FooEntityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasDiscriminator(d => d.Discriminator)
                .HasValue<DerivedClass>(Discriminator.DerivedClass)
                .HasValue<DerivedDerivedClass>(Discriminator.DerivedDerivedClass);
        }

        internal void ConfigureDerivedClasses(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DerivedDerivedClass>()
                .OwnsOne(d => d.OwnedType, navigationBuilder =>
                {
                    navigationBuilder.Property(x => x.Something)
                        .HasColumnName("Something")
                        .IsRequired();
                })
                .Property(x => x.JustSomePropertyInDerivedDerivedClass)
                    .HasColumnName("JustSomePropertyInDerivedDerivedClass");

            modelBuilder.Entity<DerivedClass>()
                .OwnsOne(d => d.OwnedType, navigationBuilder =>
                {
                    navigationBuilder.Property(x => x.Something)
                        .HasColumnName("Something")
                        .IsRequired();
                });
        }

    }
}
