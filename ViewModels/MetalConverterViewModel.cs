using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.ViewModels 
{
    public class MetalConverterViewModel : CalcFunctions
    {      
        private BindableCollection<MetalModel> _metals;
        private MetalModel _origSelectedMetal;
        private MetalModel _newSelectedMetal;
        private string _origMetalWeight = "";

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

        public override void CalculateButton()
        {
            if (OrigSelectedMetal != null && NewSelectedMetal != null && OrigMetalWeight != null && IsDouble(OrigMetalWeight))
            {
                double weight = Convert.ToDouble(OrigMetalWeight);

                if (weight > 0)
                {
                    weight *= 1.0 / OrigSelectedMetal.SpecificGravity;
                    weight *= NewSelectedMetal.SpecificGravity;

                    CalculateText = weight.ToString("F3") + "g";
                }
                else { CalculateText = ("Invalid Input"); }
            }
            else { CalculateText = ("Invalid Input"); }
        }
    }
}
