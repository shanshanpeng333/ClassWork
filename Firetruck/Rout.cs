using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firetruck
{
    public class Rout
    {
        public int StartNode { get; set; }
        public int EndNode { get; set; }

        public override string ToString() => $"{StartNode} | {EndNode}";
    }
}
