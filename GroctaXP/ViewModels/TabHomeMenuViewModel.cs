using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GroctaXP.ViewModels
{
    public class TabHomeMenuViewModel : INotifyPropertyChanged
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

        public Command MyCommand { get; private set; }

        public TabHomeMenuViewModel()
        {
            // configure the TapCommand with a method

            Message = "Waiting";
            MyCommand = new Command(UpdateVersion);
        }

        private void UpdateVersion()
        {
            Message += "Clicked ";
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
