// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using efcore5;

namespace efcore5.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Entities.AbstractBaseClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Discriminator")
                        .HasColumnType("int");

                    b.Property<int?>("FooEntityId")
                        .HasColumnType("int");

                    b.Property<int>("Something")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FooEntityId");

                    b.ToTable("SomeEntity");

                    b.HasDiscriminator<int>("Discriminator");
                });

            modelBuilder.Entity("Entities.FooEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foo");
                });

            modelBuilder.Entity("Entities.DerivedClass", b =>
                {
                    b.HasBaseType("Entities.AbstractBaseClass");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("Entities.DerivedDerivedClass", b =>
                {
                    b.HasBaseType("Entities.DerivedClass");

                    b.Property<int>("JustSomePropertyInDerivedDerivedClass")
                        .HasColumnType("int")
                        .HasColumnName("JustSomePropertyInDerivedDerivedClass");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Entities.AbstractBaseClass", b =>
                {
                    b.HasOne("Entities.FooEntity", "FooEntity")
                        .WithMany()
                        .HasForeignKey("FooEntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FooEntity");
                });

            modelBuilder.Entity("Entities.DerivedClass", b =>
                {
                    b.OwnsOne("Entities.OwnedType", "OwnedType", b1 =>
                        {
                            b1.Property<int>("DerivedClassId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .UseIdentityColumn();

                            b1.Property<int>("SomePropertyInOwnedType")
                                .HasColumnType("int")
                                .HasColumnName("SomePropertyInOwnedType");

                            b1.HasKey("DerivedClassId");

                            b1.ToTable("SomeEntity");

                            b1.WithOwner()
                                .HasForeignKey("DerivedClassId");
                        });

                    b.Navigation("OwnedType");
                });
#pragma warning restore 612, 618
        }
    }
}
