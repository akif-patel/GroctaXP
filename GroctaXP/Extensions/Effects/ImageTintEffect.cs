using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GroctaXP.Extensions.Effects
{
    public static class ImageTintEffect
    {
        public static BindableProperty TintColorProperty =
            BindableProperty.CreateAttached("TintColor",
                                            typeof(Color),
                                            typeof(ImageTintEffect),
                                            Color.Default,
                                            propertyChanged: OnTintColorPropertyPropertyChanged);

        public static Color GetTintColor(BindableObject element)
        {
            return (Color)element.GetValue(TintColorProperty);
        }

        public static void SetTintColor(BindableObject element, Color value)
        {
            element.SetValue(TintColorProperty, value);
        }


        static void OnTintColorPropertyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            AttachEffect(bindable as Image, (Color)newValue);
        }

        static void AttachEffect(Image element, Color color)
        {
            var effect = element.Effects.FirstOrDefault(x => x is ImageTint) as ImageTint;

            if (effect != null)
            {
                element.Effects.Remove(effect);
            }

            element.Effects.Add(new ImageTint(color));
        }

    }
}
