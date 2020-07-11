using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace GroctaXP.Controls
{
    public partial class TabLayout : Xamarin.Forms.TabbedPage
    {
        #region Property Hide Bar
        public static readonly BindableProperty HideBarProperty =
            BindableProperty.Create("HideBar", typeof(bool), typeof(TabLayout), false);
        public bool HideBar
        {
            get { return (bool)GetValue(HideBarProperty); }
            set { SetValue(HideBarProperty, value); }
        }
        #endregion

        public TabLayout()
        {

        }
    }
}
