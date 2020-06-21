using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Telephony;
using Android.Views;
using Android.Widget;
using GroctaXP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(GroctaXP.Droid.Services.DeviceInfo))]
namespace GroctaXP.Droid.Services
{

    public class DeviceInfo : IDeviceInfo
    {
        public string GetMyPhoneNumber()
        {
            try
            {
                TelephonyManager mTelephonyMgr;
                mTelephonyMgr = (TelephonyManager)Android.App.Application.Context.GetSystemService(Context.TelephonyService);

                var Number = mTelephonyMgr.Line1Number;
                return Number; 
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}