using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GroctaXP.Services;
using GroctaXP.Views;

namespace GroctaXP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //MainPage = new MainPage();
            MainPage = new MainPageTabbed();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
