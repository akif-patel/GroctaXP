using GroctaXP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GroctaXP.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public List<HomeMenuItemList> _menuItemList;
        public List<HomeMenuItemList> MenuItemList { get { return _menuItemList; } set { _menuItemList = value; } }

        public MenuPage()
        {
            InitializeComponent();
            InitializeMainMenu();

            //menuItems = new List<HomeMenuItem>
            //{
            //    new HomeMenuItem {Id = MenuItemType.DeliveryLocations, Title="Delivery Locations" },
            //    new HomeMenuItem {Id = MenuItemType.OrderHistory, Title="Order History" },
            //    new HomeMenuItem {Id = MenuItemType.FavoriteGroceries, Title="Favorite Groceries" },
            //    new HomeMenuItem {Id = MenuItemType.QuickBaskets, Title="Quick Baskets" },
            //};

            //ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.ItemSelected += async (sender, e) =>
            //{
            //    if (e.SelectedItem == null)
            //        return;

            //    //var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            //    //await RootPage.NavigateFromMenu(id);
            //};

            System.Diagnostics.Debug.WriteLine(typeof(MenuPage).Assembly.FullName);
            //var assembly = typeof(MenuPage).GetTypeInfo().Assembly;
            //foreach (var res in assembly.GetManifestResourceNames())
            //{
            //    System.Diagnostics.Debug.WriteLine("found resource: " + res);
            //}
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Console.WriteLine(this.GetType().GetTypeInfo().Assembly.ToString());
        }

        private void InitializeMainMenu()
        {
            _menuItemList = new List<HomeMenuItemList>();
            HomeMenuItemList menuList = new HomeMenuItemList() { Group = MenuItemGroupType.My.ToString() };

            menuList.Add(new HomeMenuItem() { Id = MenuItemType.MyDeliveryLocations, Title = "Delivery Locations", Icon = "GroctaXP.Resources.Icons.ai_delivery_location.svg" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.MyOrderHistory, Title = "Order History" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.MyFavoriteGroceries, Title = "Favorite Groceries" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.MyQuickBaskets, Title = "Quick Baskets" });
            _menuItemList.Add(menuList);

            menuList = new HomeMenuItemList() { Group = MenuItemGroupType.Grocta.ToString() };
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.GroctaAllCategories, Title = "All Categories" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.GroctaRefundWallet, Title = "Refund Wallet" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.GroctaNotifications, Title = "Notifications & Alerts" });
            _menuItemList.Add(menuList);

            menuList = new HomeMenuItemList() { Group = MenuItemGroupType.Help.ToString() };
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.HelpFeedback, Title = "Feedback\\Contact Us" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.HelpRateUs, Title = "Rate Us" });
            menuList.Add(new HomeMenuItem() { Id = MenuItemType.HelpShare, Title = "Share" });
            _menuItemList.Add(menuList);

            ListViewMenu.ItemsSource = _menuItemList;
        }
    }
}