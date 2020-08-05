using System;
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
        }

        private void TouchEff_Completed(VisualElement sender, TouchEffect.EventArgs.TouchCompletedEventArgs args)
        {
            Application.Current.MainPage.DisplayAlert("Tap!", "The Completed event was fired", "Cancel");
        }
    }
}