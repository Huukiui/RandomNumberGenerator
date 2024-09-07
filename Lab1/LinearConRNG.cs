using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class LinearCongruentialGenerator
    {
        private long _seed;
        private long _a;
        private long _c;
        private long _m;

        public LinearCongruentialGenerator(long a, long c, long m, long seed)
        {
            _a = a;
            _c = c;
            _m = m;
            _seed = seed;
        }

        public long Next()
        {
            _seed = (_a * _seed + _c) % _m;
            return _seed;
        }
    }
}
