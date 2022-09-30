using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryProgramV3
{
    internal class RingSize
    {
        public string LetterSize;
        public double NumberSize;
        public double Diameter;

        public RingSize(string letterSize, double numberSize, double diameter)
        {
            this.LetterSize = letterSize;
            this.NumberSize = numberSize;
            this.Diameter = diameter;
        }
    }
}
