using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.Design.Internal;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using GroctaXP.Droid.Extensions.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using grocta_ctl = GroctaXP.Controls;
//using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

[assembly: ExportRenderer(typeof(grocta_ctl.TabLayout), typeof(GroctaTabLayoutRenderer))]
namespace GroctaXP.Droid.Extensions.Renderers
{
    public class GroctaTabLayoutRenderer : TabbedPageRenderer
    {
        private Xamarin.Forms.TabbedPage tabbedPage;
        private BottomNavigationView bottomNavigationView;
        //private IMenuItem lastItemSelected;
        int lastItemId = -1;

        public GroctaTabLayoutRenderer(Context ctx) : base(ctx)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                tabbedPage = e.NewElement as Xamarin.Forms.TabbedPage;
                bottomNavigationView = (GetChildAt(0) as Android.Widget.RelativeLayout).GetChildAt(1) as BottomNavigationView;
                bottomNavigationView.NavigationItemSelected += BottomNavigationView_NavigationItemSelected;
                //Call to change the font
                ChangeFont();
            }

            if (e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationView_NavigationItemSelected;
            }
        }

        //Change Tab font
        private void ChangeFont()
        {
            var fontFace = Typeface.CreateFromAsset(Context.Assets, "Celias-Medium.ttf");
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            for (int i = 0; i < bottomNavMenuView.ChildCount; i++)
            {
                var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                var itemTitle = item.GetChildAt(1);

                var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
                var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

                lastItemId = bottomNavMenuView.SelectedItemId;

                smallTextView.SetTypeface(fontFace, TypefaceStyle.Normal);
                largeTextView.SetTypeface(fontFace, TypefaceStyle.Normal);

                smallTextView.SetTextSize(Android.Util.ComplexUnitType.Sp, 10);
                largeTextView.SetTextSize(Android.Util.ComplexUnitType.Sp, 12);
            }
        }

        private void BottomNavigationView_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            var normalColor = tabbedPage.UnselectedTabColor.ToAndroid();
            var selectedColor = tabbedPage.SelectedTabColor.ToAndroid();
            var bottomNavMenuView = bottomNavigationView.GetChildAt(0) as BottomNavigationMenuView;

            if (lastItemId != -1)
            {
                SetTabItemTextColor(bottomNavMenuView.GetChildAt(lastItemId) as BottomNavigationItemView, normalColor);
                
            }

            SetTabItemTextColor(bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView, selectedColor);
            //ChangeTabIcon(bottomNavMenuView.GetChildAt(e.Item.ItemId) as BottomNavigationItemView, true);

            this.OnNavigationItemSelected(e.Item);
            lastItemId = e.Item.ItemId;
        }

        private void SetTabItemTextColor(BottomNavigationItemView bottomNavigationItemView, Android.Graphics.Color textColor)
        {
            var itemTitle = bottomNavigationItemView.GetChildAt(1);
            var smallTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(0));
            var largeTextView = ((TextView)((BaselineLayout)itemTitle).GetChildAt(1));

            smallTextView.SetTextColor(textColor);
            largeTextView.SetTextColor(textColor);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            bottomNavigationView.Visibility = ((grocta_ctl.TabLayout)sender).HideBar ? ViewStates.Gone : ViewStates.Visible;
        }
    }
}