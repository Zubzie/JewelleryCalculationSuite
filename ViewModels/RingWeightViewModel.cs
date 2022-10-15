using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RingWeightViewModel : CalcFunctions
    {
        private BindableCollection<MetalModel> _metals;
        private BindableCollection<RingSizeModel> _ringSizes;
        private BindableCollection<ProfileModel> _profiles = new();

        private MetalModel? _selectedMetal;
        private RingSizeModel? _selectedRingSize;
        private ProfileModel? _selectedProfile;

        private string _ringWidth = "";
        private string _ringThickness = "";
        private bool _isThicknessEnabled;

        public RingWeightViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes)
        {
            _metals = metals;
            _ringSizes = ringSizes;
            _profiles.Add(new ProfileModel("Round"));
            _profiles.Add(new ProfileModel("Half-Round"));
            _profiles.Add(new ProfileModel("Square"));
            _profiles.Add(new ProfileModel("Rectangle"));
        }

        public BindableCollection<MetalModel> MetalsDropDown
        {
            get { return _metals; }
            set { _metals = value; }
        }

        public MetalModel SelectedMetal
        {
            get { return _selectedMetal; }
            set { _selectedMetal = value; NotifyOfPropertyChange(() => SelectedMetal); }
        }

        public BindableCollection<RingSizeModel> SizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel SelectedRingSize
        {
            get { return _selectedRingSize; }
            set { _selectedRingSize = value; NotifyOfPropertyChange(() => SelectedRingSize); }
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
                _selectedProfile = value; NotifyOfPropertyChange(() => SelectedProfile); 
                if (_selectedProfile != null && (_selectedProfile.Shape == "Round" || _selectedProfile.Shape == "Square"))
                {
                    _isThicknessEnabled = false;
                    NotifyOfPropertyChange(() => IsThicknessEnabled);
                } 
                else { _isThicknessEnabled = true; NotifyOfPropertyChange(() => IsThicknessEnabled); }              
            }
        }

        public string RingWidth
        {
            get { return _ringWidth; }
            set { _ringWidth = value; NotifyOfPropertyChange(() => RingWidth); }
        }

        public string RingThickness
        {
            get { return _ringThickness; }
            set { _ringThickness = value; NotifyOfPropertyChange(() => RingThickness); }
        }

        public bool IsThicknessEnabled
        {
            get { return _isThicknessEnabled; }
            set { _isThicknessEnabled = value; NotifyOfPropertyChange(() => IsThicknessEnabled); }
        }

        public override void CalculateButton()
        {            
            if (SelectedMetal != null && SelectedRingSize != null && SelectedProfile != null && IsDouble(RingWidth))
            {
                double weight = 0.0;                
                double length = SelectedRingSize.Diameter;
                double width = Convert.ToDouble(RingWidth);

                if ((SelectedProfile.Shape == "Half-Round" || SelectedProfile.Shape == "Rectangle") && IsDouble(RingThickness))
                {
                    double thickness = Convert.ToDouble(RingThickness);
                    if (width > 0 && thickness > 0)
                    {
                        if (SelectedProfile.Shape == "Half-Round") { weight = ((pi * Math.Pow(width, 2)) * (length + width + thickness)) * SelectedMetal.SpecificGravity / 1000; }
                        if (SelectedProfile.Shape == "Rectangle") { weight = (length + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000; }
                        CalculateText = weight.ToString("F3") + "g";
                    }
                    else { CalculateText = ("Invalid Input"); }
                }               
                else if ((SelectedProfile.Shape == "Round" || SelectedProfile.Shape == "Square") && width > 0)
                {
                    if (SelectedProfile.Shape == "Round") { weight = (pi * Math.Pow(width, 2) * (length + width)) * SelectedMetal.SpecificGravity / 1000; }
                    if (SelectedProfile.Shape == "Square") { weight = (length + width + width) * pi * width * width * SelectedMetal.SpecificGravity / 1000; }
                    CalculateText = weight.ToString("F3") + "g";
                }
                else { CalculateText = ("Invalid Input"); }               
            }
            else { CalculateText = ("Invalid Input"); }
        }
    }
}
