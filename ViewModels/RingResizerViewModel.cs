using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RingResizerViewModel : CalcFunctions
    {
        private BindableCollection<MetalModel> _metals;
        private BindableCollection<RingSizeModel> _ringSizes;
        private BindableCollection<ProfileModel> _profiles = new();

        private MetalModel? _selectedMetal;
        private RingSizeModel? _origSelectedRingSize;
        private RingSizeModel? _newSelectedRingSize;
        private ProfileModel? _selectedProfile;

        private string _ringWidth = "";
        private string _ringThickness = "";
        private bool _isThicknessEnabled;

        public RingResizerViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes)
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

        public BindableCollection<RingSizeModel> OrigSizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel OrigSelectedRingSize
        {
            get { return _origSelectedRingSize; }
            set { _origSelectedRingSize = value; NotifyOfPropertyChange(() => OrigSelectedRingSize); }
        }

        public BindableCollection<RingSizeModel> NewSizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel NewSelectedRingSize
        {
            get { return _newSelectedRingSize; }
            set { _newSelectedRingSize = value; NotifyOfPropertyChange(() => NewSelectedRingSize); }
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
            if (SelectedMetal != null && OrigSelectedRingSize != null && NewSelectedRingSize != null && SelectedProfile != null && IsDouble(RingWidth))
            {
                double origWeight = 0.0;
                double newWeight = 0.0;
                double origLength = OrigSelectedRingSize.Diameter;
                double newLength = NewSelectedRingSize.Diameter;
                double width = Convert.ToDouble(RingWidth);

                if ((SelectedProfile.Shape == "Half-Round" || SelectedProfile.Shape == "Rectangle") && IsDouble(RingThickness))
                {
                    double thickness = Convert.ToDouble(RingThickness);
                    if (width > 0 && thickness > 0)
                    {
                        if (SelectedProfile.Shape == "Half-Round") 
                        { 
                            origWeight = ((pi * Math.Pow(width, 2)) * (origLength + width + thickness)) * SelectedMetal.SpecificGravity / 1000;
                            newWeight = ((pi * Math.Pow(width, 2)) * (newLength + width + thickness)) * SelectedMetal.SpecificGravity / 1000;
                        }
                        if (SelectedProfile.Shape == "Rectangle") 
                        { 
                            origWeight = (origLength + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000;
                            newWeight = (newLength + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000;
                        }                  
                        CalculateText = (newWeight - origWeight).ToString("F3") + "g";
                    }
                    else { CalculateText = ("Invalid Input"); }
                }
                else if ((SelectedProfile.Shape == "Round" || SelectedProfile.Shape == "Square") && width > 0)
                {
                    if (SelectedProfile.Shape == "Round") 
                    { 
                        origWeight = (pi * Math.Pow(width, 2) * (origLength + width)) * SelectedMetal.SpecificGravity / 1000;
                        newWeight = (pi * Math.Pow(width, 2) * (newLength + width)) * SelectedMetal.SpecificGravity / 1000;
                    }                    
                    if (SelectedProfile.Shape == "Square") 
                    { 
                        origWeight = (origLength + width + width) * pi * width * width * SelectedMetal.SpecificGravity / 1000;
                        newWeight = (newLength + width + width) * pi * width * width * SelectedMetal.SpecificGravity / 1000;
                    }                    
                    CalculateText = (newWeight - origWeight).ToString("F3") + "g";
                }
                else { CalculateText = ("Invalid Input"); }
            }
            else { CalculateText = ("Invalid Input"); }
        }
    
    }
}
