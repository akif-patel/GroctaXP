using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GroctaXP.Droid.Extensions.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName(GroctaXP.Extensions.Effects.ImageTint.GroupName)]
[assembly: ExportEffect(typeof(ImageTintImplementation), nameof(GroctaXP.Extensions.Effects.ImageTint))]
namespace GroctaXP.Droid.Extensions.Effects
{
    public class ImageTintImplementation : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (GroctaXP.Extensions.Effects.ImageTint)Element.Effects.FirstOrDefault(
                    e => e is GroctaXP.Extensions.Effects.ImageTint);

                if (effect == null || !(Control is ImageView image))
                    return;

                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), 
                    PorterDuff.Mode.SrcIn);
                image.SetColorFilter(filter);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDetached() { }
    }
}

//[assembly: ExportEffect(typeof(TintImageImpl), nameof(XamarinStudy.Common.Controls.TintImage))]  
//namespace XamarinStudy.Droid.Effects
//{
//    public class TintImageImpl : PlatformEffect
//    {
//        protected override void OnAttached()
//        {
//            try
//            {
//                var effect = (XamarinStudy.Common.Controls.TintImage)Element.Effects.FirstOrDefault(e => e is XamarinStudy.Common.Controls.TintImage);

//                if (effect == null || !(Control is ImageView image))
//                    return;

//                var filter = new PorterDuffColorFilter(effect.TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
//                image.SetColorFilter(filter);
//            }
//            catch (Exception ex)
//            {

//            }
//        }

//        protected override void OnDetached() { }
//    }
//}