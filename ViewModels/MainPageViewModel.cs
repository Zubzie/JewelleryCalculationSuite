using Caliburn.Micro;
using System.IO;

namespace JewelleryCalculationSuite.ViewModels
{
    public class MainPageViewModel : Screen
    {
        public static string ImagePath
        {
            get { return Path.GetFullPath("Images/Icon.ico"); }
        }
    }
}
