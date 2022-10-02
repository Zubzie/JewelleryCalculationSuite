using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryCalculationSuite
{
    public class CalcFunctions : Screen
    {
        private string _calculateText = "";
        protected const double pi = 3.14159265359;

        public string CalculateText
        {
            get { return _calculateText; }
            set
            {
                _calculateText = value;
                NotifyOfPropertyChange(() => CalculateText);
            }
        }

        public static bool IsDouble(string input)
        {
            bool isDouble = Double.TryParse(input, out _);
            if (isDouble) return true;
            return false;
        }

        public virtual void CalculateButton()
        {

        }
    }
}
