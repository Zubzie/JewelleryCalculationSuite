using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite.ViewModels
{
    public class RollingWireViewModel : CalcFunctions
    {
        private BindableCollection<MetalModel> _metals;
        private BindableCollection<ProfileModel> _profiles;
        private MetalModel _selectedMetal;
        private ProfileModel _selectedProfile;
        private string _width = "";
        private string _thickness = "";
        private string _length = "";
        private string _stockSize = "";
        private bool _isStock = false;

        public RollingWireViewModel(BindableCollection<MetalModel> metals, BindableCollection<ProfileModel> profiles)
        {
            _metals = metals;
            _profiles = profiles;
            //_profiles.RemoveAt(1);
            //_profiles.RemoveAt(3);
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

        public string Width
        {
            get { return _width; }
            set
            {
                _width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }

        public string Thickness
        {
            get { return _thickness; }
            set
            {
                _thickness = value;
                NotifyOfPropertyChange(() => Thickness);
            }
        }
        public string Length
        {
            get { return _length; }
            set
            {
                _length = value;
                NotifyOfPropertyChange(() => Length);
            }
        }

        public string StockSize
        {
            get { return _stockSize; }
            set
            {
                _stockSize = value;
                NotifyOfPropertyChange(() => StockSize);
            }
        }

        public bool IsStock
        {
            get { return _isStock; }
            set
            {
                _isStock = value;
                NotifyOfPropertyChange(() => IsStock);
            }
        }

        public override void CalculateButton()
        {
            if (SelectedMetal != null && SelectedProfile != null && IsDouble(Width) && IsDouble(Length))
            {
                double length = Convert.ToDouble(Length);
                double width = Convert.ToDouble(Width);
                double thickness = Convert.ToDouble(Width);
                double stockSize = 1.0;

                if (IsStock)
                {
                    if (IsDouble(Thickness)) { thickness = Convert.ToDouble(Thickness); }
                    if (IsDouble(StockSize)) { stockSize = Convert.ToDouble(StockSize); }
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
                            CalculateText = "Width: " + diameter.ToString("F3") + "mm" + " Length: " + length.ToString("F3") + "mm" + " Stock Length: " + stockSize.ToString("F3") + "mm";
                        }
                        else { CalculateText = "Width: " + side.ToString("F3") + "mm" + " Length: " + length.ToString("F3") + "mm"; }                       
                    }
                    else
                    {
                        if (IsStock)
                        {
                            stockSize = (Math.Pow(side, 2) * length) / Math.Pow(stockSize, 2);
                            CalculateText = "Width: " + side.ToString("F3") + "mm" + " Length: " + length.ToString("F3") + "mm" + " Stock Length: " + stockSize.ToString("F3") + "mm";
                        }
                        else { CalculateText = "Width: " + side.ToString("F3") + "mm" + " Length: " + length.ToString("F3") + "mm"; }                       
                    }
                }
                else { CalculateText = ("Invalid Input"); }
            }
            else { CalculateText = ("Invalid Input"); }
        }
    }
}
