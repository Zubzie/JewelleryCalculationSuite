using System.Text.Json.Serialization;
namespace JewelleryCalculationSuite.Models
{
    public class RingSizeModel
    {
        public string Name { get; set; }
        public string LetterSize { get; set; }
        public double NumberSize { get; set; }
        public double Diameter { get; set; }

        public RingSizeModel(string letterSize, double numberSize, double diameter)
        { 
            this.Name = $"{letterSize} / {numberSize}";
            this.LetterSize = letterSize;
            this.NumberSize = numberSize;
            this.Diameter = diameter;
        }
    }
}
