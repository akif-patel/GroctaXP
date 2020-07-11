using Android.Content;
using Android.Views;
using Android.Widget;
using GroctaXP.Droid.Utils;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using GroctaCtrl = GroctaXP.Controls;
using GroctaRes = GroctaXP.Resources;

[assembly: ExportRenderer(typeof(GroctaCtrl.ImageButton), typeof(GroctaXP.Droid.Extensions.Renderers.ImageButtonRenderer))]
namespace GroctaXP.Droid.Extensions.Renderers
{
    public class ImageButtonRenderer : ViewRenderer<GroctaCtrl.ImageButton, Android.Views.View>
    {
        private readonly Context context;
        private Android.Views.View buttonView;
        private TextView buttonText;
        private ImageView buttonIcon;

        public ImageButtonRenderer(Context context) : base(context)
        {
            this.context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GroctaCtrl.ImageButton> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
                var rootLayout = inflater.Inflate(Resource.Layout.ImageButton, null, false);

                buttonView = (Android.Views.View)rootLayout.FindViewById(Resource.Id.image_button);
                var padding = Utils.Converter.GetDpAsPixel(context, Element.InnerPadding);
                buttonView.SetPadding(padding, padding, padding, padding);

                buttonText = (TextView) rootLayout.FindViewById(Resource.Id.image_button_text);
                buttonText.Text = Element.Text;
                buttonText.SetTextColor(Element.TextColor.ToAndroid());
                FontsUtil.OverrideFont(buttonText, GroctaRes.Resources.AppFontRegular);

                buttonIcon = (ImageView)rootLayout.FindViewById(Resource.Id.image_button_icon);
                buttonIcon.SetImageResource(Resources.GetIdentifier(
                    ((FileImageSource)Element.Source).File,
                    nameof(Resource.Drawable).ToLower(),
                    context.ApplicationContext.PackageName));
                buttonIcon.LayoutParameters.Height = Utils.Converter.GetDpAsPixel(context, Element.IconSize);
                buttonIcon.LayoutParameters.Width = Utils.Converter.GetDpAsPixel(context, Element.IconSize);

                if (Element.TintColor != Color.Transparent)
                    buttonIcon.SetColorFilter(Element.TintColor.ToAndroid());

                //GradientDrawable shape = new GradientDrawable();
                //shape.SetShape(ShapeType.Rectangle);
                //shape.SetColor(Element.BackgroundColor.ToAndroid());
                //shape.SetStroke(1, Element.);
                //v.setBackground(shape);

                SetNativeControl(rootLayout);
                buttonView.Click += (s, a) =>
                {
                    Element.RaiseCommand();
                };
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}