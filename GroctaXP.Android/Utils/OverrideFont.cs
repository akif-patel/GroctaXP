using Android.Graphics;
using Android.Widget;
using Grocta = GroctaXP.Resources;

namespace GroctaXP.Droid.Utils
{
    public class FontsUtil
    {
        public static void OverrideFont(TextView view, string fontName)
        {
            if(string.IsNullOrEmpty(fontName))
                fontName = Grocta.Resources.AppFontRegular;

            var fontFace = Typeface.CreateFromAsset(view.Context.Assets, fontName);

           view.SetTypeface(fontFace, TypefaceStyle.Normal);
        }

        public static void OverrideFont(TextView view)
        {
            string fontName = Grocta.Resources.AppFontRegular;

            var fontFace = Typeface.CreateFromAsset(view.Context.Assets, fontName);

            view.SetTypeface(fontFace, TypefaceStyle.Normal);
        }
    }
}