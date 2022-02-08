using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efcore6_table_splitting_owned_entities_issue
{
    public class FooEntityMap : IEntityTypeConfiguration<FooEntity>
    {
        public void Configure(EntityTypeBuilder<FooEntity> builder)
        {
            builder.ToTable("Foo");

            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name).IsRequired(false);
        }
    }
}
