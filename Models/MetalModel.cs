using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.Models
{
    public class MetalModel
    {
        public string Name { get; set; }
        public double SpecificGravity { get; set; }

        public MetalModel(string name, double specificGravity)
        {
            this.Name = name;
            this.SpecificGravity = specificGravity;
        }
    }
}
