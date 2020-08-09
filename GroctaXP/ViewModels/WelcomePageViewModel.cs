using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GroctaXP.ViewModels
{
    public class WelcomePageViewModel : INotifyPropertyChanged
    {
        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs("Message"));
            }
        }

        public ICommand CommandBeginFacebookLogin
        {
            get
            {
                return new Command
                (
                    (parameter) =>
                    {
                        var page = parameter as ContentPage;
                        var parentPage = page.Parent as TabbedPage;
                        parentPage.CurrentPage = parentPage.Children[1];
                    }
                );
            }
        }

        public ICommand CommandAddDeliveryAddress
        {
            get
            {
                return new Command
                (
                    (parameter) =>
                    {
                        var page = parameter as ContentPage;
                        var parentPage = page.Parent as TabbedPage;
                        parentPage.CurrentPage = parentPage.Children[2];
                    }
                );
            }
        }

        public WelcomePageViewModel()
        {
            Message = "Waiting";
        }

        private void NavigateToTab()
        {
            //this.
            //CurrentPage = Children[1];

            //Application.Current.MainPage.DisplayAlert("Login", "Login with Google", "Cancel");
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
