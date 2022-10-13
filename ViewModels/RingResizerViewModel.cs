using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RingResizerViewModel : CalcFunctions
    {
        private BindableCollection<MetalModel> _metals;
        private BindableCollection<RingSizeModel> _ringSizes;
        private BindableCollection<ProfileModel> _profiles;
        private MetalModel _selectedMetal;
        private RingSizeModel _origSelectedRingSize;
        private RingSizeModel _newSelectedRingSize;
        private ProfileModel _selectedProfile;
        private string _ringWidth = "";
        private string _ringThickness = "";

        public RingResizerViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes, BindableCollection<ProfileModel> profiles)
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

        public BindableCollection<RingSizeModel> OrigSizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel OrigSelectedRingSize
        {
            get { return _origSelectedRingSize; }
            set
            {
                _origSelectedRingSize = value;
                NotifyOfPropertyChange(() => OrigSelectedRingSize);
            }
        }

        public BindableCollection<RingSizeModel> NewSizesDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public RingSizeModel NewSelectedRingSize
        {
            get { return _newSelectedRingSize; }
            set
            {
                _newSelectedRingSize = value;
                NotifyOfPropertyChange(() => NewSelectedRingSize);
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

        public override void CalculateButton()
        {
            if (SelectedMetal != null && OrigSelectedRingSize != null && NewSelectedRingSize != null && SelectedProfile != null && IsDouble(RingWidth))
            {
                double origWeight;
                double newWeight;

                double origLength = OrigSelectedRingSize.Diameter;
                double newLength = NewSelectedRingSize.Diameter;
                double width = Convert.ToDouble(RingWidth);
                double thickness = Convert.ToDouble(RingWidth);

                if (SelectedProfile.Shape == "Half-Round" || SelectedProfile.Shape == "Rectangle")
                {
                    if (IsDouble(RingThickness)) { thickness = Convert.ToDouble(RingThickness); }
                }

                if (width > 0 && thickness > 0)
                {
                    if (SelectedProfile.Shape == "Round") { origWeight = (pi * Math.Pow(width, 2) * (origLength + width)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Half-Round") { origWeight = ((pi * Math.Pow(width, 2)) * (origLength + width + thickness)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Square") { origWeight = (origLength + width + width) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000; }
                    else origWeight = (origLength + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000;

                    if (SelectedProfile.Shape == "Round") { newWeight = (pi * Math.Pow(width, 2) * (newLength + width)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Half-Round") { newWeight = ((pi * Math.Pow(width, 2)) * (newLength + width + thickness)) * SelectedMetal.SpecificGravity / 1000; }
                    else if (SelectedProfile.Shape == "Square") { newWeight = (newLength + width + width) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000; }
                    else newWeight = (newLength + width + thickness) * pi * width * thickness * SelectedMetal.SpecificGravity / 1000;

                    CalculateText = (newWeight - origWeight).ToString("F3") + "g";
                }
                else { CalculateText = ("Invalid Input"); }
            }
            else { CalculateText = ("Invalid Input"); }
        }
    
    }
}
