﻿using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageTabbed : Xamarin.Forms.TabbedPage
    {
        public MainPageTabbed()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //On<Xamarin.Forms.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);


        }
    }
}