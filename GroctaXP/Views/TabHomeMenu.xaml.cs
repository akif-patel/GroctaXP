using FFImageLoading.Forms;
using FFImageLoading.Svg.Forms;
using GroctaXP.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabHomeMenu : ContentPage
    {
        public TabHomeMenu()
        {
            InitializeComponent();

            if (Application.Current.Properties["EmailAddress"] != null)
                lblEmail.Text =  Application.Current.Properties["EmailAddress"].ToString();

            if (Application.Current.Properties["FirstName"] != null)
                LabelUserName.Text = Application.Current.Properties["FirstName"].ToString() + " " + Application.Current.Properties["LastName"].ToString();
        }

        void OnTapOpenSubMenu(object sender, EventArgs args)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs) args;

            if (tappedEventArgs.Parameter.Equals("MenuSupport"))
            {
                View subMenuView = ((View)this.FindByName("ViewMenuSupport_All"));
                SvgImage icon = (SvgImage)subMenuView.FindByName("ImgSupportMenuStateIcon");
                Label menuDesc = (Label)subMenuView.FindByName("LabelSupportMenuDesc");

                subMenuView.IsVisible = !subMenuView.IsVisible;
                if (subMenuView.IsVisible)
                {
                    menuDesc.Text = "All the support you need";
                    icon.Source = new EmbeddedResourceImageSource(new Uri("resource://GroctaXP.Resources.Icons.ai_arrow_up.svg"));
                }
                else
                {
                    menuDesc.Text = "Contact Us, Feedback, FAQs & Share";
                    icon.Source = new EmbeddedResourceImageSource(new Uri("resource://GroctaXP.Resources.Icons.ai_arrow_down.svg"));
                }
            }
            else if (tappedEventArgs.Parameter.Equals("MenuMyAccount"))
            {
                View subMenuView = ((View)this.FindByName("ViewMenuMyAccount_All"));
                SvgImage icon = (SvgImage)subMenuView.FindByName("ImgMyAccountMenuStateIcon");
                Label menuDesc = (Label)subMenuView.FindByName("LabelMyAccountMenuDesc");

                subMenuView.IsVisible = !subMenuView.IsVisible;
                if (subMenuView.IsVisible)
                {
                    menuDesc.Text = "All your account details";
                    icon.Source = new EmbeddedResourceImageSource(new Uri("resource://GroctaXP.Resources.Icons.ai_arrow_up.svg"));
                }
                else
                {
                    menuDesc.Text = "Delivery Locations, Orders, Quick Baskets & Others";
                    icon.Source = new EmbeddedResourceImageSource(new Uri("resource://GroctaXP.Resources.Icons.ai_arrow_down.svg"));
                }
            }
        }
    }
}