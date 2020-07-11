using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GroctaXP.Droid.Utils
{
    public class Converter
    {
        public static int GetDpAsPixel(Context context, int dp)
        {
            float scale = context.Resources.DisplayMetrics.Density;
            return (int)(dp * scale + 0.5f);
        }
    }
}