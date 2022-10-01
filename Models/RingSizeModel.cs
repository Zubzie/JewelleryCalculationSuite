using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.Models
{
    public class RingSizeModel
    {
        public string LetterSize;
        public double NumberSize;
        public double Diameter;

        public RingSizeModel(string letterSize, double numberSize, double diameter)
        {
            this.LetterSize = letterSize;
            this.NumberSize = numberSize;
            this.Diameter = diameter;
        }

        public string RingSizeName
        {
            get { return $"Letter: {LetterSize}, Number: {NumberSize}"; }
        }
    }
}
