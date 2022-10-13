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
