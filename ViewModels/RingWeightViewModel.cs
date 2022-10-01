using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RingWeightViewModel : Screen
    {
        private BindableCollection<MetalModel> _metals;
        private BindableCollection<RingSizeModel> _ringSizes;
        private BindableCollection<ProfileModel> _profiles;
        private MetalModel _selectedMetal;
        private RingSizeModel _selectedRingSize;
        private ProfileModel _selectedProfile;
        private string _ringWidth;
        private string _ringThickness;
        private string _metalCalcText;
        protected const double pi = 3.14159265359;

        public RingWeightViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes, BindableCollection<ProfileModel> profiles)
        {
            _metals = metals;
            _ringSizes = ringSizes;
            _profiles = profiles;
        }

        public BindableCollection<MetalModel> MetalsDropDown
        {
            get { return _metals; }
            set { _metals = value; }
        }

        public MetalModel SelectedMetal
        {
            get { return _selectedMetal; }
            set
            {
                _selectedMetal = value;
                NotifyOfPropertyChange(() => SelectedMetal);
            }
        }

        public BindableCollection<RingSizeModel> SizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel SelectedRingSize
        {
            get { return _selectedRingSize; }
            set
            {
                _selectedRingSize = value;
                NotifyOfPropertyChange(() => SelectedRingSize);
            }
        }
        public BindableCollection<ProfileModel> ProfileDropDown
        {
            get { return _profiles; }
            set { _profiles = value; }
        }

        public ProfileModel SelectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                _selectedProfile = value;
                NotifyOfPropertyChange(() => SelectedProfile);
            }
        }

        public string RingWidth
        {
            get { return _ringWidth; }
            set
            {
                _ringWidth = value;
                NotifyOfPropertyChange(() => RingWidth);
            }
        }

        public string RingThickness
        {
            get { return _ringThickness; }
            set
            {
                _ringThickness = value;
                NotifyOfPropertyChange(() => RingThickness);
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
            if (SelectedMetal != null && SelectedRingSize != null && SelectedProfile != null && IsDouble(RingWidth))
            {
                double weight = 0;                
                double length = SelectedRingSize.Diameter;
                double width = Convert.ToDouble(RingWidth);
                double thickness = Convert.ToDouble(RingWidth);

                if (SelectedProfile.Shape == "Half-Round" || SelectedProfile.Shape == "Rectangle")
                {
                    if (IsDouble(RingThickness)) { thickness = Convert.ToDouble(RingThickness); }                  
                }                             

                if (width > 0 && thickness > 0)
                {
                    if (SelectedProfile.Shape == "Round") { weight = (pi * Math.Pow(width, 2) * (length + width)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Half-Round") { weight = (pi * Math.Pow(1.5 * thickness, 2) * (length + width + thickness)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Square") { weight = (length + width + width) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000; }
                    else weight = (length + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000;
                    MetalCalcText = weight.ToString("F3") + "g";
                }
                else { MetalCalcText = ("Invalid Input"); }
            }
            else { MetalCalcText = ("Invalid Input"); }
        }
    }
}
