using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Implementation
{
    internal class MinimizedStandardTableEntry 
    {
        public BitArray CosetLeader { get; set; }
        public BitArray Syndrome { get; set; }
        public int Weight { get; set; }
    }
}
