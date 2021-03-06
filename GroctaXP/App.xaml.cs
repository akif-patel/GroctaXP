﻿using System;
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
            //MainPage = new WelcomePageTabbed();
            // MainPage = new MainPageTabbed();
            MainPage = new TabWelcomeSplash();
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
