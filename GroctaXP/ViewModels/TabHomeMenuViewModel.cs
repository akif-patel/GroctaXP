using GroctaXP.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GroctaXP.ViewModels
{
    public class TabHomeMenuViewModel : INotifyPropertyChanged
    {
        public bool IsVisibleMyAccountSubMenu { get; private set; }
        public bool IsVisibleGroctaSupportSubMenu { get; private set; }
        public string AppVersion { get; private set; }

        public List<RecentOrder> RecentOrders { get; private set; }

        public ICommand ShowHideMyAccountSubMenuCommand { get; private set; }
        public ICommand ShowHideGroctaSupportSubMenuCommand { get; private set; }
        public ICommand EditUserProfileCommand { get; private set; }
        public ICommand ShowCurrentLocalityCommand { get; private set; }
        public ICommand ReferFriendCommand { get; private set; }
        public ICommand RateUsCommand { get; private set; }

        public TabHomeMenuViewModel()
        {
            this.GetAppVersion();
            ShowHideMyAccountSubMenuCommand = new Command(ShowHideMyAccountSubMenu);
            ShowHideGroctaSupportSubMenuCommand = new Command(ShowHideGroctaSupportSubMenu);
            EditUserProfileCommand = new Command(EditUserProfile);
            ShowCurrentLocalityCommand = new Command(ShowCurrentLocality);

            RecentOrders = new List<RecentOrder>();
            RecentOrders = RecentOrder.GetDummyList(); ;
        }

        private void ShowHideMyAccountSubMenu()
        {
            IsVisibleMyAccountSubMenu = !IsVisibleMyAccountSubMenu;
            OnPropertyChanged("IsVisibleMyAccountSubMenu");
        }

        private void ShowHideGroctaSupportSubMenu()
        {
            IsVisibleGroctaSupportSubMenu = !IsVisibleGroctaSupportSubMenu;
            OnPropertyChanged("IsVisibleGroctaSupportSubMenu");
        }

        private void EditUserProfile() {
        }

        private void ShowCurrentLocality()
        {
        }

        private void GetAppVersion()
        {
            this.AppVersion = "App Version: 1.0.0";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
