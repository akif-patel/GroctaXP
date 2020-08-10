using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GroctaXP.Models
{
    public class AdBanner : INotifyPropertyChanged
    {
        public string AdID { get; set;}
        public DateTime Date { get; set;}
        public string Title { get; set;}
        public string Description { get; set;}
        public string ImageURL { get; set;}

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static ObservableCollection<AdBanner> GetDummyList()
        {
            ObservableCollection<AdBanner> banner = new ObservableCollection<AdBanner>
            {
                new AdBanner { ImageURL = "banner_1.png" },
                new AdBanner { ImageURL = "banner_2.png" },
                new AdBanner { ImageURL = "banner_1.png" }
            };

            return banner;
        }
    }
}
