using System.Collections.Generic;
using System.Linq;

namespace Kanban.SharedKernel
{
    public abstract class ValueObject
    {
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            using (var thisValues = GetAtomicValues().GetEnumerator())
            {
                using (var otherValues = other.GetAtomicValues().GetEnumerator())
                {
                    while (thisValues.MoveNext() && otherValues.MoveNext())
                    {
                        if (ReferenceEquals(thisValues.Current, null) ^
                            ReferenceEquals(otherValues.Current, null))
                        {
                            return false;
                        }

                        if (thisValues.Current != null &&
                            !thisValues.Current.Equals(otherValues.Current))
                        {
                            return false;
                        }
                    }
                    return !thisValues.MoveNext() && !otherValues.MoveNext();
                }
            }
        }

        public override int GetHashCode()
        {
            var hash = GetAtomicValues().Aggregate(42, (current, atomicValue) => current * 7 + atomicValue.GetHashCode());
            return hash;
        }
    }
}
