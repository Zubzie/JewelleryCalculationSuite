using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Windows;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RollingWireViewModel : CalcFunctions
    {
        private BindableCollection<ProfileModel> _profiles = new();
        private BindableCollection<RingSizeModel> _ringSizes = new();
        private ProfileModel? _selectedProfile;
        private RingSizeModel? _selectedRingSize;
        private Visibility _ringSizesIsVisible = Visibility.Hidden;

        private string _width = "";
        private string _thickness = "";
        private string _length = "";
        private string _stockSize = "";

        private bool _isStock;
        private bool _isRingSize;
       
        public RollingWireViewModel(BindableCollection<RingSizeModel> ringSizes)
        {
            _profiles.Add(new ProfileModel("Round"));
            _profiles.Add(new ProfileModel("Square"));
            _ringSizes = ringSizes;
        }       

        public BindableCollection<ProfileModel> ProfilesDropDown
        { 
            get { return _profiles; }
            set { _profiles = value; }
        }

        public ProfileModel SelectedProfile
        {
            get { return _selectedProfile; }
            set { _selectedProfile = value; NotifyOfPropertyChange(() => SelectedProfile); }
        }

        public bool IsStock
        {
            get { return _isStock; }
            set { _isStock = value; NotifyOfPropertyChange(() => IsStock); }
        }

        public BindableCollection<RingSizeModel> RingSizeDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }

        public bool IsRingSize
        {
            get { return _isRingSize; }
            set 
            { 
                _isRingSize = value; NotifyOfPropertyChange(() => IsRingSize);
                if (_isRingSize) { _ringSizesIsVisible = Visibility.Visible; NotifyOfPropertyChange(() => RingSizesIsVisible); }
                else { _ringSizesIsVisible = Visibility.Hidden; NotifyOfPropertyChange(() => RingSizesIsVisible); }
            }
        }

        public RingSizeModel SelectedRingSize
        {
            get { return _selectedRingSize; }
            set  { _selectedRingSize = value; NotifyOfPropertyChange(() => SelectedRingSize); }
        }

        public Visibility RingSizesIsVisible
        {
            get { return _ringSizesIsVisible; }
            set { _ringSizesIsVisible = value; NotifyOfPropertyChange(() => RingSizesIsVisible); }
        }

        public string WidthInput
        {
            get { return _width; }
            set { _width = value; NotifyOfPropertyChange(() => WidthInput); }
        }

        public string ThicknessInput
        {
            get { return _thickness; }
            set { _thickness = value; NotifyOfPropertyChange(() => ThicknessInput); }
        }

        public string LengthInput
        {
            get { return _length; }
            set { _length = value; NotifyOfPropertyChange(() => LengthInput); }
        }

        public string StockSizeInput
        {
            get { return _stockSize; }
            set { _stockSize = value; NotifyOfPropertyChange(() => StockSizeInput); }
        }

        public override void CalculateButton()
        {
            if (SelectedProfile != null && IsDouble(WidthInput) && IsDouble(ThicknessInput))
            {
                double stockSize = 0.0;
                double length = 0.0;
                if (IsRingSize && _selectedRingSize != null) { length = _selectedRingSize.Diameter; }
                else if (IsDouble(LengthInput)) { length = Convert.ToDouble(LengthInput); }

                double width = Convert.ToDouble(WidthInput);
                double thickness = Convert.ToDouble(ThicknessInput);              

                if (IsStock && IsDouble(StockSizeInput)) { stockSize = Convert.ToDouble(StockSizeInput); }

                if (width > 0 && thickness > 0 && length > 0 && (!IsStock || stockSize > 0))
                {
                    double side = Math.Pow(Math.Pow(width, 2) * thickness, 1.0 / 3);
                    length = (length * width * thickness) / Math.Pow(side, 2);

                    if (SelectedProfile.Shape == "Round")
                    {
                        double diameter = (2 * side) / Math.Sqrt(pi);
                        if (IsStock)
                        {
                            stockSize = (4 * Math.Pow(side, 2) * length) / (pi * Math.Pow(stockSize, 2));
                            CalculateText = "Diameter: " + diameter.ToString("F2") + "mm" + "\nStock Length: " + stockSize.ToString("F2") + "mm";
                        }
                        else { CalculateText = "Diameter: " + side.ToString("F2") + "mm" + "\nLength: " + length.ToString("F2") + "mm"; }
                    }
                    else
                    {
                        if (IsStock)
                        {
                            stockSize = (Math.Pow(side, 2) * length) / Math.Pow(stockSize, 2);
                            CalculateText = "Side: " + side.ToString("F2") + "mm" + "\nStock Length: " + stockSize.ToString("F2") + "mm";
                        }
                        else { CalculateText = "Side: " + side.ToString("F2") + "mm" + "\nLength: " + length.ToString("F2") + "mm"; }
                    }
                }
                else { CalculateText = ("Invalid Input"); }
            }
            else { CalculateText = ("Invalid Input"); }
        }
    }
}
