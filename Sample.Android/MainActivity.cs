
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using System;
using Android.Views;
using Android.Widget;
using Com.Clevertap.Android.Sdk;
using System.Collections.Generic;
using Java.Util;
using Com.Clevertap.Android.Sdk.Displayunits.Model;
using Android.Util;

using Google.Android.Material.Snackbar;
using Google.Android.Material.FloatingActionButton;

using Java.Lang;
using Com.Clevertap.Android.Sdk.Displayunits;
using Com.Clevertap.Android.Sdk.Product_config;
using AndroidX.AppCompat.App;
using Android;

namespace Sample.Droid
{
   

    [Activity(Label = "Sample", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, ICTInboxListener, ICTExperimentsListener, IDisplayUnitListener, ICTFeatureFlagsListener, ICTProductConfigListener, IInAppNotificationButtonListener, IInboxMessageButtonListener
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            CleverTapAPI cleverTapAPI = CleverTapAPI.GetDefaultInstance(Android.App.Application.Context);
            base.OnCreate(savedInstanceState);

            CleverTapAPI.SetDebugLevel(CleverTapAPI.LogLevel.Debug);

            IDictionary<string, Java.Lang.Object> profileData = new Dictionary<string, Java.Lang.Object>();

            profileData.Add("Name", "Xamarin Test");    // String
            profileData.Add("Identity", 61020032);      // String or number
            profileData.Add("Email", "x@x.com"); // Email address of the user
            profileData.Add("Phone", "+14155951234");   // Phone (with the country code, starting with +)
            profileData.Add("Gender", "M");             // Can be either M or F
            profileData.Add("DOB", new Date());         // Date of Birth. Set the Date object to the appropriate value first - requires java.util


            cleverTapAPI.PushProfile(profileData);

            cleverTapAPI.PushEvent("Product View Via Xamarin");

            //Record Charged
            IDictionary<string, Java.Lang.Object> chargedDetails = new Dictionary<string, Java.Lang.Object>();
            chargedDetails.Add("Total Amount", 400);

            IDictionary<string, Java.Lang.Object> item1 = new Dictionary<string, Java.Lang.Object>();
            item1.Add("Product Name", "Harry Potter");
            item1.Add("ProductID", "4756");
            item1.Add("Price", 300);

            IDictionary<string, Java.Lang.Object> item2 = new Dictionary<string, Java.Lang.Object>();
            item2.Add("Product Name", "Harry Potter 2");
            item2.Add("ProductID", "4776");
            item2.Add("Price", 100);

            List<IDictionary<string, Java.Lang.Object>> items = new List<IDictionary<string, Java.Lang.Object>>();
            items.Add(item1);
            items.Add(item2);

            cleverTapAPI.PushChargedEvent(chargedDetails, items);

            CleverTapAPI.CreateNotificationChannel(Android.App.Application.Context, "BRTesting", "BRTesting", "BRTesting", 5, true);
            //Create Channel Group
            CleverTapAPI.CreateNotificationChannelGroup(Android.App.Application.Context, "YourGroupId", "Your Group Name");
            //PushTokenAsync();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        private async System.Threading.Tasks.Task PushTokenAsync()
        {
            var instanceIdResult = await FirebaseInstanceId.Instance.GetInstanceId().AsAsync<IInstanceIdResult>();
            string token = instanceIdResult.Token;

            CleverTapAPI.PushFcmRegistrationId(token, true);
            Log.Debug("TOken", "token Sent" + token);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void InboxDidInitialize()
        {
            throw new NotImplementedException();
        }

        public void InboxMessagesDidUpdate()
        {
            throw new NotImplementedException();
        }

        public void CTExperimentsUpdated()
        {
            throw new NotImplementedException();
        }

        public void OnDisplayUnitsLoaded(IList<CleverTapDisplayUnit> p0)
        {
            throw new NotImplementedException();
        }

        public void FeatureFlagsUpdated()
        {
            throw new NotImplementedException();
        }

        public void OnActivated()
        {
            throw new NotImplementedException();
        }

        public void OnFetched()
        {
            throw new NotImplementedException();
        }

        public void OnInit()
        {
            throw new NotImplementedException();
        }

        public void OnInAppButtonClick(IDictionary<string, string> p0)
        {
            throw new NotImplementedException();
        }

        public void OnInboxButtonClick(IDictionary<string, string> p0)
        {
            throw new NotImplementedException();
        }
    }
}