using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryProgramV3
{
    internal class Metal
    {
        public string Name { get; set; }
        public double SpecificGravity { get; set; }

        public Metal(string name, double specificGravity)
        {
            this.Name = name;
            this.SpecificGravity = specificGravity;
        }
    }
}
