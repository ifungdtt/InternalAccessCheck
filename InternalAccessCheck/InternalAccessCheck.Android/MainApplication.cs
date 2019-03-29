using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Airwatch.App;
using Com.Airwatch.Gateway.UI;

namespace InternalAccessCheck.Droid
{
    [Application(Label = "@string/app_name", Icon = "@mipmap/icon")]
    class MainApplication : AWApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }
        public override Intent MainActivityIntent
        {
            get
            {
                var intent = new Intent(ApplicationContext, typeof(MainActivity)); // MainActivity is application's main landing activity
                return intent;
            }
        }
        public override Intent MainLauncherIntent
        {
            get
            {
                var intent = new Intent(ApplicationContext, typeof(GatewaySplashActivity));
                return intent;
            }
        }

        public override bool MagCertificateEnable
        {
            get
            {
                return true; // to fetch mag certificate during initial setup
            }
        }

        protected override bool IsInputLogoBrandable
        {
            get
            {
                return true; // to brand application logo
            }
        }


        public override void OnPostCreate()
        {
            base.OnPostCreate();
            // App specific code here
        }
    }
}