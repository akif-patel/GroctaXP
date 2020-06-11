using FFImageLoading.Svg.Forms;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GroctaXP.Controls
{
    public class SvgImage : SvgCachedImage
    {
        public static BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(SvgCachedImage));
        public Color Color
        {
            get { return (Color) GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ColorProperty.PropertyName)
            {
                
                ReplaceStringMap = new Dictionary<string, string>() { { "rgb(0,0,0)", this.GetColorAsRGB() } };
            }
        }

        private string GetColorAsRGB()
        {
            System.Drawing.Color hexColor = ColorConverters.FromHex(this.Color.ToHex());

            return String.Format
                ("rgb({0},{1},{2})", 
                hexColor.R.ToString(),
                hexColor.G.ToString(),
                hexColor.B.ToString());
        }
    }
}
