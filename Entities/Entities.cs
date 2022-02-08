using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class AbstractBaseClass
    {
        public int Id { get; private set; }
        public int Something { get; private set; }

        public int? FooEntityId { get; private set; }
        public FooEntity? FooEntity { get; private set; }

        public abstract Discriminator Discriminator { get; protected set; }

    }

    public class DerivedClass : AbstractBaseClass
    {
        public OwnedType? OwnedType { get; private set; }
        public override Discriminator Discriminator { get; protected set; } = Discriminator.DerivedClass;
    }

    public class DerivedDerivedClass : DerivedClass
    {
        public int JustSomePropertyInDerivedDerivedClass { get; set; }
        public override Discriminator Discriminator { get; protected set; } = Discriminator.DerivedDerivedClass;
    }

    public class OwnedType
    {
        public int Something { get; set; }
    }

    public class FooEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
    }

    public enum Discriminator
    {
        DerivedClass,
        DerivedDerivedClass
    }
}
