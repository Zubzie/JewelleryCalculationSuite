using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RollingWireViewModel : CalcFunctions
    {
        private BindableCollection<ProfileModel> _profiles;
        private ProfileModel _selectedProfile;
        private string _width = "";
        private string _thickness = "";
        private string _length = "";
        private string _stockSize = "";
        private bool _isStock;

        public bool IsStock 
        { 
            get { return _isStock; }
            set
            {
                _isStock = value;
                NotifyOfPropertyChange(() => IsStock);
            }
        }

        public RollingWireViewModel(BindableCollection<ProfileModel> profiles)
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                if (profiles[i].Shape == "Half-Round" || profiles[i].Shape == "Rectangle")
                {
                    profiles.RemoveAt(i);
                }
            }
            _profiles = profiles;        
        }

        public BindableCollection<ProfileModel> ProfilesDropDown
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

        public string WidthInput
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => WidthInput);
            }
        }

        public string ThicknessInput
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                NotifyOfPropertyChange(() => ThicknessInput);
            }
        }

        public string LengthInput
        {
            get { return _length; }
            set
            {
                _length = value;
                NotifyOfPropertyChange(() => LengthInput);
            }
        }

        public string StockSizeInput
        {
            get { return _stockSize; }
            set
            {
                _stockSize = value;
                NotifyOfPropertyChange(() => StockSizeInput);
            }
        }

        public override void CalculateButton()
        {
            if (SelectedProfile != null && IsDouble(WidthInput) && IsDouble(LengthInput))
            {
                double length = Convert.ToDouble(LengthInput);
                double width = Convert.ToDouble(WidthInput);
                double thickness = Convert.ToDouble(WidthInput);
                double stockSize = 1.0;

                if (IsStock)
                {
                    if (IsDouble(ThicknessInput)) { thickness = Convert.ToDouble(ThicknessInput); }
                    if (IsDouble(StockSizeInput)) { stockSize = Convert.ToDouble(StockSizeInput); }
                }

                if (width > 0 && thickness > 0 && length > 0 && stockSize > 0)
                {
                    double side = Math.Pow((Math.Pow(width, 2) * thickness), 1.0 / 3);
                    length = (length * width * thickness) / Math.Pow(side, 2);

                    if (SelectedProfile.Shape == "Round")
                    {
                        double diameter = (2 * side) / Math.Sqrt(pi);
                        if (IsStock)
                        {
                            stockSize = (4 * Math.Pow(side, 2) * length) / (pi * Math.Pow(stockSize, 2));
                            CalculateText = "Side: " + diameter.ToString("F2") + "mm" + "\nStock Length: " + stockSize.ToString("F2") + "mm";
                        }
                        else { CalculateText = "Side: " + side.ToString("F2") + "mm" + "\nLength: " + length.ToString("F2") + "mm"; }
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
