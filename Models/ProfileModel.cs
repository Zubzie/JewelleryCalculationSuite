using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.Models
{
    public class ProfileModel
    {
        public string Shape { get; set; }

        public ProfileModel(string shape)
        {
            this.Shape = shape;
        }
    }
}
