using System;
using System.Collections.Generic;
using System.Text;

namespace GroctaXP.Models
{
    public enum MenuItemType
    {
        MyDeliveryLocations,
        MyOrderHistory,
        MyFavoriteGroceries,
        MyQuickBaskets,
        GroctaAllCategories,
        GroctaNotifications,
        GroctaRefundWallet,
        HelpFeedback,
        HelpRateUs,
        HelpShare
    }
    
    public enum MenuItemGroupType
    {
        My,
        Grocta,
        Help
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }
    }

    public class HomeMenuItemList : List<HomeMenuItem>
    {
        public string Group { get; set; }
        public List<HomeMenuItem> HomeMenuItems => this;
    }
}
