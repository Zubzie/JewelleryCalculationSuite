using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JewelleryCalculationSuite.ViewModels
{
    public class SettingsViewModel : Screen
    {
        private BindableCollection<MetalModel> _metals = new();
        private BindableCollection<RingSizeModel> _ringSizes = new();
        private Visibility _visibility = Visibility.Hidden;

        private MetalModel _selectedMetal;
        private RingSizeModel _selectedRingSize;

        private bool _metalChecked;
        private bool _sizeChecked;
        private bool _modifyChecked;
        private bool _addChecked;
        private bool _removeChecked;

        private string _variable1Input = "";
        private string _variable2Input = "";
        private string _variable3Input = "";
        private string _variable1Name = "N/A";
        private string _variable2Name = "N/A";
        private string _variable3Name = "N/A";



        public SettingsViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes)
        {
            _metals = metals;
            _ringSizes = ringSizes;
        }

        public bool RbMetals
        {
            get { return _metalChecked; }
            set
            {
                _metalChecked = value; NotifyOfPropertyChange(() => RbMetals);
                if (_metalChecked) 
                { 
                    _visibility = Visibility.Hidden; NotifyOfPropertyChange(() => RbSizesIsVisible);
                    _variable1Name = "Name"; NotifyOfPropertyChange(() => Variable1Name);
                    _variable2Name = "Specific Gravity"; NotifyOfPropertyChange(() => Variable2Name);
                    _variable3Name = ""; NotifyOfPropertyChange(() => Variable3Name);
                }               
            }
        }

        public bool RbSizes
        {
            get { return _sizeChecked;  }
            set
            {
                _sizeChecked = value; NotifyOfPropertyChange(() => RbSizes);
                if (_sizeChecked) 
                { 
                    _visibility = Visibility.Visible; NotifyOfPropertyChange(() => RbSizesIsVisible);
                    _variable1Name = "Letter Size"; NotifyOfPropertyChange(() => Variable1Name);
                    _variable2Name = "Number Size"; NotifyOfPropertyChange(() => Variable2Name);
                    _variable3Name = "Diameter"; NotifyOfPropertyChange(() => Variable3Name);
                }                
            }
        }

        public Visibility RbSizesIsVisible
        {
            get { return _visibility; }
            set { _visibility = value; NotifyOfPropertyChange(() => RbSizesIsVisible); }
        }

        public BindableCollection<MetalModel> MetalDropDown
        {
            get { return _metals; }           
            set { _metals = value; }
        }

        public MetalModel SelectedMetal
        {
            get { return _selectedMetal; }
            set { _selectedMetal = value; NotifyOfPropertyChange(() => SelectedMetal); }
        }

        public BindableCollection<RingSizeModel> RingSizeDropDown
        {
            get { return _ringSizes; }
            set { _ringSizes = value; }
        }
      
        public RingSizeModel SelectedRingSize
        {
            get { return _selectedRingSize; }
            set { _selectedRingSize = value; NotifyOfPropertyChange(() => SelectedRingSize); }
        }

        public bool RbModify
        {
            get { return _modifyChecked; }
            set { _modifyChecked = value; NotifyOfPropertyChange(() => RbModify); }
        }

        public bool RbAdd
        {
            get { return _addChecked; }
            set { _addChecked = value; NotifyOfPropertyChange(() => RbAdd); }
        }

        public bool RbRemove
        {
            get { return _removeChecked; }
            set { _removeChecked = value; NotifyOfPropertyChange(() => RbRemove); }
        }

        public string Variable1Name
        {
            get { return _variable1Name; }
            set { _variable1Name = value; NotifyOfPropertyChange(() => Variable1Name); }
        }
        public string Variable2Name
        {
            get { return _variable2Name; }
            set { _variable2Name = value; NotifyOfPropertyChange(() => Variable2Name); }
        }
        public string Variable3Name
        {
            get { return _variable3Name; }
            set { _variable3Name = value; NotifyOfPropertyChange(() => Variable3Name); }
        }

    }
}
