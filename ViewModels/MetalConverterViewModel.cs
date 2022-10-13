using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;

namespace JewelleryCalculationSuite.ViewModels
{
    public class MetalConverterViewModel : CalcFunctions
    {      
        private BindableCollection<MetalModel> _metals;
        private MetalModel _origSelectedMetal;
        private MetalModel _newSelectedMetal;
        private string _metalWeight = "";

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

        public string MetalWeight
        {
            get { return _metalWeight; }
            set
            {
                _metalWeight = value;
                NotifyOfPropertyChange(() => MetalWeight);
            }
        }      

        public override void CalculateButton()
        {
            if (OrigSelectedMetal != null && NewSelectedMetal != null && MetalWeight != null && IsDouble(MetalWeight))
            {
                double weight = Convert.ToDouble(MetalWeight);

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
