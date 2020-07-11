using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GroctaXP.Utils
{
    public class Utility
    {
        public static Color GetColorFromAppResources(string ColorName)
        {
            return (Color)Application.Current.Resources[ColorName];
        }
    }
}
