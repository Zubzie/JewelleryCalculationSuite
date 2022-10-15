﻿using Caliburn.Micro;
using JewelleryCalculationSuite.Models;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace JewelleryCalculationSuite.ViewModels
{
    public class SettingsViewModel : CalcFunctions
    {
        private BindableCollection<MetalModel> _metals = new();
        private BindableCollection<RingSizeModel> _ringSizes = new();
        private Visibility _rbSizesIsVisible = Visibility.Hidden;
        private MetalModel? _selectedMetal;
        private RingSizeModel? _selectedRingSize;
        private string? _jsonString;

        private bool _metalChecked;
        private bool _sizeChecked;
        private bool _modifyChecked;
        private bool _addChecked;
        private bool _removeChecked;

        private bool _activateInput1;
        private bool _activateInput2;
        private bool _activateInput3;

        private string _variable1Name;
        private string _variable2Name;
        private string _variable3Name;

        private string _variable1Input = "";
        private string _variable2Input = "";
        private string _variable3Input = "";
        private string _invalidInputText = "";           

        public SettingsViewModel(BindableCollection<MetalModel> metals, BindableCollection<RingSizeModel> ringSizes)
        {
            _metals = metals;
            _ringSizes = ringSizes;
            NothingCheckedSettings();
        }

        public bool ActivateInput1
        {
            get { return _activateInput1; }
            set { _activateInput1 = value; NotifyOfPropertyChange(() => ActivateInput1); }
        }

        public bool ActivateInput2
        {
            get { return _activateInput2; }
            set { _activateInput2 = value; NotifyOfPropertyChange(() => ActivateInput2); }
        }

        public bool ActivateInput3
        {
            get { return _activateInput3; }
            set { _activateInput3 = value; NotifyOfPropertyChange(() => ActivateInput3); }
        }

        public bool RbMetals
        {
            get { return _metalChecked; }
            set
            {
                _metalChecked = value; NotifyOfPropertyChange(() => RbMetals);
                if (_metalChecked)
                {
                    _rbSizesIsVisible = Visibility.Hidden; NotifyOfPropertyChange(() => RbSizesIsVisible);
                    _selectedRingSize = null; NotifyOfPropertyChange(() => SelectedRingSize);
                    MetalCheckedSettings();
                }
            }
        }

        public bool RbSizes
        {
            get { return _sizeChecked; }
            set
            {
                _sizeChecked = value; NotifyOfPropertyChange(() => RbSizes);
                if (_sizeChecked)
                {
                    _rbSizesIsVisible = Visibility.Visible; NotifyOfPropertyChange(() => RbSizesIsVisible);
                    _selectedMetal = null; NotifyOfPropertyChange(() => SelectedMetal);
                    SizeCheckedSettings();
                }
            }
        }

        public Visibility RbSizesIsVisible
        {
            get { return _rbSizesIsVisible; }
            set { _rbSizesIsVisible = value; NotifyOfPropertyChange(() => RbSizesIsVisible); }
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
            set
            {
                _modifyChecked = value; NotifyOfPropertyChange(() => RbModify);
                //if (_sizeChecked) { SizeCheckedSettings(); }
                //if (_metalChecked) { MetalCheckedSettings(); }
            }
        }

        public bool RbAdd
        {
            get { return _addChecked; }
            set
            {
                _addChecked = value; NotifyOfPropertyChange(() => RbAdd);
                //if (_sizeChecked) { SizeCheckedSettings(); }
                //if (_metalChecked) { MetalCheckedSettings(); }
            }
        }

        public bool RbRemove
        {
            get { return _removeChecked; }
            set
            {
                _removeChecked = value; NotifyOfPropertyChange(() => RbRemove);
                //NothingCheckedSettings();
            }
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

        public void SizeCheckedSettings()
        {
            _activateInput1 = true; NotifyOfPropertyChange(() => ActivateInput1);
            _activateInput2 = true; NotifyOfPropertyChange(() => ActivateInput2);
            _activateInput3 = true; NotifyOfPropertyChange(() => ActivateInput3);
            _variable1Name = "Letter Size"; NotifyOfPropertyChange(() => Variable1Name);
            _variable2Name = "Number Size"; NotifyOfPropertyChange(() => Variable2Name);
            _variable3Name = "Diameter"; NotifyOfPropertyChange(() => Variable3Name);
        }

        public void MetalCheckedSettings()
        {
            _activateInput1 = true; NotifyOfPropertyChange(() => ActivateInput1);
            _activateInput2 = true; NotifyOfPropertyChange(() => ActivateInput2);
            _activateInput3 = false; NotifyOfPropertyChange(() => ActivateInput3);
            _variable1Name = "Name"; NotifyOfPropertyChange(() => Variable1Name);
            _variable2Name = "Specific Gravity"; NotifyOfPropertyChange(() => Variable2Name);
            _variable3Name = "N/A"; NotifyOfPropertyChange(() => Variable3Name);
        }

        public void NothingCheckedSettings()
        {
            _activateInput1 = false; NotifyOfPropertyChange(() => ActivateInput1);
            _activateInput2 = false; NotifyOfPropertyChange(() => ActivateInput2);
            _activateInput3 = false; NotifyOfPropertyChange(() => ActivateInput3);
            _variable1Name = "N/A"; NotifyOfPropertyChange(() => Variable1Name);
            _variable2Name = "N/A"; NotifyOfPropertyChange(() => Variable2Name);
            _variable3Name = "N/A"; NotifyOfPropertyChange(() => Variable3Name);
        }

        public string Variable1Input
        {
            get { return _variable1Input; }
            set { _variable1Input = value; NotifyOfPropertyChange(() => Variable1Input); }
        }
        public string Variable2Input
        {
            get { return _variable2Input; }
            set { _variable2Input = value; NotifyOfPropertyChange(() => Variable2Input); }
        }
        public string Variable3Input
        {
            get { return _variable3Input; }
            set { _variable3Input = value; NotifyOfPropertyChange(() => Variable3Input); }
        }

        public string InvalidInputText
        {
            get { return _invalidInputText; }
            set { _invalidInputText = value; NotifyOfPropertyChange(() => InvalidInputText); }
        }

        public void AlterButton()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            // Code will execute if the Modify radio button is selected
            if (_modifyChecked)
            {
                if (RbMetals)
                {
                    if(Variable1Input != null && IsDouble(Variable2Input) && SelectedMetal != null)
                    {
                        _invalidInputText = ""; NotifyOfPropertyChange(() => InvalidInputText);
                        for (int i = 0; i < _metals.Count; i++)
                        {
                            if (SelectedMetal == _metals[i])
                            {
                                _metals.RemoveAt(i);
                                _metals.Insert(i, new MetalModel(_variable1Input, Convert.ToDouble(_variable2Input)));
                                _jsonString = JsonSerializer.Serialize(_metals, options);
                                File.WriteAllText(@"Metals.json", _jsonString);
                            }
                        }
                    }
                    else { _invalidInputText = "Invalid Input"; NotifyOfPropertyChange(() => InvalidInputText); }
                }               
                if (RbSizes)
                {
                    if (Variable1Input != null && IsDouble(Variable2Input) && IsDouble(Variable3Input) && SelectedRingSize != null)
                    {
                        _invalidInputText = ""; NotifyOfPropertyChange(() => InvalidInputText);
                        for (int i = 0; i < _ringSizes.Count; i++)
                        {
                            if (SelectedRingSize == _ringSizes[i])
                            {
                                _ringSizes.RemoveAt(i);
                                _ringSizes.Insert(i, new RingSizeModel(_variable1Input, Convert.ToDouble(_variable2Input), Convert.ToDouble(_variable3Input)));
                                _jsonString = JsonSerializer.Serialize(_ringSizes, options);
                                File.WriteAllText(@"RingSizes.json", _jsonString);
                            }
                        }
                    }
                    else { _invalidInputText = "Invalid Input"; NotifyOfPropertyChange(() => InvalidInputText); }
                }  
            }

            // Code will execute if the Add radio button is selected
            if (_addChecked)
            {                
                if (RbMetals)
                {
                    if (Variable1Input != null && IsDouble(Variable2Input))
                    {
                        _invalidInputText = ""; NotifyOfPropertyChange(() => InvalidInputText);
                        for (int i = 0; i < _metals.Count; i++)
                        {
                            if (SelectedMetal == _metals[i])
                            {
                                _metals.Add(new MetalModel(_variable1Input, Convert.ToDouble(_variable2Input)));
                                _jsonString = JsonSerializer.Serialize(_metals, options);
                                File.WriteAllText(@"Metals.json", _jsonString);
                            }
                        }                     
                    }
                    else { _invalidInputText = "Invalid Input"; NotifyOfPropertyChange(() => InvalidInputText); }
                }               
                if (RbSizes)
                {
                    if (Variable1Input != null && IsDouble(Variable2Input) && IsDouble(Variable3Input))
                    {
                        _invalidInputText = ""; NotifyOfPropertyChange(() => InvalidInputText);
                        for (int i = 0; i < _ringSizes.Count; i++)
                        {
                            if (SelectedRingSize == _ringSizes[i])
                            {
                                _ringSizes.Add(new RingSizeModel(_variable1Input, Convert.ToDouble(_variable2Input), Convert.ToDouble(_variable3Input)));
                                _jsonString = JsonSerializer.Serialize(_ringSizes, options);
                                File.WriteAllText(@"RingSizes.json", _jsonString);
                            }
                        }                       
                    }
                    else { _invalidInputText = "Invalid Input"; NotifyOfPropertyChange(() => InvalidInputText); }
                }     
            }

            // Code will execute if the Remove radio button is selected
            if (_removeChecked)
            {                
                if (SelectedMetal != null)
                {
                    for (int i = 0; i < _metals.Count; i++)
                    {
                        if (SelectedMetal == _metals[i])
                        {
                            _metals.RemoveAt(i);
                            _jsonString = JsonSerializer.Serialize(_metals, options);
                            File.WriteAllText(@"Metals.json", _jsonString);
                        }
                    }                                         
                }
                if (SelectedRingSize != null)
                {
                    for (int i = 0; i < _ringSizes.Count; i++)
                    {
                        if (SelectedRingSize == _ringSizes[i])
                        {
                            _ringSizes.RemoveAt(i);
                            _jsonString = JsonSerializer.Serialize(_ringSizes, options);
                            File.WriteAllText(@"RingSizes.json", _jsonString);
                        }
                    }
                }
            }
        }

        public void RevertToDefaultButton()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            if (RbMetals)
            {
                AddDefaultMetals();
                _jsonString = JsonSerializer.Serialize(_metals, options);
                File.WriteAllText(@"Metals.json", _jsonString);
            }
            if (RbSizes)
            {
                AddDefaultSizes();
                _jsonString = JsonSerializer.Serialize(_ringSizes, options);
                File.WriteAllText(@"RingSizes.json", _jsonString);
            }
        }

        public void AddDefaultMetals()
        {
            _metals.Clear();
            _metals.Add(new MetalModel("Fine Silver", 10.64));
            _metals.Add(new MetalModel("Bright Silver", 10.50));
            _metals.Add(new MetalModel("Sterling Silver", 10.55));
            _metals.Add(new MetalModel("Fine Gold", 19.36));
            _metals.Add(new MetalModel("18ct Yellow Gold", 16.04));
            _metals.Add(new MetalModel("14ct Yellow Gold", 13.56));
            _metals.Add(new MetalModel("9ct Yellow Gold", 11.64));
            _metals.Add(new MetalModel("18ct White Gold", 16.59));
            _metals.Add(new MetalModel("14ct White Gold", 14.02));
            _metals.Add(new MetalModel("9ct White Gold", 13.04));
            _metals.Add(new MetalModel("18ct Pink Gold", 15.45));
            _metals.Add(new MetalModel("14ct Pink Gold", 14.00));
            _metals.Add(new MetalModel("9ct Pink Gold", 11.71));
            _metals.Add(new MetalModel("Platinum", 21.24));
            _metals.Add(new MetalModel("Wax", 1.0));
        }

        public void AddDefaultSizes()
        {
            _ringSizes.Clear();
            _ringSizes.Add(new RingSizeModel("A", 0.5, 12.04));
            _ringSizes.Add(new RingSizeModel("B", 1.0, 12.45));
            _ringSizes.Add(new RingSizeModel("C", 1.5, 12.85));
            _ringSizes.Add(new RingSizeModel("D", 2.0, 13.26));
            _ringSizes.Add(new RingSizeModel("E", 2.5, 13.67));
            _ringSizes.Add(new RingSizeModel("F", 3.0, 14.07));
            _ringSizes.Add(new RingSizeModel("G", 3.5, 14.48));
            _ringSizes.Add(new RingSizeModel("H", 4.0, 14.88));
            _ringSizes.Add(new RingSizeModel("I", 4.5, 15.29));
            _ringSizes.Add(new RingSizeModel("J", 5.0, 15.49));
            _ringSizes.Add(new RingSizeModel("K", 5.5, 15.9));
            _ringSizes.Add(new RingSizeModel("L", 6.0, 16.31));
            _ringSizes.Add(new RingSizeModel("M", 6.5, 16.71));
            _ringSizes.Add(new RingSizeModel("N", 7.0, 17.12));
            _ringSizes.Add(new RingSizeModel("O", 7.5, 17.53));
            _ringSizes.Add(new RingSizeModel("P", 8.0, 17.93));
            _ringSizes.Add(new RingSizeModel("Q", 8.5, 18.34));
            _ringSizes.Add(new RingSizeModel("R", 9.0, 18.75));
            _ringSizes.Add(new RingSizeModel("S", 9.5, 19.15));
            _ringSizes.Add(new RingSizeModel("T", 10.0, 19.56));
            _ringSizes.Add(new RingSizeModel("U", 10.5, 19.96));
            _ringSizes.Add(new RingSizeModel("V", 11.0, 20.37));
            _ringSizes.Add(new RingSizeModel("W", 11.5, 20.78));
            _ringSizes.Add(new RingSizeModel("X", 12.0, 21.18));
            _ringSizes.Add(new RingSizeModel("Y", 12.5, 21.59));
            _ringSizes.Add(new RingSizeModel("Z", 13.0, 21.79));
        }
    }
}
