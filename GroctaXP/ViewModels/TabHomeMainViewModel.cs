using GroctaXP.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace GroctaXP.ViewModels
{
    public class TabHomeMainViewModel : INotifyPropertyChanged
    {
        private const string PATH_ICON_ARROW_UP = "resource://GroctaXP.Resources.Icons.ai_arrow_up.svg";
        private const string PATH_ICON_ARROW_DOWN = "resource://GroctaXP.Resources.Icons.ai_arrow_down.svg";

        public bool IsVisibleThirdRow { get; private set; }
        public string ExpandCollapseIcon { get; private set; }
        public ObservableCollection<AdBanner> AdBanners { get; private set; }

        public ICommand ShowHideMoreCategoriesCommand { get; private set; }

        public TabHomeMainViewModel()
        {
            this.ExpandCollapseIcon = PATH_ICON_ARROW_DOWN;
            this.AdBanners = AdBanner.GetDummyList();

            ShowHideMoreCategoriesCommand = new Command(ShowHideMoreCategories);
        }

        private void ShowHideMoreCategories()
        {
            IsVisibleThirdRow = !IsVisibleThirdRow;

            if (IsVisibleThirdRow)
                ExpandCollapseIcon = PATH_ICON_ARROW_UP;
            else
                ExpandCollapseIcon = PATH_ICON_ARROW_DOWN;

            AdBanners = AdBanner.GetDummyList();

            OnPropertyChanged("AdBanners");
            OnPropertyChanged("IsVisibleThirdRow");
            OnPropertyChanged("ExpandCollapseIcon");
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
