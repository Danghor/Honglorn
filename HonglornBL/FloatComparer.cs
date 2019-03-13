using System;
using System.Collections.Generic;

namespace HonglornBL
{
    class FloatComparer : IEqualityComparer<float?>
    {
        public bool Equals(float? left, float? right) => left == null && right == null || left != null && right != null && Math.Abs(left.Value - right.Value) < float.Epsilon;

        public int GetHashCode(float? obj)
        {
            throw new NotImplementedException();
        }
    }
}