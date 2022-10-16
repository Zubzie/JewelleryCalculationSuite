using System.Text.Json;
using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System.IO;

namespace JewelleryCalculationSuite.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private BindableCollection<MetalModel> _metals = new();
        private BindableCollection<RingSizeModel> _ringSizes = new();
        private string ?_jsonString;
        private readonly string _metalPath;
        private readonly string _ringSizePath;

        public ShellViewModel()
        {
            ActivateItemAsync(new MainPageViewModel());
            _metalPath = "Data/Metals.json";
            _ringSizePath = "Data/RingSizes.json";

            try
            {
                _jsonString = File.ReadAllText(@_metalPath);
                _metals = JsonSerializer.Deserialize<BindableCollection<MetalModel>>(_jsonString);
            }
            catch(System.IO.FileNotFoundException) { MakeDefaultMetals(); }

            try
            {
                _jsonString = File.ReadAllText(@_ringSizePath);
                _ringSizes = JsonSerializer.Deserialize<BindableCollection<RingSizeModel>>(_jsonString);
            }
            catch (System.IO.FileNotFoundException) { MakeDefaultSizes(); }
        }

        public void LoadPageInformation()
        {
            ActivateItemAsync(new InformationViewModel());
        }

        public void LoadPageMetalConverter()
        {
            ActivateItemAsync(new MetalConverterViewModel(_metals));
        }

        public void LoadPageRingWeight()
        {
            ActivateItemAsync(new RingWeightViewModel(_metals, _ringSizes));
        }

        public void LoadPageRingResizer()
        {
            ActivateItemAsync(new RingResizerViewModel(_metals, _ringSizes));
        }

        public void LoadPageRollingWire()
        {
           ActivateItemAsync(new RollingWireViewModel());
        }   

        public void LoadPageSettings()
        {
            ActivateItemAsync(new SettingsViewModel(_metals, _ringSizes));
        }

        public static string InformationPath
        {
            get { return Path.GetFullPath("Images/Information.png"); }
        }

        public static string MetalConverterPath
        {
            get { return Path.GetFullPath("Images/MetalConverter.png"); }
        }

        public static string RingWeightPath
        {
            get { return Path.GetFullPath("Images/RingWeight.png"); }
        }

        public static string RingResizerPath
        {
            get { return Path.GetFullPath("Images/RingResizer.png"); }
        }

        public static string RollingWirePath
        {
            get { return Path.GetFullPath("Images/RollingWire.png"); }
        }     

        public static string SettingsPath
        {
            get { return Path.GetFullPath("Images/Settings.png"); }
        }

        public void MakeDefaultMetals()
        {
            _metals.Add(new MetalModel("Fine Silver", 10.64));
            _metals.Add(new MetalModel("Bright Silver", 10.50));
            _metals.Add(new MetalModel("Sterling Silver", 10.55));
            _metals.Add(new MetalModel("Fine Gold", 19.36));
            _metals.Add(new MetalModel("18ct Yellow Gold", 16.04));
            _metals.Add(new MetalModel("14ct Yellow Gold", 13.56));
            _metals.Add(new MetalModel("9ct Yellow Gold", 11.64));
            _metals.Add(new MetalModel("18ct White Gold", 16.59));
            _metals.Add(new MetalModel("14ct White Gold", 14.02));
            _metals.Add(new MetalModel("9ct White Gold", 13.04));
            _metals.Add(new MetalModel("18ct Pink Gold", 15.45));
            _metals.Add(new MetalModel("14ct Pink Gold", 14.00));
            _metals.Add(new MetalModel("9ct Pink Gold", 11.71));
            _metals.Add(new MetalModel("Platinum", 21.24));
            _metals.Add(new MetalModel("Wax", 1.0));
            var options = new JsonSerializerOptions { WriteIndented = true };
            _jsonString = JsonSerializer.Serialize(_metals, options);
            File.WriteAllText(@_metalPath, _jsonString);
        }

        public void MakeDefaultSizes()
        {
            _ringSizes.Add(new RingSizeModel("A", 0.5, 12.04));
            _ringSizes.Add(new RingSizeModel("B", 1.0, 12.45));
            _ringSizes.Add(new RingSizeModel("C", 1.5, 12.85));
            _ringSizes.Add(new RingSizeModel("D", 2.0, 13.26));
            _ringSizes.Add(new RingSizeModel("E", 2.5, 13.67));
            _ringSizes.Add(new RingSizeModel("F", 3.0, 14.07));
            _ringSizes.Add(new RingSizeModel("G", 3.5, 14.48));
            _ringSizes.Add(new RingSizeModel("H", 4.0, 14.88));
            _ringSizes.Add(new RingSizeModel("I", 4.5, 15.29));
            _ringSizes.Add(new RingSizeModel("J", 5.0, 15.49));
            _ringSizes.Add(new RingSizeModel("K", 5.5, 15.9));
            _ringSizes.Add(new RingSizeModel("L", 6.0, 16.31));
            _ringSizes.Add(new RingSizeModel("M", 6.5, 16.71));
            _ringSizes.Add(new RingSizeModel("N", 7.0, 17.12));
            _ringSizes.Add(new RingSizeModel("O", 7.5, 17.53));
            _ringSizes.Add(new RingSizeModel("P", 8.0, 17.93));
            _ringSizes.Add(new RingSizeModel("Q", 8.5, 18.34));
            _ringSizes.Add(new RingSizeModel("R", 9.0, 18.75));
            _ringSizes.Add(new RingSizeModel("S", 9.5, 19.15));
            _ringSizes.Add(new RingSizeModel("T", 10.0, 19.56));
            _ringSizes.Add(new RingSizeModel("U", 10.5, 19.96));
            _ringSizes.Add(new RingSizeModel("V", 11.0, 20.37));
            _ringSizes.Add(new RingSizeModel("W", 11.5, 20.78));
            _ringSizes.Add(new RingSizeModel("X", 12.0, 21.18));
            _ringSizes.Add(new RingSizeModel("Y", 12.5, 21.59));
            _ringSizes.Add(new RingSizeModel("Z", 13.0, 21.79));
            var options = new JsonSerializerOptions { WriteIndented = true };
            _jsonString = JsonSerializer.Serialize(_ringSizes, options);
            File.WriteAllText(@_ringSizePath, _jsonString);
        }
    }
}
