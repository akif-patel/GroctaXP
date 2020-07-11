using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GroctaXP.Extensions.Effects
{
    public class ImageTint : RoutingEffect
    {
        public const string GroupName = "Grocta";
        public Color TintColor { get; set; }
        public ImageTint(Color color) : base($"{GroupName}.{nameof(ImageTint)}")
        {
            TintColor = color;
        }
    }
}