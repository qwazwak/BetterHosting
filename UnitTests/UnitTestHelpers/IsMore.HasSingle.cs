using NUnit.Framework.Constraints;

namespace UnitTestHelpers;

public static class IsMore
{
    public static partial class HasSingle
    {
        public static Constraint SameAs(object same) => new AndConstraint(Has.Count.EqualTo(1), Has.All.SameAs(same));
    }
}