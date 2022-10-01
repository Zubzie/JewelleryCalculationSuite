using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.ViewModels 
{
    public class MetalConverterViewModel : Screen
    {      
        private BindableCollection<MetalModel> _metals;
        private MetalModel _origSelectedMetal;
        private MetalModel _newSelectedMetal;
        private string _origMetalWeight;
        private string _metalCalcText;

        public MetalConverterViewModel(BindableCollection<MetalModel> metals)
        {
            _metals = metals;
        }

        public BindableCollection<MetalModel> OrigMetalsDropDown
        {
            get { return _metals; }
            set { _metals = value; }
        }
        public MetalModel OrigSelectedMetal
        {
            get { return _origSelectedMetal; }
            set
            {
                _origSelectedMetal = value;
                NotifyOfPropertyChange(() => OrigSelectedMetal);
            }
        }

        public BindableCollection<MetalModel> NewMetalsDropDown
        {
            get { return _metals; }
            set { _metals = value; }
        }                  

        public MetalModel NewSelectedMetal
        {
            get { return _newSelectedMetal; }
            set
            {
                _newSelectedMetal = value;
                NotifyOfPropertyChange(() => NewSelectedMetal);
            }
        }

        public string OrigMetalWeight
        {
            get { return _origMetalWeight; }
            set
            {
                _origMetalWeight = value;
                NotifyOfPropertyChange(() => OrigMetalWeight);
            }
        }

        public string MetalCalcText
        {
            get { return _metalCalcText; }
            set
            {
                _metalCalcText = value;
                NotifyOfPropertyChange(() => MetalCalcText);
            }
        }

        private static bool IsDouble(string input)
        {
            bool isDouble = Double.TryParse(input, out _);
            if (isDouble) return true;
            return false;
        }       

        public void CalculateButton()
        {
            if (OrigSelectedMetal != null && NewSelectedMetal != null && OrigMetalWeight != null && IsDouble(OrigMetalWeight))
            {
                double weight = Convert.ToDouble(OrigMetalWeight);

                if (weight > 0)
                {
                    weight *= 1.0 / OrigSelectedMetal.SpecificGravity;
                    weight *= NewSelectedMetal.SpecificGravity;

                    MetalCalcText = weight.ToString("F3") + "g";
                }
                else { MetalCalcText = ("Invalid Input"); }
            }
            else { MetalCalcText = ("Invalid Input"); }
        }
    }
}
