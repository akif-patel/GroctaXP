using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GroctaXP.Models
{
    public class RecentOrder : INotifyPropertyChanged
    {
        public string OrderNo { get; set;}
        public string Date { get; set;}
        public string Status { get; set;}
        public string Quantities { get; set;}
        public string Amnout { get; set;}
        public bool IsLastInList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<RecentOrder> GetDummyList()
        {
            List<RecentOrder> recentOrders = new List<RecentOrder>();

            recentOrders.Add(new RecentOrder() { OrderNo = "MTMB202007302002", Date = "2020-01-05 11:23", Status = "DELIVERED", Quantities = "03", Amnout = "500" });
            recentOrders.Add(new RecentOrder() { OrderNo = "MTMB201917302653", Date = "2020-06-17 14:55", Status = "CANCELLED", Quantities = "05", Amnout = "800" });
            recentOrders.Add(new RecentOrder() { OrderNo = "MTMB201917302653", Date = "2020-06-17 14:55", Status = "CANCELLED", Quantities = "05", Amnout = "800", IsLastInList = true });

            return recentOrders;
        }
    }
}
