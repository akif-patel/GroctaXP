using GroctaXP.Controls;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePageTabbed : TabLayout
    {
        public WelcomePageTabbed()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}