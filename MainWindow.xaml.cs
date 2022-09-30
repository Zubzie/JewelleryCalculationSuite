using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JewelleryProgramV3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Metal> metalList = new List<Metal>();
        List<RingSize> ringSizeList = new List<RingSize>();

        public MainWindow()
        {
            InitializeComponent();

            AddDefaultSizes();
            AddDefaultMetals();                      

            metalsDropDown1.ItemsSource = metalList;
            metalsDropDown2.ItemsSource = metalList;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            int selection = 0;
            selection = metalsDropDown1.SelectedIndex;
            if (selection == -1) { selection = 0; }
            Metal oldMetal = metalList[selection];

            selection = metalsDropDown2.SelectedIndex;
            if (selection == -1) { selection = 0; }
            Metal newMetal = metalList[selection];

            if (oldMetal != null && newMetal != null && isDouble(oldMetalWeight.Text.ToString()))
            {
                double weight = Convert.ToDouble(oldMetalWeight.Text);
                weight *= 1.0 / oldMetal.SpecificGravity;
                weight *= newMetal.SpecificGravity;

                metalCalcText.Text = weight.ToString("F3") + "g";
            }
            else { metalCalcText.Text = ("Invalid Input"); }
        }
        private bool isDouble(string input)
        {
            bool isDouble = Double.TryParse(input, out _);
            if (isDouble) return true;
            return false;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddDefaultMetals()
        {
            metalList.Add(new Metal("Select Metal", 0.0));
            metalList.Add(new Metal("Fine Silver", 10.64));
            metalList.Add(new Metal("Bright Silver", 10.50));
            metalList.Add(new Metal("Sterling Silver", 10.55));
            metalList.Add(new Metal("Fine Gold", 19.36));
            metalList.Add(new Metal("18ct Yellow Gold", 16.04));
            metalList.Add(new Metal("14ct Yellow Gold", 13.56));
            metalList.Add(new Metal("9ct Yellow Gold", 11.64));
            metalList.Add(new Metal("18ct White Gold", 16.59));
            metalList.Add(new Metal("14ct White Gold", 14.02));
            metalList.Add(new Metal("9ct White Gold", 13.04));
            metalList.Add(new Metal("18ct Pink Gold", 15.45));
            metalList.Add(new Metal("14ct Pink Gold", 14.00));
            metalList.Add(new Metal("9ct Pink Gold", 11.71));
            metalList.Add(new Metal("Platinum", 21.24));
            metalList.Add(new Metal("Wax", 1.0));
        }

            private void AddDefaultSizes()
        {
            ringSizeList.Add(new RingSize("A", 0.5, 12.04));
            ringSizeList.Add(new RingSize("B", 1.0, 12.45));
            ringSizeList.Add(new RingSize("C", 1.5, 12.85));
            ringSizeList.Add(new RingSize("D", 2.0, 13.26));
            ringSizeList.Add(new RingSize("E", 2.5, 13.67));
            ringSizeList.Add(new RingSize("F", 3.0, 14.07));
            ringSizeList.Add(new RingSize("G", 3.5, 14.48));
            ringSizeList.Add(new RingSize("H", 4.0, 14.88));
            ringSizeList.Add(new RingSize("I", 4.5, 15.29));
            ringSizeList.Add(new RingSize("J", 5.0, 15.49));
            ringSizeList.Add(new RingSize("K", 5.5, 15.9));
            ringSizeList.Add(new RingSize("L", 6.0, 16.31));
            ringSizeList.Add(new RingSize("M", 6.5, 16.71));
            ringSizeList.Add(new RingSize("N", 7.0, 17.12));
            ringSizeList.Add(new RingSize("O", 7.5, 17.53));
            ringSizeList.Add(new RingSize("P", 8.0, 17.93));
            ringSizeList.Add(new RingSize("Q", 8.5, 18.34));
            ringSizeList.Add(new RingSize("R", 9.0, 18.75));
            ringSizeList.Add(new RingSize("S", 9.5, 19.15));
            ringSizeList.Add(new RingSize("T", 10.0, 19.56));
            ringSizeList.Add(new RingSize("U", 10.5, 19.96));
            ringSizeList.Add(new RingSize("V", 11.0, 20.37));
            ringSizeList.Add(new RingSize("W", 11.5, 20.78));
            ringSizeList.Add(new RingSize("X", 12.0, 21.18));
            ringSizeList.Add(new RingSize("Y", 12.5, 21.59));
            ringSizeList.Add(new RingSize("Z", 13.0, 21.79));
        }
    }
}
